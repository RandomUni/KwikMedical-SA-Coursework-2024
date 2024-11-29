using KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Presentation
{
    public static class LoginManager
    {
        public static ResponseState Login(LoginRequest2 req)
        {
            try
            {
                if (!ManageLogin.Login(req.Username, req.Password, req.Ambulance))
                {
                    return ResponseState.NO_USER;
                }
                return ResponseState.OK;
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(NoUserFound))
                {
                    return ResponseState.NO_USER;
                }
                else
                {
                    return ResponseState.NO_AMBULANCE;
                }
            }
        }
    }
}
