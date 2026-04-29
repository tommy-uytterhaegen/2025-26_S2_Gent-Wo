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

            builder.Services.AddTransient<JokeService>();
            
            //builder.Services.AddSingleton<IJokeRespository, JokeRepository>();
            builder.Services.AddSingleton<IJokeRespository, DadJokeRepository>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
