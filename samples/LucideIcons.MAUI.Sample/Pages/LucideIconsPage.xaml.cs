namespace LucideIcons.MAUI.Sample.Pages;

public partial class LucideIconsPage : ContentPage
{
    public LucideIconsPage()
    {
        InitializeComponent();

        // 获取 Lucide 中所有的图标

        var icons = typeof(LucideIconGlyph).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
            .Where(f => f.FieldType == typeof(LucideIconGlyph))
            .Select(f => (LucideIconGlyph)f.GetValue(null))
            .ToList();

        // 绑定到 Layout 中

        foreach (var icon in icons)
        {

            Layout.Children.Add(new Icon()
            {
                Glyph = icon,
                Size = 72
            });
        }
    }
}