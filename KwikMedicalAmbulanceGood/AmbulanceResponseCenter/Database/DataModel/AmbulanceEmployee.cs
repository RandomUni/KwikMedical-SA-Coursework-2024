using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Database.DataModel
{
    public class AmbulanceEmployee
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AmbulanceEmployee() { }

        public AmbulanceEmployee(string username, string password)
        {
            Username = username;
            Password = password;
        }

        //A different constructor to add username to app state, without exposing the password
        public AmbulanceEmployee(string username)
        {
            Username = username;
        }
    }
}
