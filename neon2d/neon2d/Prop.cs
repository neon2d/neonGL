using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace neon2d
{
    public class Prop
    {

        public Bitmap propsource;
        public int propx;
        public int propy;
        public int propwidth;
        public int propheight;

        public Prop(Bitmap image, int x, int y, int width = -1, int height = -1)
        {
            propsource = image;
            propx = x;
            propy = y;
            if (width == -1)
            {
                propwidth = propsource.Width;
            }
            else
            {
                propwidth = width;
            }
            if (height == -1)
            {
                propheight = propsource.Height;
            }
            else
            {
                propheight = height;
            }
        }

    }
}
