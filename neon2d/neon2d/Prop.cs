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

        public Bitmap propSource;
        public int propWidth;
        public int propHeight;

        public Prop(Bitmap image, int width, int height)
        {
            propSource = image;
            propWidth = width;
            propHeight = height;
        }

        public Prop(Bitmap image)
        {
            propSource = image;
            propWidth = image.Width;
            propHeight = image.Height;
        }

    }
}
