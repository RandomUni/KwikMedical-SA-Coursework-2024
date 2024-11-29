using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulanceGood.AmbulanceResponseCenter.Presentation
{
    public class LoginRequest2
    {
        [Required(ErrorMessage = "Please provide username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please provide password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please provide Ambulance Id")]
        public string Ambulance { get; set; }

        public LoginRequest2() { }
    }
}
