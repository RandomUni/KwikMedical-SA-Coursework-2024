using KwikMedicalResponseCenter.PatientCallCenter.Application;
using KwikMedicalResponseCenter.PatientCallCenter.Enums;
using KwikMedicalResponseCenter.PatientCallCenter.Presentation.Helpers;
using KwikMedicalResponseCenter.SharedResources;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KwikMedicalResponseCenter.PatientCallCenter.Presentation
{
	public class Req
	{
		public Severity Severity { get; set; }
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

		public DateTime TimeReceived { get; set; }

		public string PreviousConditions { get; set; }

		public string STH { get; set; } = "hello";


        public Req(int severity, string message, string condition, string address, string nHSNumber, string patientName)
		{
			Severity = SeverityConverter.ConvertToSevFromInt(severity);
			SeverityInt = severity;
			Message = message;
			Condition = condition;
			Address = address;
			NHSNumber = nHSNumber;
			PatientName = patientName;
			TimeReceived = DateTime.Now;
        }

		public Req() {
		}

		public string toJson()
		{
			return JsonSerializer.Serialize(this);
		}
		public Req(string message)
		{
     
        }
	}
}
