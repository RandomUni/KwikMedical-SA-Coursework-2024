using KwikMedicalResponseCenter.PatientCallCenter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalResponseCenter.PatientCallCenter.Constants
{
    internal class MedicalConditionLibrary
    {
        // A dictionary with some conditions with associated severity,
        // should be filled with more for complete application
        public static readonly Dictionary<string, Severity> MedicalConditionsWithSev = new Dictionary<string, Severity>
        {{ "stroke", Severity.MAJOR },
            {"cardiac arrest", Severity.EXTREME },
            {"fracture", Severity.MODERATE },
            {"anaphylactic shock", Severity.MAJOR },
            {"sprained ankle", Severity.MODERATE },
            {"bruised knee", Severity.MINOR }
        };
    }
}
