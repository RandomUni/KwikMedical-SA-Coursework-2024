using KwikMedicalHospital.HospitalCenter.Database;
using KwikMedicalHospital.HospitalCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Application
{
    public static class ManageLogin
    {

        //There should be more logic here in the real app to do with hashing the password, for example
        public static Employee Login(string username, string password, Employee emp)
        {         
            if(emp != null && hash(emp.Password, password))
            {
                return emp;
            }
            return null;
        }


        /// A hashing function, in a real project would compare hashes from password and
        /// password in db, however that would be a lot of extra code and thus not supported
        private static bool hash(string passwordInDb, string password)
        {
            return passwordInDb.Equals(password);
        }
        //There should be more logic here in the real app to do with hashing the password, for example
    }
}
