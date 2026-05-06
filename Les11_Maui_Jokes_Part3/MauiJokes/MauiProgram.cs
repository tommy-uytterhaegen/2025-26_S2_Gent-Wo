using MauiJokes.ViewModels;
using MauiJokesBL.Interfaces;
using MauiJokesBL.Services;
using MauiJokesDL;
using Microsoft.Extensions.Logging;

namespace MauiJokes
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

            // Services
            builder.Services.AddTransient<JokeService>();
            builder.Services.AddSingleton<DatabaseConnection>(); // De connection leggen willen we maar 1x
            builder.Services.AddTransient<IJokeRespository, LiteDBJokeRepository>();

            // ViewModels
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<JokeListViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
