using KwikMedicalHospital.HospitalCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Presentation
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

            [Required]
            public string HospitalAllocated {  get; set; }

            public string AmbulanceAllocated {  get; set; }

            public string PreviousConditions { get; set; }

        public SubmittableRequest(AllocatedRequest req)
            {
                this.Severity = req.Request.Severity;
                this.Message = req.Request.Message;
                this.Condition = req.Request.Condition;
                this.Address = req.Request.Address;
                this.NHSNumber = req.Request.NHSNumber;
                this.PatientName = req.Request.PatientName;
                this.TimeReceived = req.Request.TimeReceived;
                this.HospitalAllocated = req.HospitalAllocated;
                this.AmbulanceAllocated = req.AmbulanceAllocated;
                this.PreviousConditions = req.Request.PreviousConditions;
            }

        public string toJson()
        {
            return JsonSerializer.Serialize(this);
        }


    }
    }

