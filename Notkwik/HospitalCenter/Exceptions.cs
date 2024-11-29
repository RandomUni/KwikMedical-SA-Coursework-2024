using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter
{
  
        public class NoVariableProvided : ApplicationException
        {
            public NoVariableProvided(string varName)
            {
                Console.WriteLine($"{varName} is not provided");
            }
    }

    public class NoDataFound : ApplicationException
    {
        public NoDataFound(string varName)
        {
            Console.WriteLine($"{varName} could not be found");
        }
    }

    public class NoAmbulance : ApplicationException
    {
        public NoAmbulance()
        {
            Console.WriteLine("Please select Ambulance");
        }
    }

    public class AmbulanceDataError : ApplicationException
    {
        public AmbulanceDataError()
        {
            Console.WriteLine("Ambulance query to the database returned too many or too litle values");
        }
    }

    public class HospitalDataError : ApplicationException
    {
        public HospitalDataError()
        {
            Console.WriteLine("Hospital query to the database returned too many or too litle values");
        }
    }

    public class NoEmployeeFound : ApplicationException
    {
        public NoEmployeeFound()
        {
            Console.WriteLine("No User with this username");
        }
    }
}
