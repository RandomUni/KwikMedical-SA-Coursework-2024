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
        private static Employee Employee;
        public static Employee Login(LoginRequest req)
        {
            MauiProgram.SendUserRequest(req.Username, null);
            //This part of the prototype would need serious reworking for a full implementation
            // so to simplify putting a thread.sleep, rather than lambda
            Thread.Sleep(800);     
            try
            {
                Employee newEmp = ManageLogin.Login(req.Username, req.Password, Employee);
                Employee = null;
                return newEmp;
            }
            catch (Exception e)
            {                
                return null;
            }
        }

        public static void setUserToReceived(string user)
        {
            Employee = Employee.DeserializeUser(user);
            Console.WriteLine();
        }
    }
}
