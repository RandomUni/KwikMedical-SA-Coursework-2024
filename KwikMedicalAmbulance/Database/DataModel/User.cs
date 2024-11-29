using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KwikMedicalAmbulance.AmbulanceManager.Database.DataModel
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        //A different constructor to add username to app state, without exposing the password
        public User(string username)
        {
            Username = username;
        }

        public static User DeserializeUser(string user)
        {
            if (user != null)
            {
                return JsonSerializer.Deserialize<User>(user) ?? null;
            }
            return null;
        }
    }
}
