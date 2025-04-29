using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LucideIcons;

public partial class LucideIconGlyph
{
    public string S_CODE { get; }

    public static implicit operator LucideIconGlyph(string glyph)
    {
        // 从当前类型中获取同名的 static 资源
        var field = typeof(LucideIconGlyph).GetField(glyph, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        if (field == null || field.GetValue(null) == null)
            throw new ArgumentException($"No such glyph: {glyph}");
        
        return (LucideIconGlyph)field.GetValue(null)!;

    }

    public LucideIconGlyph(string code)
    {
        S_CODE = code;
    }
}
