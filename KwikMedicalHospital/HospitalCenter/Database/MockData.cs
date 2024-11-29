using KwikMedicalHospital.HospitalCenter.Application;
using KwikMedicalHospital.HospitalCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KwikMedicalHospital.HospitalCenter.Database
{
    internal static class MockData
    {
        public static List<string> requests = new List<string> { { "{\"Severity\":4,\"SeverityInt\":4,\"Message\":\"Fractured Leg\",\"Condition\":\"Fracture\",\"Address\":\"Grove\",\"NHSNumber\":\"123\",\"Pressumed stroke\":\"\"}" }, "{\"Severity\":3,\"SeverityInt\":3,\"Message\":\"Fractured Leg\",\"Condition\":\"Stroke\",\"Address\":\"Elm Grove 11,\",\"NHSNumber\":\"123\",\"PatientName\":\"\"}" };
        public static List<Hospital> hospitals = new List<Hospital> { { new Hospital("Queen Margaret", "Dunfermline", 5) }, { new Hospital("Kirkaldy", "Kirkaldy", 50) } };
        public static List<Ambulance> ambulances = new List<Ambulance> { { new Ambulance("111", "Kelty", "Queen Margaret", Status.AVAILABLE) }, { new Ambulance("222", "Dunfermline", "Queen Margaret", Status.AVAILABLE) }, { new Ambulance("112", "Dunfermline", "Queen Margaret", Status.AVAILABLE) } };
        public static List<AllocatedRequest> allocatedRequests = new List<AllocatedRequest>();       
    }
}
