using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace ChefManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Wood Dragon.ttf", "WoodDragon");
                fonts.AddFont("Arial.ttf", "Arial");
                fonts.AddFont("Balance.ttf", "Balance");

            });
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}