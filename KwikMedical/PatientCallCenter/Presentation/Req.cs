using KwikMedical.PatientCallCenter.Application;
using KwikMedical.PatientCallCenter.Enums;
using KwikMedical.PatientCallCenter.Presentation.Helpers;
using KwikMedical.SharedResources;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedical.PatientCallCenter.Presentation
{
	public class Req
	{
		public Severity Severity;
        public int SeverityInt { get; set; }



        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        public string Message { get; set; } = "";

        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        public string Condition { get; set; } = "";

        [Required(ErrorMessage = "Please provide a location for incident")]
        public string Address { get; set; }

        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        public string NHSNumber { get; set; } = "";
        //Changing to empty strings to support of case of unidentified people and avoid messy validation logic
        public string PatientName { get; set; } = "";

		public DateTime TimeReceived;

		public Req(int severity, string message, string condition, string address, string nHSNumber, string patientName)
		{
			Severity = SeverityConverter.ConvertToSevFromInt(severity);
			Message = message;
			Condition = condition;
			Address = address;
			NHSNumber = nHSNumber;
			PatientName = patientName;
			TimeReceived = DateTime.Now;
			// Calling for new request resolver each time to allow easier scaling and prevent system
			// blockages due to resource being occupied and unavailable for new requests 
        }

		public Req() {
		}

		public Req(string message)
		{
     
        }
	}
}
