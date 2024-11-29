using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedical.PatientCallCenter.Presentation
{
    public class PatientRecords
    {
        public string NHSNumber { get; set; }
        public string PatientName { get; set; }

        public PatientRecords()
        {

        }

        public PatientRecords(string NHSNumber, string PatientName)
        {
            this.NHSNumber = NHSNumber;
            this.PatientName = PatientName;
        }
    }
}
