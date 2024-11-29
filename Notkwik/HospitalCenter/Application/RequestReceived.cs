using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Application
{
    public class RequestReceived
    {
        [Required]
        public int Severity { get; set; }
        public int SeverityInt { get; set; }

        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        public string Message { get; set; } = "";

        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        [Required]
        public string Condition { get; set; } = "";
        [Required]
        public string Address { get; set; }

        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        public string NHSNumber { get; set; } = "";
        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        [Required]
        public string PatientName { get; set; } = "";
        [Required]
        public DateTime TimeReceived { get; set; }

    }
}
