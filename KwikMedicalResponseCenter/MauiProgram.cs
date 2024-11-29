using KwikMedicalResponseCenter.PatientCallCenter.Application;
using KwikMedicalResponseCenter.PatientCallCenter.Database;
using KwikMedicalResponseCenter.PatientCallCenter.Presentation;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR.Client;

namespace KwikMedicalResponseCenter
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
            //DB PatientCallCenter = new DB(); 
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<AppState>();

            _hubConnection = new HubConnectionBuilder().WithUrl($"https://localhost:7059/kwikmedicalhub").Build();
            _hubConnection.StartAsync();
            

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
          
            return builder.Build();
        }

        public static async void send(string request, EventArgs e)
        {
            await _hubConnection.SendAsync("SendMessage", request);

        }


        private static void MessageReceived(string request, string status)
        {
            Console.WriteLine ($"{request} with {status}{Environment.NewLine}");
        }
    }


}
