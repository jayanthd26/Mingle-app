using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;

namespace MauiApp1
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
                

            builder.Services.AddSingleton<MongoDbContext>(new MongoDbContext("mongodb://rakshithazrati:w8mSxGhX4sbnOID5@ac-annsyke-shard-00-00.7qncxbg.mongodb.net:27017,ac-annsyke-shard-00-02.7qncxbg.mongodb.net:27017,ac-annsyke-shard-00-00.7qncxbg.mongodb.net:27017/MingleApp?authSource=admin&ssl=true", "MingleApp"));

            builder.Services.AddTransient<LogIn>();
            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<OtpPage>();
            builder.Services.AddTransient<MyDatesPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif



            return builder.Build();
        }
    }
}
