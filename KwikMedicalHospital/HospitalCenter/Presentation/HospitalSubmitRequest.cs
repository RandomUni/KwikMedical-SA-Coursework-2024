using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Presentation
{
    public class HospitalSubmitRequest
    {
        [Required]
        public int Severity { get; set; }

        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        public string Message { get; set; } = "";

        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        [Required]
        public string Condition { get; set; }
        [Required]
        public string Address { get; set; }

        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        public string NHSNumber { get; set; } = "";
        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        [Required]
        public string PatientName { get; set; }
        [Required]
        public DateTime TimeReceived { get; set; }

        public TimeSpan TimeSpent { get; set; }

        [Required]
        public string HospitalAllocated { get; set; }

        [Required]
        public string HealthcareProvider { get; set; }

        [Required]
        public string Actions { get; set; }

        public HospitalSubmitRequest(SubmittableRequest req)
        {
            this.Severity = req.Severity;
            this.Message = req.Message; 
            this.Condition = req.Condition;
            this.Address = req.Address;
            this.NHSNumber = req.NHSNumber;
            this.PatientName = req.PatientName;
            this.TimeReceived = req.TimeReceived;
            this.HospitalAllocated = req.HospitalAllocated;           
        }

        public HospitalSubmitRequest()
        {

        }
        public string toJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
