using KwikMedicalAmbulance.AmbulanceManager.Applications;
using KwikMedicalAmbulance.AmbulanceManager.Database.DataModel;
using KwikMedicalAmbulance.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KwikMedicalAmbulance.Presentation
{
    public static class LoginManager
       
    {
        private static ManageLogin manageLogin = new ManageLogin();
        private static User User = null;
        public static State Login(LoginRequest req)
        {
            try
            {
                MauiProgram.SendUserRequest(req.Username, null);
                //This part of the prototype would need serious reworking for a full implementation
                // so to simplify putting a thread.sleep, rather than lambda
                Thread.Sleep(1000);
                if (!manageLogin.Login(req.Username, req.Password, req.AmbulanceID, User))
                {
                    User = null;
                    return State.NO_USER;
                }
                User = null;
                return State.OK;
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(NoUserFound)) {
                    User = null;
                    return State.NO_USER;
                }
                else
                {
                    User = null;
                    return State.NO_AMBULANCE;
                }
            }
        }

        public static void setUserToReceived(string user)
        {
            User = User.DeserializeUser(user);
        }
    }
}
