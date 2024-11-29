

using KwikMedicalAmbulance.AmbulanceManager.Applications;
using KwikMedicalAmbulance.AmbulanceManager.Database.DataModel;
using System;

namespace KwikMedicalAmbulance.Presentation
{
    public static class ManageIncidentReports
    {
        private static RequestManager requestManager = new RequestManager(new AmbulanceAllocator());
       
        public static SubmittableRequest getRequestForAmbulance(string amubulance)
        {
            return requestManager.GetForThisAmbulance(amubulance);
        }

        public static State ReportSubmitted(SubmittableRequest req)
        {
            req.TimeSpent = ManageIncidentReports.CalculateTime(req);
            if (!requestManager.SubmitReport(req))
            {
                return State.NO_REQUEST;
            }
            return State.OK;
        }

        public static void MessageReceived(string request)
        {
            string message = request;
            try
            {
                requestManager.HandleRequest(message);
            }
            //Adding some error handling to handle cases where message is empty but not crash the entire application,
            // simply ignore and continue running but log for code quality improvement reasons
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine($"{request} {Environment.NewLine}");
        }

       public static TimeSpan  CalculateTime(SubmittableRequest req)
        {
            return DateTime.Now - req.TimeReceived;
        }




    }
}
