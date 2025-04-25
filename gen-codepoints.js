// 读取 css，把 .lucide-***:before { content:"\e001"; } 抠出来
import fs from 'fs';
import path from 'path';

const cssPath  = path.resolve('src/LucideIcons/Resources/Fonts/lucide.css');
const jsonPath = path.resolve('src/LucideIcons/Resources/Iconmap/codepoints.json');
const glyphCs  = path.resolve('src/LucideIcons/Resources/LucideIconGlyph.g.cs');

const css = fs.readFileSync(cssPath, 'utf8');

const regex = /\.lucide-([\w-]+)::before\s*\{[^}]*?content:\s*["']\\([a-f0-9]{4})["']/gi;

const map = {};   // { iconName : "0xEA01", ... }
let m;
while ((m = regex.exec(css)) !== null) {
  const name = m[1];                 // a-arrow-down
  const code = `0x${m[2].toUpperCase()}`; // 0xEA01
  map[name] = code;
}

// 1) 生成 codepoints.json
fs.mkdirSync(path.dirname(jsonPath), { recursive: true });
fs.writeFileSync(jsonPath, JSON.stringify(map, null, 2));
console.log(`✓  written ${jsonPath}`);

// 2) 生成 C# 强类型常量
let cs = `namespace LucideIcons;\npublic static partial class LucideIconGlyph\n{\n`;
for (const [name, code] of Object.entries(map)) {
  cs += `    public const string ${pascal(name)} = "\\u${code.slice(2)}";\n`;
}
cs += `}\n`;
fs.writeFileSync(glyphCs, cs);
console.log(`✓  written ${glyphCs}`);

function pascal(s){return s.replace(/(^|-)(\w)/g,(_,__,c)=>c.toUpperCase());}
