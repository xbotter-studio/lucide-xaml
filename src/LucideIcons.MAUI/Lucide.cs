using System;
using System.Windows.Input;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace LucideIcons.MAUI;

public class LucideIcon : Label
{
    // ① Glyph 绑定属性（用 Core 的常量）
    public static readonly BindableProperty GlyphProperty =
        BindableProperty.Create(nameof(Glyph), typeof(string), typeof(LucideIcon),
            default(string), propertyChanged: (v,o,n) => ((LucideIcon)v).Text = (string)n);

    public string Glyph
    {
        get => (string)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }

    // ② Size 语法糖（同步 FontSize）
    public static readonly BindableProperty SizeProperty =
        BindableProperty.Create(nameof(Size), typeof(double), typeof(LucideIcon),
            24.0, propertyChanged: (v,o,n) => ((LucideIcon)v).FontSize = (double)n);

    public double Size
    {
        get => (double)GetValue(SizeProperty);
        set => SetValue(SizeProperty, value);
    }

    // ③ 点击命令（可选）
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(LucideIcon));

    public ICommand? Command
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public LucideIcon()
    {
        FontFamily = "LucideIcons";
        HorizontalTextAlignment = TextAlignment.Center;
        VerticalTextAlignment   = TextAlignment.Center;

        // 简易点击处理
        this.GestureRecognizers.Add(new TapGestureRecognizer
        {
            Command = new Command(() => Command?.Execute(null))
        });
    }
}
