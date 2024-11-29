using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedical.PatientCallCenter.Constants
{
    // This could be integrated with ChatGPT or similar to decide on severity
    // That approach would provide more accurate estimated, however some of the real-time aspect would 
    // have to be sacrificed and this approach should be discussed with sta
    internal class SeverityKeywords
    {
        public readonly static string[] Extreme = ["cardiac arrest", "excessive bleeding", "life threatening", "life-threatening", "respiratory arrest"];
        public readonly static string[] Major = ["stroke", "open fracture "];
        public readonly static string[] Moderate = ["bleeding profusely", "abdominal pain"];
        public readonly static string[] Minor = ["cut", "minor pain", "bleeding"];
    }
}
