using KwikMedicalHospital.HospitalCenter.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Database.DataModel
{
    public class AllocatedRequest
    {
        [Required]
        public RequestReceived Request;
        [Required]
        public string HospitalAllocated;
        public string AmbulanceAllocated;
        

        public AllocatedRequest(RequestReceived request, string hospital)
        {
            Request = request;
            HospitalAllocated = hospital;
        }
    }
}
