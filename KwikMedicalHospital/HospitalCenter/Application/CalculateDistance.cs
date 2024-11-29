using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Application
{
    // just a simple struct that tries to calculate distance geolocation library, or service should be used for full
    public static class CalculateDistance
    {
        public static int GetDistance(string incidentAddress, string objectAddress)
        {
            return Math.Abs(incidentAddress.Length - objectAddress.Length);
        }

    }
}
