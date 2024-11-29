using KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Presentation
{
   public class AppState1
    {
        public AmbulanceEmployee User { get; set; }
        public string Ambulance { get; set; }

        public SubmittedRequests Request { get; set; }
    }
}
