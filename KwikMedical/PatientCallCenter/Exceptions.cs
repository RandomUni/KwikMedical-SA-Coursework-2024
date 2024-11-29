using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedical.PatientCallCenter
{
    public class NameNHSNumberMismatch : ApplicationException
    {
        public NameNHSNumberMismatch()
        {
            Console.WriteLine("NHS number provided and name on database does not match");
        }
    }

    public class NoSeverityAllocated : ApplicationException
    {
        public NoSeverityAllocated()
        {
            Console.WriteLine("The system could not allocate severity, use manual input");
        }
    }
}
