using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KwikMedicalServer.Data
{
    public class MedicalRequestResponse
    {
        [Key]
        public int Id { get; set; }
        public int Severity { get; set; }

        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        public string Message { get; set; } = "";

        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        public string Condition { get; set; }
        public string Address { get; set; }

        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        public string NHSNumber { get; set; } = "";
        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        public string PatientName { get; set; }
        public DateTime TimeReceived { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public string HospitalAllocated { get; set; }
        public string HealthcareProvider { get; set; }
        public string Actions { get; set; }
        public string AmbulanceAllocated { get; set; } = "";
    }
}
