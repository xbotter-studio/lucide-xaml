using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LucideIcons;

public partial class LucideIconGlyph
{
    private static readonly Dictionary<string, LucideIconGlyph> _glyphs = new Dictionary<string, LucideIconGlyph>();
    
    public static implicit operator LucideIconGlyph(string glyph)
    {
        if (string.IsNullOrEmpty(glyph))
            throw new ArgumentNullException(nameof(glyph), "Glyph name cannot be null or empty.");
        
        if(_glyphs.Count == 0)
        {
            // 预先加载所有的 glyphs
            var fields = typeof(LucideIconGlyph).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            foreach (var field in fields)
            {
                if (field.GetValue(null) is LucideIconGlyph glyphObj)
                {
                    _glyphs[field.Name] = glyphObj;
                }
            }
        }

        if (_glyphs.TryGetValue(glyph, out var iconGlyph))
        {
            return iconGlyph;
        }
        else
        {
            throw new KeyNotFoundException($"Glyph '{glyph}' not found.");
        }
       

    }

    public string S_CODE { get; }
    public LucideIconGlyph(string code)
    {
        S_CODE = code;
    }
}
