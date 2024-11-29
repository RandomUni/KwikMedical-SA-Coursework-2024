using KwikMedicalAmbulance.AmbulanceManager.Database;
using KwikMedicalAmbulance.AmbulanceManager.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulance.AmbulanceManager.Applications
{
    public class ManageLogin
    {      
        //There should be more logic here in the real app to do with hashing the password, for example
        public bool Login(string username, string password, string ambulance, User userIndb)
        {           
            if(userIndb == null)
            {
                return false;
            }
            Ambulance ambulanceInDB = AmbulanceDB.getAmbulanceById(ambulance);        
            return hash(password, userIndb.Password);
        }

        /// A hashing function, in a real project would compare hashes from password and
        /// password in db, however that would be a lot of extra code and thus not supported
        private  bool hash(string password, string passwordInDB)
        {
            return password.Equals(passwordInDB);
        }

    }
}
