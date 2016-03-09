using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neon2d
{
    public class Shape
    {

        public class Line
        {

            public int lX1 = 0;
            public int lY1 = 0;
            public int lX2 = 0;
            public int lY2 = 0;

            public Line(int x1, int y1, int x2, int y2)
            {
                lX1 = x1;
                lY1 = y1;
                lX2 = x2;
                lY2 = y2;
            }
            public Line(Math.Vector2i point1, Math.Vector2i point2)
            {
                lX1 = point1.x;
                lY1 = point1.y;
                lX2 = point2.x;
                lY2 = point2.y;
            }

        }

        public class Rectangle
        {

            public int rectX = 0;
            public int rectY = 0;
            public int rectWidth = 0;
            public int rectHeight = 0;

            public Rectangle(int x, int y, int width, int height)
            {
                rectX = x;
                rectY = y;
                rectWidth = width;
                rectHeight = height;
            }
            public Rectangle(Physics.Rect dimensions)
            {
                rectX = (int)dimensions.x;
                rectY = (int)dimensions.y;
                rectWidth = (int)dimensions.width;
                rectHeight = (int)dimensions.height;
            }
        
        }

        public class Ellipse
        {

            public int ellipsX = 0;
            public int ellipsY = 0;
            public int ellipsWidth = 0;
            public int ellipsHeight = 0;

            public Ellipse(int x, int y, int width, int height)
            {
                ellipsX = x;
                ellipsY = y;
                ellipsWidth = width;
                ellipsHeight = height;
            }
            public Ellipse(Physics.Rect dimensions)
            {
                ellipsX = (int)dimensions.x;
                ellipsY = (int)dimensions.y;
                ellipsWidth = (int)dimensions.width;
                ellipsHeight = (int)dimensions.height;
            }

        }

        public class Triangle
        {

            public int triX = 0;
            public int triY = 0;
            public int triWidth = 0;
            public int triHeight = 0;

            public Triangle(int x, int y, int width, int height)
            {
                triX = x;
                triY = y;
                triWidth = width;
                triHeight = height;
            }
            public Triangle(Physics.Rect dimensions)
            {
                triX = (int)dimensions.x;
                triY = (int)dimensions.y;
                triWidth = (int)dimensions.width;
                triHeight = (int)dimensions.height;
            }

        }

    }
}
