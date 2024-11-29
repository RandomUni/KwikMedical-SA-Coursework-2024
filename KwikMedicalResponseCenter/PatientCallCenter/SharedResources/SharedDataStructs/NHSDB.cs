using KwikMedicalResponseCenter.PatientCallCenter;
using KwikMedicalResponseCenter.PatientCallCenter.Database.DataModels;
using KwikMedicalResponseCenter.PatientCallCenter.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalResponseCenter.SharedResources.SharedDataStructs
{
    //A basic struct for demo purposes to query NHS database, to get patient record response
    public class NHSDB
    {

        /// A dictionary to mock response from NHS database, since available API calls and tables are unknown
        private Dictionary<string, PatientDetails> patients = new Dictionary<string, PatientDetails> {
            {"123", new PatientDetails("Sir Conan Doyle","Calendar House")},{"124", new PatientDetails("Julius Caesar","House of Augustus")}, {"125", new PatientDetails("Winston Churchill", "10 Downing St", "Stroke") } };
        public PatientDetails QueryPatientRecord(string NHSNumber, string patientName = "")
        {
            if (patients.ContainsKey(NHSNumber))
            {
                if (patientName != "" && patients[NHSNumber].PatientName != patientName)
                {
                    throw new NameNHSNumberMismatch();
                }
                return patients[NHSNumber];
            }
            else return null;
        }

        public PatientDetails getDetailsFromNHSNumber(string NHSNumber)
        {
            if (patients.ContainsKey(NHSNumber)) {
                PatientDetails details = patients[NHSNumber];
                return details == null ? new PatientDetails("") : details;
            }
            return null;
        }

        public NHSDB() { }
    }
}
