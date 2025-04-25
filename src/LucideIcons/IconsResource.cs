using System;
using System.Reflection;

namespace LucideIcons;

/// <summary>
/// 读取嵌入字体流，供各平台包装库注册字体时使用。
/// </summary>
public static class IconResources
{
    // ❶ 嵌入资源的完全限定名
    //    若文件在 Core 项目里是  Resources/Fonts/xbottericons.ttf
    //    且 <EmbeddedResource LogicalName="..." /> 留空，
    //    默认 LogicalName = "{根命名空间}.Resources.Fonts.xbottericons.ttf"
    public const string FontResourceId =
        "LucideIcons.icons.ttf";

    // ❷ 取流
    public static Stream GetFontStream()
    {
        var asm = typeof(IconResources).GetTypeInfo().Assembly;
        return asm.GetManifestResourceStream(FontResourceId)
            ?? throw new InvalidOperationException(
               $"Embedded resource '{FontResourceId}' not found.");
    }
}