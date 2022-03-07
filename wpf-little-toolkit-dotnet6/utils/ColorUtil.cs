using System;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace io.github.toyota32k.dotnet6.toolkit.utils {
    public static class ColorUtil {
        private static readonly Regex colorReg = new(@"#*(?<a>[0-9a-f]{2})*(?<r>[0-9a-f]{2})(?<g>[0-9a-f]{2})(?<b>[0-9a-f]{2})", RegexOptions.IgnoreCase);
        public static Color Parse(string colorText) {
            var m = colorReg.Match(colorText);
            if (!m.Success) return Colors.Gray;
            var a = m.Groups["a"].Value;
            var r = m.Groups["r"].Value;
            var g = m.Groups["g"].Value;
            var b = m.Groups["b"].Value;
            return !string.IsNullOrEmpty(a) ? Color.FromArgb(Convert.ToByte(a,16), Convert.ToByte(r,16), Convert.ToByte(g,16), Convert.ToByte(b,16)) : Color.FromRgb(Convert.ToByte(r, 16), Convert.ToByte(g, 16), Convert.ToByte(b, 16));
        }
    }
}
