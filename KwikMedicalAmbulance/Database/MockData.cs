using KwikMedicalAmbulance.AmbulanceManager.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KwikMedicalAmbulance.AmbulanceManager.Database
{
    internal static class MockData
    {
        public static List<string> requests = new List<string> { { "{\"Severity\":1,\"SeverityInt\":1,\"Message\":\"Fractured Leg\",\"Condition\":\"Fracture\",\"Address\":\"Grove\",\"NHSNumber\":\"123\",\"Pressumed stroke\":\"\"}" }, "{\"Severity\":1,\"SeverityInt\":1,\"Message\":\"Fractured Leg\",\"Condition\":\"Stroke\",\"Address\":\"Elm Grove 11,\",\"NHSNumber\":\"123\",\"PatientName\":\"\"}" };
        public static List<Ambulance> ambulances = new List<Ambulance>();
    }
}
