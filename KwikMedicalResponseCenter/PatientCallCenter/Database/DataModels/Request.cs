using KwikMedicalResponseCenter.PatientCallCenter.Application;
using KwikMedicalResponseCenter.PatientCallCenter.Enums;
using KwikMedicalResponseCenter.PatientCallCenter.Presentation;
using KwikMedicalResponseCenter.SharedResources.SharedDataStructs;
using Microsoft.Maui.Controls;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalResponseCenter.PatientCallCenter.Database.DataModels
{
    public class Request
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        // These fields could also be set up with getters and setters, however since the database for this
        // module is only used to enter logs and it does not provide any value to the prototype it is emitted
        public DateTime TimeReceived;
        public DateTime TimeResolved;
        public Status Status;
        public Severity Severity;
        public bool manualSeverity = false;
        public string Message = "";
        public Coordinate Cord;
        public PatientDetails Details;

        public Request(DateTime timeReceived, string message, Coordinate cord, PatientDetails details)
        {
            this.Id = Guid.NewGuid();
            this.TimeReceived = timeReceived;
            this.Message = message;
            this.Cord = cord;
            this.Details = details;
        }

        public Request(Req req, NHSDB db)
        {
            this.Id = Guid.NewGuid();
            this.TimeReceived = req.TimeReceived;
            this.Message= req.Message;
            this.Severity = req.Severity;
            this.Cord = AddressToCoordinate.GetCordFromAddress(req.Address);
            this.Details = db.QueryPatientRecord(req.NHSNumber, req.PatientName);           
        }

    }
}
