using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedical.PatientCallCenter.Database.DataModels
{
    //This is a class that would contain all the relevant patient information that would be read from
    // sql database
    public class PatientDetails
    {
        public string PatientName;
        //While address is stored it cannot be assumed incidents happened 
        public string Address;
        public string Condition;

        public PatientDetails(string patientName,string address, string medicalCondition)
        {
            PatientName = patientName;
            Address = address;
            Condition = medicalCondition;
        }

        public PatientDetails(string patientName, string address) 
        { PatientName = patientName;
            Address = address;
        }

        public PatientDetails(string patientName)
        {
            PatientName = patientName;
        }
    }
}
