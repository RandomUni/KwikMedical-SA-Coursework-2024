using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalResponseCenter.PatientCallCenter.Application
{
    //Just a simple basic struct, intended to mimic geolocation
    public static class AddressToCoordinate
    {
        // A struct to mimic geolocation
        public static Coordinate GetCordFromAddress(string Address)
        {
            return new Coordinate(Address.Length, Address.Length);
        }
    }
}
