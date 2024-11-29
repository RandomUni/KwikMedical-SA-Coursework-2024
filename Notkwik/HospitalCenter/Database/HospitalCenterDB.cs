
using KwikMedicalHospital.HospitalCenter.Database.DataModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalHospital.HospitalCenter.Database
{
    public class HospitalCenterDB
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        private SQLiteAsyncConnection conn;

        public static void adjustHospitalCapacity(string hospitalName)
        {
            List<Hospital> hospitals = MockData.hospitals.Where(hospital => hospital.Name == hospitalName).ToList();

            if(hospitals.Count !=1)
            {
                throw new HospitalDataError();
            }
            hospitals[0].Capacity--;
        }

        public static void changeAmbulanceStatus(string ambulanceId, Status Status)
        {
           List<Ambulance> ambulances = MockData.ambulances.Where(ambulance => ambulance.Id == ambulanceId).ToList();
            if (ambulances.Count != 1)
            {
                throw new AmbulanceDataError();
            }
            ambulances[0].Status = Status;
        }

        public static List<AllocatedRequest> getAllRequestsForHospital(string hospital)
        {
            return MockData.allocatedRequests.Where(request => request.HospitalAllocated == hospital).ToList();
        }

        public static void addAllocatedRequest(AllocatedRequest allocatedRequest, string req)
        {
            MockData.allocatedRequests.Add(allocatedRequest);
           // Logic to remove here as well
        }

        public static List<Hospital> GetHospitals()
        {
            return MockData.hospitals;
        }

        public static List<Ambulance> gelAllAvailableAmbulances()
        {
            return MockData.ambulances.Where(ambulance => ambulance.Status == Status.AVAILABLE).ToList();
            
        }

        public static Employee getEmployeeByUsername(string username)
        {
            List<Employee> employees = MockData.employees.Where(employee => employee.Username == username).ToList();
            if (employees.Count != 1) {
                throw new NoEmployeeFound();
            }
            return employees[0];
        }

        public HospitalCenterDB(string dbPath)

        {
            _dbPath = dbPath;
         /*   this.AddMockData();*/
        }

        private async Task InitAsync()

        {

            // Don't Create database if it exists

            if (conn != null)

                return;

            // Create database and Tables

            conn = new SQLiteAsyncConnection(_dbPath);

            await conn.CreateTableAsync<Employee>();
            await conn.CreateTableAsync<Hospital>();

        }

        public async Task<List<Employee>> GetEmployeesAsync()

        {

            await InitAsync();

            return await conn.Table<Employee>().ToListAsync();

        }

        public async Task<Employee> GetEmployeeByUsername(string username)
        {
            await InitAsync();
            return await conn.Table<Employee>().Where(i => i.Username == username).FirstOrDefaultAsync();
            
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            await conn.InsertAsync(employee);
            return employee;
        }

        private async void AddMockData()
        {
            await InitAsync();
            await this.AddHospitals();
            await this.AddEmployees();
        }

        private async Task<int> AddHospitals()
        {
            return await conn.InsertAllAsync(MockData.hospitals);
        }

        private async Task<int> AddEmployees()
        {
            return await conn.InsertAllAsync(MockData.employees);
        }



        //public async Task<WeatherForecast> UpdateForecastAsync(

        //    WeatherForecast paramWeatherForecast)

        //{

        //    // Update

        //    await conn.UpdateAsync(paramWeatherForecast);

        //    // Return the updated object

        //    return paramWeatherForecast;

    }

        //public async Task<WeatherForecast> DeleteForecastAsync(

        //    WeatherForecast paramWeatherForecast)

        //{

        //    // Delete

        //    await conn.DeleteAsync(paramWeatherForecast);

        //    return paramWeatherForecast;

        //}

    }


