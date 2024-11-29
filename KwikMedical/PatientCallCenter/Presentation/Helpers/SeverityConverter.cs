using KwikMedical.PatientCallCenter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedical.PatientCallCenter.Presentation.Helpers
{
    internal class SeverityConverter
    {
        public static Severity ConvertToSevFromInt(int severity)
        {
            switch (severity)
            {
                case 1: return Severity.EXTREME;
                case 2: return Severity.MAJOR;
                case 3: return Severity.MODERATE;
                case 4: return Severity.MINOR;
                default: return Severity.NO_ALLOCATED;
            }
        }
    }
}
