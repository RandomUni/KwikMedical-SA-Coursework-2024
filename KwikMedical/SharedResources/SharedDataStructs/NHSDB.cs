using KwikMedical.PatientCallCenter;
using KwikMedical.PatientCallCenter.Database.DataModels;
using KwikMedical.PatientCallCenter.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedical.SharedResources.SharedDataStructs
{
    //A basic struct for demo purposes to query NHS database, to get patient record response
    public class NHSDB
    {

        /// A dictionary to mock response from NHS database, since available API calls and tables are unknown
        private Dictionary<string, PatientDetails> patients = new Dictionary<string, PatientDetails> {
            {"123", new PatientDetails("Sir Conan Doyle","Calendar House")},{"124", new PatientDetails("Julius Caesar","House of Augustus")} };
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
            else return new PatientDetails("John Doe");
        }

        public PatientDetails getDetailsFromNHSNumber(string NHSNumber)
        {
            PatientDetails details = patients[NHSNumber];           
            return details == null? new PatientDetails("") : details;
        }

        public NHSDB() { }
    }
}
