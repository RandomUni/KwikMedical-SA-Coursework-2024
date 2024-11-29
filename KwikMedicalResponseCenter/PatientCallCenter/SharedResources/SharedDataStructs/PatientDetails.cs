using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalResponseCenter.PatientCallCenter.Database.DataModels
{
    //This is a class that would contain all the relevant patient information that would be read from
    // sql database
    public class PatientDetails
    {
        public string PatientName;
        // This is their home address, not neccesirily where incident happened
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
