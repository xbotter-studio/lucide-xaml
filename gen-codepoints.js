// 读取 css，把 .lucide-***:before { content:"\e001"; } 抠出来
import fs from 'fs';
import path from 'path';

const fontPath = path.resolve('lucide/lucide-font/lucide.ttf');
const targetPath = path.resolve('src/LucideIcons/Resources/Fonts/lucide.ttf');
const cssPath  = path.resolve('lucide/lucide-font/lucide.css');
const jsonPath = path.resolve('src/LucideIcons/Resources/Iconmap/codepoints.json');
const glyphCs  = path.resolve('src/LucideIcons/Resources/LucideIconGlyph.g.cs');

// 1) 复制字体文件
fs.mkdirSync(path.dirname(targetPath), { recursive: true });
fs.copyFileSync(fontPath, targetPath);
console.log(`✓  copied ${fontPath} -> ${targetPath}`);

const css = fs.readFileSync(cssPath, 'utf8');

const regex = /\.icon-([\w-]+):before\s*\{[^}]*?content:\s*["']\\([a-f0-9]{4})["']/gi;

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
let cs = `namespace LucideIcons;\npublic partial class LucideIconGlyph\n{\n`;
for (const [name, code] of Object.entries(map)) {
  cs += `    public static LucideIconGlyph ${pascal(name)} = new("\\u${code.slice(2)}");\n`;
}
cs += `}\n`;
fs.writeFileSync(glyphCs, cs);
console.log(`✓  written ${glyphCs}`);

function pascal(s){return s.replace(/(^|-)(\w)/g,(_,__,c)=>c.toUpperCase());}
