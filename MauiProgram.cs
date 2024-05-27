using CommunityToolkit.Maui;
using GymDay.Services;
using GymDay.ViewModels;
using GymDay.Views;
using Microsoft.Extensions.Logging;

namespace GymDay;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        //Services
        builder.Services.AddSingleton<IDatabaseService, SqLiteService>();

        //Views
        builder.Services.AddTransient<WelcomePage>();
        builder.Services.AddTransient<CurrentWorkoutPage>();
        builder.Services.AddTransient<WorkoutPlansPage>();
        builder.Services.AddTransient<EditRoutinesPage>();

        //ViewModels
        builder.Services.AddTransient<WelcomeViewModel>();
        builder.Services.AddTransient<CurrentWorkoutViewModel>();
        builder.Services.AddTransient<WorkoutPlansViewModel>();
        builder.Services.AddTransient<EditRoutinesViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
