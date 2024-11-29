using KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Database
{
    internal static class MockData
    {
        public static List<string> requests = new List<string> { { "{\"Severity\":1,\"SeverityInt\":1,\"Message\":\"Fractured Leg\",\"Condition\":\"Fracture\",\"Address\":\"Grove\",\"NHSNumber\":\"123\",\"Pressumed stroke\":\"\"}" }, "{\"Severity\":1,\"SeverityInt\":1,\"Message\":\"Fractured Leg\",\"Condition\":\"Stroke\",\"Address\":\"Elm Grove 11,\",\"NHSNumber\":\"123\",\"PatientName\":\"\"}" };
        public static List<AmbulanceEmployee> users = new List<AmbulanceEmployee> { { new AmbulanceEmployee("Ben", "123") }, { new AmbulanceEmployee("Carol", "123") } };
        public static List<Ambulance> ambulances = new List<Ambulance> { { new Ambulance("111", "Cowdenbeath", "Queen Margaret", Status.AVAILABLE) }, { new Ambulance("222", "Dunfermline", "Queen Margaret", Status.AVAILABLE) } };
    }
}
