using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalResponseCenter
{
    public class Coordinate
    {
        public double Longiture;
        public double Latitutude;

        public Coordinate(double lat, double lon) {
            this.Latitutude = lat;
            this.Longiture = lon;
        }
        // A simple method for distance calculation for demo purposes, for a full scale application something 
        // like google maps API is recommended to use
        public double getDistanceTo(double lat, double lon)
        {
            return Math.Abs(this.Latitutude = lat) + Math.Abs(this.Longiture - lon);
        }
    }
}
