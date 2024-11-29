using KwikMedicalAmbulance.AmbulanceManager.Database;
using KwikMedicalAmbulance.Presentation;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KwikMedicalAmbulance
{
    public static class MauiProgram
    {
        private static HubConnection _hubConnection;

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
            _hubConnection = new HubConnectionBuilder().WithUrl($"https://localhost:7059/kwikmedicalhub").Build();
            _hubConnection.StartAsync();
            _hubConnection.On<string>("ReceiveMessage", MessageReceived);
            _hubConnection.On<string>("ReceiveMessageAmbulance", MessageReceived);
            _hubConnection.On<string>("ReceiveUserRequest", ProcessUserRequest);
            _hubConnection.On<string>("ReceiveAmbulances", AddAmbulancesToCache);
            builder.Services.AddScoped<AppState>();
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
                await _hubConnection.SendAsync("SendAmbulanceBooked", request);
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
                sendReport(request, e);
            }
        }

    public static async void SendAmbulanceUnbooked(string request, EventArgs e)
        {
            //Adding some error handling to ensure messages always get sent
            //(the error expected are due to asyncronous server closing)
            try
            {
                await _hubConnection.SendAsync("SendAmbulanceUnbooked", request);
            }
            catch (Exception ex)
            {
                SendAmbulanceUnbooked(request, e);
            }
        }

    public static async void SendUserRequest(string request, EventArgs e)
        {
            //Adding some error handling to ensure messages always get sent
            //(the error expected are due to asyncronous server closing)
            try
            {
                await _hubConnection.SendAsync("SendUserRequest", request);
            }
            catch (Exception ex)
            {
                SendUserRequest(request, e);
            }
        }

        public static void checkForMessages(Action<string, string> receiveAction)
        {
            _hubConnection.On<string, string>("ReceiveMessage", receiveAction);
        }

        private static void MessageReceived(string request)
        {
            ManageIncidentReports.MessageReceived(request);
            Console.WriteLine($"{request} {Environment.NewLine}");
        }

        private static void ProcessUserRequest(string user)
        {
            LoginManager.setUserToReceived(user);
        }

        private static void AddAmbulancesToCache(string ambulances)
        {
            AmbulanceDB.addAmbulancesToCache(ambulances);
        }
    }
}
