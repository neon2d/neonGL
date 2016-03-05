using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neon2d
{
    class Physics
    {

        public class Bodies
        {
            public class Rect
            {

                public int rectx = 0;
                public int recty = 0;
                public int rectwidth = 0;
                public int rectheight = 0;

                public Rect(int x, int y, int width, int height)
                {
                    rectx = x;
                    recty = y;
                    rectwidth = width;
                    rectheight = height;
                }

            }
        }

        public class World
        {
            
            public void getRectCollision(Bodies.Rect rect1, Bodies.Rect rect2)
            {
                //get rekt
            }

        }

    }
}
