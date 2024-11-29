using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedical.PatientCallCenter.Presentation.Helpers
{
    internal class ExceptionHandler
    {

        public static FormState handleExceptionState(Exception e)
        {
            if (e.GetType() == typeof(NameNHSNumberMismatch))
            {
                return FormState.NAME_MISSMATCH;
            }
            if (e.GetType() == typeof(NoSeverityAllocated))
            {
                return FormState.NO_SEVERITY_ALLOCATED;
            }
            return FormState.UNKNOWN_EXCEPTION;
        }
    }


       
    }

