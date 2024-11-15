using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace MauiSample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCompatibility()
            .ConfigureEffects(effects =>
            {
#if ANDROID
                effects.Add<CobrowseRedactedViewEffect, MauiSample.Platforms.Android.PlatformCobrowseRedactedViewEffect>();
#elif IOS
                effects.Add<CobrowseRedactedViewEffect, MauiSample.Platforms.iOS.PlatformCobrowseRedactedViewEffect>();
#endif
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

