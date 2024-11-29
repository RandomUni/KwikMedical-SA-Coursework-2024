using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedical.PatientCallCenter.Enums
{
    // Severity measures used described here https://en.wikipedia.org/wiki/Severity_of_illness
    public enum Severity
    {
        MINOR,
        MODERATE,
        MAJOR,
        EXTREME,
        NO_ALLOCATED
    }
}
