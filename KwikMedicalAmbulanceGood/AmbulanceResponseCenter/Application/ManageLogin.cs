using KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Database;
using KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Application
{
    public class ManageLogin
    {
        //There should be more logic here in the real app to do with hashing the password, for example
        public static bool Login(string username, string password, string ambulance)
        {
            AmbulanceEmployee user = AmbulanceDB.getUser(username);
            Ambulance ambulanceInDB = AmbulanceDB.getAmbulanceById(ambulance);
            return hash(user.Password, password);
        }


        /// A hashing function, in a real project would compare hashes from password and
        /// password in db, however that would be a lot of extra code and thus not supported
        private static bool hash(string passwordInDb, string password)
        {
            return passwordInDb.Equals(password);
        }
    }
}
