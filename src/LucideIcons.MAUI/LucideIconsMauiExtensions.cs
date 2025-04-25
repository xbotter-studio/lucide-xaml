using System;
using Microsoft.Maui.Controls.Hosting;
using LucideIcons;
namespace Microsoft.Maui.Hosting;


public static class LucideIconsMauiExtensions
{
    public static MauiAppBuilder UseIconKit(this MauiAppBuilder builder)
    {
        // 注：这里把字体流注册成 “XbotterIcons”
        builder.ConfigureFonts(fonts =>
        {
            using var stream = IconResources.GetFontStream();
            fonts.AddEmbeddedResourceFont(typeof(IconResources).Assembly,
                        IconResources.FontResourceId,
                        "LucideIcons");
        });
        return builder;
    }
}
