using KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Database
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

            if (ambulances[0].Status != Status.AVAILABLE)
            {
                throw new AmbulanceNotAvailable();
            }
            return ambulances[0];
        }

        public static AmbulanceEmployee getUser(string username)
        {
            List<AmbulanceEmployee> users = MockData.users.Where(user => user.Username == username).ToList();

            if (users.Count != 1)
            {
                throw new AmbulanceDataError();
            }
            return users[0];
        }
    }
}
