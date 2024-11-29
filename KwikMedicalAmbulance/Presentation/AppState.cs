using KwikMedicalAmbulance.AmbulanceManager.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulance.Presentation
{
    public class AppState
    {
        public User User { get; set; }
        public string AmbulanceID {  get; set; }

        public SubmittableRequest Request { get; set; }
    }
}
