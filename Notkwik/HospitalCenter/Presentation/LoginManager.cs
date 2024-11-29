using KwikMedicalHospital.HospitalCenter.Application;
using KwikMedicalHospital.HospitalCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Presentation
{
    internal class LoginManager
    {
        public static Employee Login(LoginRequest req)
        {
            try
            {
                return ManageLogin.Login(req.Username, req.Password);
            }
            catch (Exception e)
            {                
                return null;
            }
        }
    }
}
