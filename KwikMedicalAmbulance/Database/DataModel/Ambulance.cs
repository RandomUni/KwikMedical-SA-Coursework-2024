using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulance.AmbulanceManager.Database.DataModel
{
    public class Ambulance
    {
        public string Id { get; set; }
        public string Location { get; set; }

        public string HospitalId { get; set; }

        public Status Status { get; set; }

        public Ambulance(string id, string location, string hospitalId, Status status)
        {
            Id = id;
            Location = location;
            HospitalId = hospitalId;
            Status = status;
        }
    }
}
