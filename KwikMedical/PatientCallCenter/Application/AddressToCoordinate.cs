using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedical.PatientCallCenter.Application
{
    //Just a simple basic struct, intended to mimic geolocation
    public static class AddressToCoordinate
    {
        public static Coordinate GetCordFromAddress(string Address, bool incidentLoc)
        {
            if(incidentLoc)
            {
                return new Coordinate(0, 0);
            }
            return new Coordinate(15, 15);
        }
    }
}
