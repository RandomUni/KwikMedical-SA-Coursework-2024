using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulance.Presentation
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Please provide username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please provide password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please provide Ambulance Id")]
        public string AmbulanceID { get; set; }

        public LoginRequest() { }
    }
}
