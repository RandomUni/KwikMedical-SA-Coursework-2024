using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulanceGood
{
    public class AmbulanceNotAvailable : ApplicationException
    {
        public AmbulanceNotAvailable()
        {
            Console.WriteLine("Ambulance is not available");
        }
    }

    public class AmbulanceDataError : ApplicationException
    {
        public AmbulanceDataError()
        {
            Console.WriteLine("Ambulance query to the database returned too many or too litle values");
        }
    }

    public class NoUserFound : ApplicationException
    {
        public NoUserFound()
        {
            Console.WriteLine("No User with this username");
        }
    }
}
