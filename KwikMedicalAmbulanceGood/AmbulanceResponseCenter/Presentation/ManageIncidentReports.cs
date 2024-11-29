using KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Application;
using KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Presentation
{
    public static class ManageIncidentReports
    {
        private static RequestManager requestManager = new RequestManager();

        public static SubmittedRequests getRequestForAmbulance(string amubulance)
        {
            return requestManager.GetForThisAmbulance(amubulance);
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
    }
}
