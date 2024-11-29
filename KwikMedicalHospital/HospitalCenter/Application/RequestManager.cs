using KwikMedicalHospital.HospitalCenter.Database;
using KwikMedicalHospital.HospitalCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace KwikMedicalHospital.HospitalCenter.Application
{
    internal class RequestManager
    {
        private AssignToHospital hospitalAssigner;
        private AmbulanceAllocator ambulanceAllocator;

        public RequestManager(AssignToHospital assignToHospital, AmbulanceAllocator ambulanceAllocator)
        {
            this.hospitalAssigner = assignToHospital;
            this.ambulanceAllocator = ambulanceAllocator;
        }
    
        public List<AllocatedRequest> getRequestsForHospital(string hospital)
        {
            return HospitalCenterDB.getAllRequestsForHospital(hospital);
        }

        public List<Ambulance> GetAvailableAmbulances()
        {
            return HospitalCenterDB.gelAllAvailableAmbulances();
        }

        public Ambulance AllocateAmbulance(AllocatedRequest req,Ambulance? ambulance = null)
        {        
            if(req.Request.Severity < 3)
            {
                return ambulanceAllocator.allocateCloset(req.Request.Address, HospitalCenterDB.gelAllAvailableAmbulances());
            }
            if (ambulance != null)
            {
                return ambulanceAllocator.SetStatus(ambulance, Status.ON_MISSION);
            }
            throw new NoAmbulance();
        }

        public void BookAmbulance(string ambulanceId)
        {
            HospitalCenterDB.changeAmbulanceStatus(ambulanceId, Status.ON_MISSION);
        }

        public void UnbookAmbulance(string ambulanceId)
        {
            HospitalCenterDB.changeAmbulanceStatus(ambulanceId, Status.AVAILABLE);
        }


        public  AllocatedRequest HandleRequest(string? request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("No request was provided");
            }
            RequestReceived req = JsonSerializer.Deserialize<RequestReceived>(request) ?? new RequestReceived();
            req.Severity = req.Severity + 1;
            if(req.Severity < 3)
            {
                return null;
            }
            string hospital = hospitalAssigner.AssignHospital(req);
            AllocatedRequest newReq = new  AllocatedRequest(req,  hospital);
            HospitalCenterDB.addAllocatedRequest(newReq, request);
            return newReq;
        }

        public void removeRequest(AllocatedRequest req)
        {
            HospitalCenterDB.removeRequest(req);
        }
    }
}
