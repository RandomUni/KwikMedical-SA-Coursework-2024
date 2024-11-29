using KwikMedicalHospital.HospitalCenter.Application;
using KwikMedicalHospital.HospitalCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Presentation
{
    internal class AppState
    {
        public string? Hospital {get; set;}
        public Employee? Employee { get; set; }
        public AllocatedRequest? Request { get; set; }

        public List<AllocatedRequest>? Requests { get; set; } = new List<AllocatedRequest>();
    }
}
