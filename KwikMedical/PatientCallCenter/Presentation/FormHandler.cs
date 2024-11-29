using KwikMedical.PatientCallCenter.Application;
using KwikMedical.PatientCallCenter.Database.DataModels;
using KwikMedical.PatientCallCenter.Presentation.Helpers;
using KwikMedical.SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedical.PatientCallCenter.Presentation
{
    internal static class FormHandler
    {
        public static FormState SubmitForm(Req req) {
            try
            {            
                RequestResolver resolver = new RequestResolver(req, new SeverityAllocator(req.Message,
                    req.Condition), NHSDatabaseConnector.database);
                resolver.HandleRequest();
            }

            catch (Exception e)
            {
             return ExceptionHandler.handleExceptionState(e);
            }
            return FormState.SUCCESS;
        }

        public static PatientRecords getPatientNameByNHSDetails(string NHSNumber)
        {
            PatientDetails details = NHSDatabaseConnector.database.getDetailsFromNHSNumber(NHSNumber);
            return new PatientRecords(NHSNumber, details.PatientName);
        }

        public static void ResetNameAndNHSNumber(Req req)
        {
            req.PatientName = "";
            req.NHSNumber = "";
        }

        public static void MatchNameToNHSNumber(Req req, string patientName)
        {
            req.PatientName = patientName;
        }

    }
}
