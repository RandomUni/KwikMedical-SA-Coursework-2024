using KwikMedicalHospital.HospitalCenter.Database;
using KwikMedicalHospital.HospitalCenter.Database.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Application
{
    public class AssignToHospital
    {
        private List<Hospital> hospitals = HospitalCenterDB.GetHospitals();
        public string AssignHospital(RequestReceived req)
        {
            //these errors will be throw, however if a null value passes trough presentation layer it is a serious bug
            // and therefore the system should crash, since it is incapable to fullfill its task
            if(req == null)
            {
                throw new NoVariableProvided("request");
            }
            string closest;
            if (req.Severity == 0)
            {
                closest = closestHospitalWithCapacity(req.Address, true);
            }
            else
            {
                closest = closestHospitalWithCapacity(req.Address);
            }
            HospitalCenterDB.adjustHospitalCapacity(closest);
            return closest;
            //Could have more  logic here to allocate based on facilities, for example
        }

   
        private string closestHospitalWithCapacity(string address, bool urgent = false)
        {
            //these errors will be throw, however if a null value passes trough presentation layer it is a serious bug
            // and therefore the system should crash, since it is incapable to fullfill its task
            if (address == null)
            {
                throw new NoVariableProvided("address");
            }
            //these errors will be throw, however if a null value passes trough presentation layer it is a serious bug
            // and therefore the system should crash, since it is incapable to fullfill its task
            if (hospitals == null || hospitals.Count == 0)
            {
                throw new NoDataFound("hospitals");
            }
            Hospital shortestPath = null;
            int shortest = int.MaxValue;
            foreach (Hospital hospital in hospitals)
            {
                if(!urgent && hospital.Capacity < 1)
                {
                    hospitals.Remove(hospital);
                }
                else
                {
                    int newshortest = CalculateDistance.GetDistance(address, hospital.Address);
                    if (shortestPath == null)
                    {
                        shortestPath = hospital;
                        shortest = newshortest;
                    }
                    else if (shortest > newshortest)
                    {
                        shortestPath = hospital;
                        shortest = newshortest;
                    }
                }
            }
            return shortestPath.Name;
        }
    }
}
