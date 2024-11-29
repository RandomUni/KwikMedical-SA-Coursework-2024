using KwikMedicalHospital.HospitalCenter.Database;
using KwikMedicalHospital.HospitalCenter.Presentation;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace KwikMedicalHospital
{
    public static class MauiProgram
    {
        private static HubConnection _hubConnection;
        public static List<string> messages = new List<string>();
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<AppState>();

            _hubConnection = new HubConnectionBuilder().WithUrl($"https://localhost:7059/kwikmedicalhub").Build();
            _hubConnection.StartAsync();
            _hubConnection.On<string>("ReceiveMessage", MessageReceived);
            _hubConnection.On<string>("ReceiveAmbulanceBookedId", BookAmbulance);
            _hubConnection.On<string>("SendAmbulanceUnbooked", UnbookAmbulance);
            _hubConnection.On<string>("ReceiveUserRequestHospital", ProcessUserRequest);
           
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"HospitalCenter.db");
            builder.Services.AddSingleton<HospitalCenterDB>(s => ActivatorUtilities.CreateInstance<HospitalCenterDB>(s, dbPath));
            SendAmbulances(HospitalCenterDB.gelAllAvailableAmbulancesToString(), null);

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }


        public static async void send(string request, EventArgs e)
        {
            //Adding some error handling to ensure messages always get sent
            //(the error expected are due to asyncronous server closing)
            try
            {
                await _hubConnection.SendAsync("SendMessageToAmbulance", request);
            }
            catch (Exception ex)
            {
                send(request, e);
            }
        }

        public static async void sendReport(string request, EventArgs e)
        {
            //Adding some error handling to ensure messages always get sent
            //(the error expected are due to asyncronous server closing)
            try
            {
                await _hubConnection.SendAsync("SendFilledReport", request);
            }
            catch (Exception ex)
            {
                send(request, e);
            }
        }

        public static async void SendUserRequest(string request, EventArgs e)
        {
            //Adding some error handling to ensure messages always get sent
            //(the error expected are due to asyncronous server closing)
            try
            {
                await _hubConnection.SendAsync("SendUserRequestHospital", request);
            }
            catch (Exception ex)

            {
                send(request, e);
            }
        }
        
        public static async void SendAmbulances(string request, EventArgs e)
        {
            //Adding some error handling to ensure messages always get sent
            //(the error expected are due to asyncronous server closing)
            try
            {
                await _hubConnection.SendAsync("SendAmbulances", request);
            }
            catch (Exception ex)
            {
                send(request, e);
            }
        }

        public static void checkForMessages(Action<string, string> receiveAction)
        {
            _hubConnection.On<string, string>("ReceiveMessage", receiveAction);
        }

        private static void MessageReceived(string request)
        {
            ManageIncidentResponse.MessageReceived(request);
            Console.WriteLine($"{request} {Environment.NewLine}");
        }

        private static void BookAmbulance(string ambulanceId)
        {
            ManageIncidentResponse.BookAmbulance(ambulanceId);
        }

        private static void UnbookAmbulance(string ambulanceId)
        {
            ManageIncidentResponse.UnbookAmbulance(ambulanceId);
        }

        private static void ProcessUserRequest(string user)
        {
            LoginManager.setUserToReceived(user);
        }


    }
}
