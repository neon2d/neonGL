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

        public int propX;
        public int propY;
        public int propWidth;
        public int propHeight;

        public Prop(Bitmap image, int x, int y, int width, int height)
        {
            propSource = image;
            propX = x;
            propY = y;
            propWidth = width;
            propHeight = height;
        }

        public Prop(Bitmap image, Physics.Rect dimensions)
        {
            propSource = image;
            propX = (int) dimensions.x;
            propY = (int) dimensions.y;
            propWidth = (int) dimensions.width;
            propHeight = (int) dimensions.height;
        }

        public Prop(Bitmap image, int x, int y)
        {
            propSource = image;
            propX = y;
            propY = x;
            propWidth = image.Width;
            propHeight = image.Height;
        }

    }
}
