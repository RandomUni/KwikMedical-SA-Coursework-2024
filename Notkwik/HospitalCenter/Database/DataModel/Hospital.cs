using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Database.DataModel
{
    public class Hospital
    {
        [PrimaryKey]
        public string Name { get; set; }
        public string Address { get; set; }

        public int Capacity {  get; set; }

        public Hospital() { }  
        public Hospital(string name, string address, int capacity)
        {
            Name = name;
            Address = address;
            Capacity = capacity;
        }
    }
}
