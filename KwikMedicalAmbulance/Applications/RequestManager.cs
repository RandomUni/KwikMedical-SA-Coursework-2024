
using KwikMedicalAmbulance.AmbulanceManager.Database;
using KwikMedicalAmbulance.AmbulanceManager.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KwikMedicalAmbulance.AmbulanceManager.Applications
{
    public class RequestManager
    {
        // Caching request to be able to query within the app, without requiring database involvment
        private static List<SubmittableRequest> requests = new List<SubmittableRequest>();
        private AmbulanceAllocator ambulanceAllocator;

        public RequestManager(AmbulanceAllocator ambulanceAllocator)
        {
            this.ambulanceAllocator = ambulanceAllocator;
        }

        public SubmittableRequest GetForThisAmbulance(string ambulance)
        {
            List<SubmittableRequest> reqs = requests.Where(req => req.AmbulanceAllocated == ambulance).ToList();
            if (reqs.Count > 1)
            {
                // This should never happen in the application, therefore it is intended to crash the app if happens
                throw new AmbulanceDataError();
            }
            if (reqs.Count == 0)
            {
                return null;
            }
            return reqs[0];
        }

        public SubmittableRequest HandleRequest(string? request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("No request was provided");
            }
            SubmittableRequest req = JsonSerializer.Deserialize<SubmittableRequest>(request) ?? new SubmittableRequest();
            req.Severity = req.Severity + 1;
            if (req.Severity < 3 || req.AmbulanceAllocated != null) 
            {
                req.AmbulanceAllocated = ambulanceAllocator.allocateCloset(req.Address, AmbulanceDB.getAllAmbulances()).Id;
                MauiProgram.send(req.AmbulanceAllocated, null);
                requests.Add(req);
            }
            return req;
        }

        public bool SubmitReport(SubmittableRequest req)
        {
            MauiProgram.sendReport(req.toJson(), null);
            MauiProgram.SendAmbulanceUnbooked(req.AmbulanceAllocated, null);
            AmbulanceDB.changeAmbulanceStatus(req.AmbulanceAllocated, Status.AVAILABLE);
            return requests.Remove(req);
        }

    }
}
