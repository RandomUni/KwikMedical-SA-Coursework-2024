using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KwikMedicalAmbulance.AmbulanceManager.Database.DataModel
{
    public class SubmittableRequest
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
        public string AmbulanceAllocated { get; set; }

        [Required]
        public string HealthcareProvider { get; set; }

        [Required]
        public string Actions { get; set; }

        public string PreviousConditions { get; set; }

        public string toJson()
        {
            return JsonSerializer.Serialize(this);
        }

    }


}

