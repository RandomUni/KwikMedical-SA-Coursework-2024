
using KwikMedicalHospital.HospitalCenter.Database.DataModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Database
{
    public class HospitalCenterDB
    {
        // A method to reduce hospital's capacity, a full system would handle treatment as well likely 
        // therefore nowehere in the demo system capacity gets readjusted
        public static void adjustHospitalCapacity(string hospitalName)
        {
            List<Hospital> hospitals = MockData.hospitals.Where(hospital => hospital.Name == hospitalName).ToList();

            if (hospitals.Count != 1)
            {
                throw new HospitalDataError();
            }
            hospitals[0].Capacity--;
        }

        public static void changeAmbulanceStatus(string ambulanceId, Status Status)
        {
            List<Ambulance> ambulances = MockData.ambulances.Where(ambulance => ambulance.Id == ambulanceId).ToList();
            if (ambulances.Count != 1)
            {
                throw new AmbulanceDataError();
            }
            ambulances[0].Status = Status;
        }

        public static List<AllocatedRequest> getAllRequestsForHospital(string hospital)
        {
            return MockData.allocatedRequests.Where(request => request.HospitalAllocated == hospital).ToList();
        }

        public static void removeRequest(AllocatedRequest req)
        {
            MockData.allocatedRequests.Remove(req);
        }

        public static void addAllocatedRequest(AllocatedRequest allocatedRequest, string req)
        {
            MockData.allocatedRequests.Add(allocatedRequest);         
        }

        public static List<Hospital> GetHospitals()
        {
            return MockData.hospitals;
        }

        public static List<Ambulance> gelAllAvailableAmbulances()
        {
            return MockData.ambulances.Where(ambulance => ambulance.Status == Status.AVAILABLE).ToList();

        }

        public static string gelAllAvailableAmbulancesToString()
        {
            List<Ambulance> ambulances = MockData.ambulances.Where(ambulance => ambulance.Status == Status.AVAILABLE).ToList();
            return JsonSerializer.Serialize(ambulances);

        }

        public static void addAmbulance(Ambulance am)
        {
            MockData.ambulances.Add(am);;
        }
    }
}


