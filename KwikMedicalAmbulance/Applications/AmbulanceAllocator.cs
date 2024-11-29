using KwikMedicalAmbulance.AmbulanceManager.Database;
using KwikMedicalAmbulance.AmbulanceManager.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalAmbulance.AmbulanceManager.Applications
{
    public class AmbulanceAllocator
    {
        public Ambulance allocateCloset(string address, List<Ambulance> ambulances)
        {
            //these errors will be throw, however if a null value passes trough presentation layer it is a serious bug
            // and therefore the system should crash, since it is incapable to fullfill its task
            if (address == "")
            {
                throw new NullReferenceException();
            }
            //these errors will be throw, however if a null value passes trough presentation layer it is a serious bug
            // and therefore the system should crash, since it is incapable to fullfill its task
            if (ambulances == null || ambulances.Count == 0)
            {
                throw new AmbulanceDataError();
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
            SetStatus(shortestPath, Status.ON_MISSION);
            return shortestPath;
        }

        // Method to change status of ambulances, to free them or put to repair, for example
        public Ambulance SetStatus(Ambulance ambulance, Status status)
        {
            //these errors will be throw, however if a null value passes trough presentation layer it is a serious bug
            // and therefore the system should crash, since it is incapable to fullfill its task
            if (ambulance == null)
            {
                throw new NullReferenceException();
            }
            ambulance.Status = Status.AVAILABLE;
            AmbulanceDB.changeAmbulanceStatus(ambulance.Id, status);
            return ambulance;
        }
    }
}

