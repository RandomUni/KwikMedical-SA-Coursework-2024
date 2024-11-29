﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Presentation
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Please provide username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please provide password")]
        public string Password { get; set; }
        

        public LoginRequest() { }
    }
}
