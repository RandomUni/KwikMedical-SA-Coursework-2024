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


            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"HospitalCenter.db");
            builder.Services.AddSingleton<HospitalCenterDB>(s => ActivatorUtilities.CreateInstance<HospitalCenterDB>(s, dbPath));

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }


        public static async void send(string request, EventArgs e)
        {
            await _hubConnection.SendAsync("SendMessage", request, "SUCCESS");
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
    }
}
