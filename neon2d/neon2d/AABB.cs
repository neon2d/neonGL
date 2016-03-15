using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neon2d.Math
{
    public class AABB
    {

        public int x, y;
        public int width, height;

        public AABB()
        {
            x = 0;
            y = 0;
            width = 0;
            height = 0;
        }

        public AABB(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public AABB add(AABB aabb)
        {
            this.x += aabb.x;
            this.y += aabb.y;
            this.width += aabb.width;
            this.height += aabb.height;
            return this;
        }

        public AABB subtract(AABB aabb)
        {
            this.x -= aabb.x;
            this.y -= aabb.y;
            this.width -= aabb.width;
            this.height -= aabb.height;
            return this;
        }

        public AABB multiply(AABB aabb)
        {
            this.x *= aabb.x;
            this.y *= aabb.y;
            this.width *= aabb.width;
            this.height *= aabb.height;
            return this;
        }

        public AABB divide(AABB aabb)
        {
            this.x /= aabb.x;
            this.y /= aabb.y;
            this.width /= aabb.width;
            this.height /= aabb.height;
            return this;
        }

        public static AABB operator +(AABB a, AABB b)
        {
            return a.add(b);
        }

        public static AABB operator -(AABB a, AABB b)
        {
            return a.subtract(b);
        }

        public static AABB operator *(AABB a, AABB b)
        {
            return a.multiply(b);
        }

        public static AABB operator /(AABB a, AABB b)
        {
            return a.divide(b);
        }

        public override string ToString()
        {
            return this.x + ", " + this.y + "; " + this.width + ", " + this.height;
        }

    }
}
