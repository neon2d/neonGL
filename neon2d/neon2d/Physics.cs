using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neon2d.Physics
{

    public class Rect
    {
        public float x, y;
        public float width, height;

        public Rect(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public bool intersects(Rect other)
        {
            return this.x + this.width > other.x && this.x < other.x + other.width
                   &&
                   this.y + this.height > other.y && this.y < other.y + other.height;
        }
    }
}

