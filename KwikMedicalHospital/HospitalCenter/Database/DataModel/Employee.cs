﻿using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Database.DataModel
{
    public class Employee
    {
        [PrimaryKey]
        public string Username { get; set; }
        //In a non-prototype version this would include aditionnal classes to authenticate users,
        //however it would provide too much
        public string Password { get; set; }

        [ForeignKey("Hospital")]
        public string Hospital { get; set; }

        public Employee() { }

        public Employee(string username, string password, string hospital)
        {
            this.Username = username;
            this.Password = password;
            this.Hospital = hospital;
        }

        public static Employee DeserializeUser(string user)
        {       
                return JsonSerializer.Deserialize<Employee>(user) ?? null;       
        }
    }
}
