﻿using MauiIcons.Fluent;
using MauiIcons.Material;
using Microsoft.Extensions.Logging;

namespace CocQuery
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder
            .UseMauiApp<App>()
            .UseFluentMauiIcons()
            .UseMaterialMauiIcons();
            return builder.Build();
        }
    }
}
