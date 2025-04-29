using System;
using Microsoft.Maui.Controls.Hosting;
using LucideIcons;
namespace Microsoft.Maui.Hosting;


public static class LucideIconsMauiExtensions
{
    public static MauiAppBuilder UseLucideIconKit(this MauiAppBuilder builder)
    {
        // 注：这里把字体流注册成 “LucideIcons”
        builder.ConfigureFonts(fonts =>
        {
            fonts.AddFont("Resources/Fonts/lucide.ttf", "LucideIcons");
        });
        return builder;
    }
}
