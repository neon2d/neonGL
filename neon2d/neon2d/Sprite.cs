using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace neon2d
{
    public class Sprite
    {

        public Bitmap[] spriteframes = new Bitmap[9999];
        public Bitmap currentframe;
        int spritect = 0;
        int currentframeid = 0;
        public int spritex;
        public int spritey;
        public int spritewidth;
        public int spriteheight;
        
        public Sprite(Bitmap[] frames, int x, int y, int width = -1, int height = -1)
        {
            spriteframes = frames;
            currentframe = spriteframes[0];
            spritect = spriteframes.Length - 1;
            spritex = x;
            spritey = y;
            if(width == -1)
            {
                spritewidth = spriteframes[0].Width;
            }
            else
            {
                spritewidth = width;
            }
            if(height == -1)
            {
                spriteheight = spriteframes[0].Height;
            }
            else
            {
                spriteheight = height;
            }
        }

        public void stepForward(int increment = 1)
        {
            if(currentframeid + increment > spritect)
            {
                Message.neonError("Frame outside of animation bounds [" + Convert.ToString(currentframeid + increment) + " > " + Convert.ToString(spritect) + "]");
            }
            else
            {
                currentframeid += increment;
                currentframe = spriteframes[currentframeid];
            }
        }

        public void stepBack(int increment = 1)
        {
            if(currentframeid - increment < 0)
            {
                Message.neonError("Frame outside of animation bounds [" + Convert.ToString(currentframeid - increment) + " < 0]");
            }
            else
            {
                currentframeid -= increment;
                currentframe = spriteframes[currentframeid];
            }
        }

        public void stepTo(int framenum)
        {
            if(framenum > spritect)
            {
                Message.neonError("Frame outside of animation bounds [" + Convert.ToString(framenum) + " > " + Convert.ToString(spritect) + "]");
            }
            else if(framenum < spritect)
            {
                Message.neonError("Frame outside of animation bounds [" + Convert.ToString(framenum) + " < 0]");
            }
            else
            {
                currentframeid = framenum;
                currentframe = spriteframes[currentframeid];
            }
        }

    }
}
