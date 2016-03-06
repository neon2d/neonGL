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

            public int lx1 = 0;
            public int ly1 = 0;
            public int lx2 = 0;
            public int ly2 = 0;

            public Line(int x1, int y1, int x2, int y2)
            {
                lx1 = x1;
                ly1 = y1;
                lx2 = x2;
                ly2 = y2;
            }

        }

        public class Rectangle
        {

            public int rectx = 0;
            public int recty = 0;
            public int rectw = 0;
            public int recth = 0;

            public Rectangle(int x, int y, int width, int height)
            {
                rectx = x;
                recty = y;
                rectw = width;
                recth = height;
            }
        
        }

        public class Ellipse
        {

            public int ellipsx = 0;
            public int ellipsy = 0;
            public int ellipsw = 0;
            public int ellipsh = 0;

            public Ellipse(int x, int y, int width, int height)
            {
                ellipsx = x;
                ellipsy = y;
                ellipsw = width;
                ellipsh = height;
            }

        }

        public class Triangle
        {

            public int trix = 0;
            public int triy = 0;
            public int triw = 0;
            public int trih = 0;

            public Triangle(int x, int y, int width, int height)
            {
                trix = x;
                triy = y;
                triw = width;
                trih = height;
            }

        }

    }
}
