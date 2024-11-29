using KwikMedicalHospital.HospitalCenter.Application;
using KwikMedicalHospital.HospitalCenter.Database;
using KwikMedicalHospital.HospitalCenter.Database.DataModel;
using System.Runtime.CompilerServices;

namespace KwikMedicalHospital.HospitalCenter.Presentation
{
    public static class ManageIncidentResponse
    {
        private static RequestManager requestManager = new RequestManager(new AssignToHospital(), new AmbulanceAllocator());
       public static List<AllocatedRequest> getAllRequests(string hospital)
        {
            //Dummy method to allocate mock requests

          /*  foreach (string req in MockData.requests)
            {
                requestManager.HandleRequest(req);
            }*/
            return requestManager.getRequestsForHospital(hospital);
        }

        public static List<Ambulance> getAmbulances()
        {
            return requestManager.GetAvailableAmbulances();
        }

        public static void AllocateAmbulace(AllocatedRequest req, Ambulance ambulance)
        {
            requestManager.AllocateAmbulance(req, ambulance);
        }

        public static void RemoveRequest(AllocatedRequest req)
        {
            requestManager.removeRequest(req);
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

        public static void BookAmbulance(string ambulanceId)
        {
            requestManager.BookAmbulance(ambulanceId);
        }

        public static void UnbookAmbulance(string ambulanceId)
        {
            requestManager.UnbookAmbulance(ambulanceId); 
        }

        public static TimeSpan CalculateTime(DateTime timeReceived)
        {
            return DateTime.Now - timeReceived;
        }




    }
}
