using KwikMedicalServer.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
namespace KwikMedicalServer.Hubs
{
    public class KwikMedicalHub:Hub
    {
        public static KwikUserContext UserContext { get; set; }
        public static MedicalRequestResponseContext RequestContext { get; set; }
        public async Task SendMessage(string request)
        {
            await Clients.All.SendAsync("ReceiveMessage", request);
        }

        public async Task SendMessageToAmbulance(string request)
        {
            await Clients.All.SendAsync("ReceiveMessageAmbulance", request);
        }

        public async Task SendFilledReport(string request)
        {
            SqliteConnection.ClearAllPools();
            MedicalRequestResponse response = JsonSerializer.Deserialize<MedicalRequestResponse>(request);
            if (response != null)
            {
                RequestContext.Add(response);
                RequestContext.SaveChanges();
            }
        }

        public async Task SendAmbulances(string ambulances)
        {
            await Clients.All.SendAsync("ReceiveAmbulances", ambulances);
        }

        public async Task SendAmbulanceBooked(string ambulanceId)
        {
            await Clients.All.SendAsync("ReceiveAmbulanceBookedId", ambulanceId);
        }

        public async Task SendAmbulanceUnbooked(string ambulanceId)
        {
            await Clients.All.SendAsync("SendAmbulanceUnbooked", ambulanceId);
        }

        public async Task BookAmbulance(string ambulanceId)
        {
            await Clients.All.SendAsync("SendAmbulanceBookedId", ambulanceId);
        }

        public async Task SendUserRequest(string username)
        {
            List<KwikUser> users = UserContext.Users.Where(a => a.Username == username).ToList();

            await Clients.All.SendAsync("ReceiveUserRequest", users[0].ToJSON());
        }

        public async Task SendUserRequestHospital(string username)
        {
            List<KwikUser> users = UserContext.Users.Where(a => a.Username == username).ToList();

            await Clients.All.SendAsync("ReceiveUserRequestHospital", users[0].ToJSON());
        }
    }
}
