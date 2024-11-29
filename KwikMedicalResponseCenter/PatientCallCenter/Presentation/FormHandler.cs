using KwikMedicalResponseCenter.PatientCallCenter.Application;
using KwikMedicalResponseCenter.PatientCallCenter.Database.DataModels;
using KwikMedicalResponseCenter.PatientCallCenter.Presentation.Helpers;
using KwikMedicalResponseCenter.SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalResponseCenter.PatientCallCenter.Presentation
{
    internal static class FormHandler
    {
        public static FormState SubmitForm(Req req) {
            try
            {
                FormHandler.addPatientDetailsToReq(req);
                req.TimeReceived = DateTime.Now;
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

        private static void addPatientDetailsToReq(Req req)
        {
            PatientDetails details = NHSDatabaseConnector.database.getDetailsFromNHSNumber(req.NHSNumber);
            if (details == null)
            {
                req.NHSNumber = "";
            }
            else if (details.PatientName != req.PatientName && req.PatientName != "") 
            {
                throw new NameNHSNumberMismatch();
               
            }
            else
            {
                req.PatientName = details.PatientName;
                req.PreviousConditions = details.Condition;
            }
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
