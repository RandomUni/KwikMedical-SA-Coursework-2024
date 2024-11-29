using KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Application
{
    public class RequestManager
    {
        // Caching request to be able to query within the app, without requiring database involvment
        private static List<SubmittedRequests> requests = new List<SubmittedRequests> ();

        public SubmittedRequests GetForThisAmbulance(string ambulance)
        {
            List<SubmittedRequests> reqs = requests.Where(req => req.AmbulanceAllocated == ambulance).ToList();
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

        public SubmittedRequests HandleRequest(string? request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("No request was provided");
            }
            SubmittedRequests req = JsonSerializer.Deserialize<SubmittedRequests>(request) ?? new SubmittedRequests();
            req.Severity = req.Severity + 1;
            requests.Add(req);
            return req;
        }
    }
}
