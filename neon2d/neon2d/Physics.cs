using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using neon2d.Math;

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

        public bool intersects(Vector2i other)
        {
            return other.x > this.x && other.x < this.x + width && other.y > this.y && other.y < this.y + this.height;
        }

        public bool intersects(Vector2f other)
        {
            return other.x > this.x && other.x < this.x + width && other.y > this.y && other.y < this.y + this.height;
        }

    }

    public class Circle
    {

        public float centerX, centerY;
        public float radius;

        public Circle(int centerX, int centerY, int radius)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.radius = radius;
        }
        public Circle(Vector2i centerPoint, int radius)
        {
            this.centerX = centerPoint.x;
            this.centerY = centerPoint.y;
            this.radius = radius;
        }

        public bool intersects(Vector2i other)
        {
            return other.x >= centerX - radius && other.x <= centerX + radius
                && other.y >= centerY - radius && other.y <= centerY + radius;
        }

    }
}
