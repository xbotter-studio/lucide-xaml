namespace LucideIcons.MAUI.Sample.Pages;

public partial class LucideIconsPage : ContentPage
{
    public LucideIconsPage()
    {
        InitializeComponent();

        // ��ȡ Lucide �����е�ͼ��

        var icons = typeof(LucideIconGlyph).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
            .Where(f => f.FieldType == typeof(LucideIconGlyph))
            .Select(f => (LucideIconGlyph)f.GetValue(null))
            .ToList();

        // �󶨵� Layout ��

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