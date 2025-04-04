using Microsoft.Extensions.Logging;
using SmartHouseApp.ViewModels;

namespace SmartHouseApp
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            // AddSingleton creates a new copy and keep it in memory
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            // AddTransient creates a new copy every time (destroyed when not used)
            builder.Services.AddTransient<ConnectPage>();
            builder.Services.AddTransient<ConnectViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
