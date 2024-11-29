using KwikMedicalAmbulance.AmbulanceManager.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KwikMedicalAmbulance.AmbulanceManager.Database
{
    public static class AmbulanceDB
    {

        public static Ambulance getAmbulanceById(string id)
        {
            List<Ambulance> ambulances = MockData.ambulances.Where(ambulance => ambulance.Id == id).ToList();

            if (ambulances.Count != 1)
            {
                throw new AmbulanceDataError();
            }
            return ambulances[0];
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

        public static List<Ambulance> getAllAmbulances()
        {
            return MockData.ambulances;
        }

        public static void addAmbulancesToCache(string ambulances)
        {
            if (ambulances != null)
            {
                MockData.ambulances = JsonSerializer.Deserialize<List<Ambulance>>(ambulances);
            }
        }
    }
}
