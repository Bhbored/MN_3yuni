using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MN_3yuni_MAUI.MVVM.ViewModels;
using MN_3yuni_MAUI.MVVM.Views;
using MN_3yuni_MAUI.DIExtension;

namespace MN_3yuni_MAUI
{
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
                    fonts.AddFont("Poppins-Bold.ttf", "poppinbold");
                    fonts.AddFont("Poppins-Regular.ttf", "poppin");
                    fonts.AddFont("MauiMaterialAssets.ttf", "MaterialAssets");
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.RegisterDependencies();
            return builder.Build();
        }
    }
}
