using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulance.AmbulanceManager.Applications
{
    public static class CalculateDistance
    {
        //Geolocation Library should be used for this
        public static int GetDistance(string incidentAddress, string objectAddress)
        {
            return Math.Abs(incidentAddress.Length - objectAddress.Length);
        }
    }
}
