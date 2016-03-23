using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neon2d.Math
{
    public class Vector2i
    {
        public int x, y;

        public Vector2i()
        {
            this.x = 0;
            this.y = 0;
        }

        public Vector2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2i add(Vector2i vector)
        {
            this.x += vector.x;
            this.y += vector.y;
            return this;
        }

        public Vector2i subtract(Vector2i vector)
        {
            this.x -= vector.x;
            this.y -= vector.y;
            return this;
        }

        public Vector2i multiply(Vector2i vector)
        {
            this.x *= vector.x;
            this.y *= vector.y;
            return this;
        }

        public Vector2i divide(Vector2i vector)
        {
            this.x /= vector.x;
            this.y /= vector.y;
            return this;
        }

        public static Vector2i operator+(Vector2i a, Vector2i b)
        {
            return a.add(b);
        }

        public static Vector2i operator-(Vector2i a, Vector2i b)
        {
            return a.subtract(b);
        }

        public static Vector2i operator*(Vector2i a, Vector2i b)
        {
            return a.multiply(b);
        }

        public static Vector2i operator/(Vector2i a, Vector2i b)
        {
            return a.divide(b);
        }

        public override string ToString()
        {
            return this.x + ", " + this.y;
        }
    }

    public class Vector2f
    {
        public float x, y;
        public Vector2f()
        {
            this.x = 0f;
            this.y = 0f;
        }

        public Vector2f(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2f add(Vector2f other)
        {
            this.x += other.x;
            this.y += other.y;
            return this;
        }

        public Vector2f subtract(Vector2f other)
        {
            this.x -= other.x;
            this.y -= other.y;
            return this;
        }

        public Vector2f multiply(Vector2f other)
        {
            this.x *= other.x;
            this.y *= other.y;
            return this;
        }

        public Vector2f divide(Vector2f other)
        {
            this.x /= other.x;
            this.y /= other.y;
            return this;
        }

        public static Vector2f operator+(Vector2f a, Vector2f b)
        {
            return a.add(b);
        }

        public static Vector2f operator-(Vector2f a, Vector2f b)
        {
            return a.subtract(b);
        }

        public static Vector2f operator*(Vector2f a, Vector2f b)
        {
            return a.multiply(b);
        }

        public static Vector2f operator/(Vector2f a, Vector2f b)
        {
            return a.divide(b);
        }

        public override string ToString()
        {
            return x + ", " + y;
        }
    }
}
