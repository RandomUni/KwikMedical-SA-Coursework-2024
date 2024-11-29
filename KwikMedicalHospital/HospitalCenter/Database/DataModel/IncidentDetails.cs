using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Database.DataModel
{
    public class IncidentDetails
    {
        public string PatientName;
        //While address is stored it cannot be assumed incidents happened 
        public string NHSNumber;
        public string Condition;
        public string Severity;
        public string AmbulanceId;
        public Condition[] PreviousConditions;
    }
}
