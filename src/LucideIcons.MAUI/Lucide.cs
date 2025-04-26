using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace LucideIcons;

public class Icon : Label
{
    // ① Glyph 绑定属性（用 Core 的常量）
    public static readonly BindableProperty GlyphProperty =
        BindableProperty.Create(nameof(Glyph), typeof(LucideIconGlyph), typeof(Icon),
            default(LucideIconGlyph), propertyChanged: (v, o, n) => ((Icon)v).Text = ((LucideIconGlyph)n).S_CODE);

    [Required]
    public LucideIconGlyph Glyph
    {
        get => (LucideIconGlyph)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }

    // ② Size 语法糖（同步 FontSize）
    public static readonly BindableProperty SizeProperty =
        BindableProperty.Create(nameof(Size), typeof(double), typeof(Icon),
            24.0, propertyChanged: (v, o, n) => ((Icon)v).FontSize = (double)n);

    public double Size
    {
        get => (double)GetValue(SizeProperty);
        set => SetValue(SizeProperty, value);
    }

    // ③ 点击命令（可选）
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(Icon));

    public ICommand? Command
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public Icon()
    {
        FontFamily = "LucideIcons";
        HorizontalTextAlignment = TextAlignment.Center;
        VerticalTextAlignment = TextAlignment.Center;

        // 简易点击处理
        this.GestureRecognizers.Add(new TapGestureRecognizer
        {
            Command = new Command(() => Command?.Execute(null))
        });
    }

    protected override void OnParentSet()
    {
        base.OnParentSet();

        if (Glyph == default)
        {
            throw new InvalidCastException($"Glyph cannot be null or default. Please set a valid LucideIconGlyph.");
        }
    }
}
