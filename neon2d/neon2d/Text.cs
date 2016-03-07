using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace neon2d
{
    public class Text
    {

        public string textcontent = "";
        public int textx = 0;
        public int texty = 0;
        public Brush stringbrush = Brushes.Black;
        public Font stringfont = SystemFonts.DefaultFont;

        public Text(string text, int x, int y, Brush textbrush = null, Font textfont = null)
        {
            textcontent = text;
            textx = x;
            texty = y;
            if(textbrush != null)
            {
                stringbrush = textbrush;
            }
            if(textfont != null)
            {
                stringfont = textfont;
            }
        }

    }
}
