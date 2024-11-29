using KwikMedical.PatientCallCenter.Application;
using KwikMedical.PatientCallCenter.Database;
using KwikMedical.PatientCallCenter.Presentation;
using Microsoft.Extensions.Logging;

namespace KwikMedical
{
    public static class MauiProgram
    {
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


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
