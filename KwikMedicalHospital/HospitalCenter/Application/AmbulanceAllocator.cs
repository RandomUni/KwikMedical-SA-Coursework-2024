using KwikMedicalHospital.HospitalCenter.Database;
using KwikMedicalHospital.HospitalCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Application
{
    internal class AmbulanceAllocator
    {
        private List<Ambulance> potentialAmbulances = new List<Ambulance>();
      public Ambulance allocateCloset(string address, List<Ambulance> ambulances)
        {
            //these errors will be throw, however if a null value passes trough presentation layer it is a serious bug
            // and therefore the system should crash, since it is incapable to fullfill its task
            if (address == "")
            {
                throw new NoVariableProvided("address");
            }
            //these errors will be throw, however if a null value passes trough presentation layer it is a serious bug
            // and therefore the system should crash, since it is incapable to fullfill its task
            if (ambulances == null || ambulances.Count == 0)
            {
                throw new NoDataFound("ambulances");
            }
            Ambulance shortestPath = null;
            int shortest = int.MaxValue;
            foreach (Ambulance ambulance in ambulances)
            { 
                    int newshortest = CalculateDistance.GetDistance(address, ambulance.Location);
                    if (shortestPath == null)
                    {
                        shortestPath = ambulance;
                        shortest = newshortest;
                    }
                    else if (shortest > newshortest)
                    {
                        shortestPath = ambulance;
                        shortest = newshortest;
                    }                
            }
            ambulances.Remove(shortestPath);
            potentialAmbulances = ambulances;
            this.SetStatus(shortestPath, Status.ON_MISSION);
            return shortestPath;
        }

        // Method to change status of ambulances, to free them or put to repair, for example
        public Ambulance SetStatus(Ambulance ambulance, Status status)
        {
            //these errors will be throw, however if a null value passes trough presentation layer it is a serious bug
            // and therefore the system should crash, since it is incapable to fullfill its task
            if (ambulance == null)
            {
                throw new NoVariableProvided("ambulance");
            }
            ambulance.Status = Status.AVAILABLE;
            HospitalCenterDB.changeAmbulanceStatus(ambulance.Id, status);
            return ambulance;
        }    }
}
