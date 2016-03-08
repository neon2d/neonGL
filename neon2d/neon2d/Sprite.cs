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

        public Bitmap[] spriteFrames = new Bitmap[9999];
        public Bitmap currentFrame;
        int spriteCt = 0;
        int currentFrameId = 0;
        public int spriteX;
        public int spriteY;
        public int spriteWidth;
        public int spriteHeight;
        
        public Sprite(Bitmap[] Frames, int x, int y, int width = -1, int height = -1)
        {
            spriteFrames = Frames;
            currentFrame = spriteFrames[0];
            spriteCt = spriteFrames.Length - 1;
            spriteX = x;
            spriteY = y;
            if(width == -1)
            {
                spriteWidth = spriteFrames[0].Width;
            }
            else
            {
                spriteWidth = width;
            }
            if(height == -1)
            {
                spriteHeight = spriteFrames[0].Height;
            }
            else
            {
                spriteHeight = height;
            }
        }

        public Sprite(Bitmap[] frames, Physics.Rect dimensions)
        {
            spriteFrames = frames;
            currentFrame = spriteFrames[0];
            spriteCt = spriteFrames.Length - 1;
            spriteX = (int)dimensions.x;
            spriteY = (int)dimensions.y;
            spriteWidth = (int)dimensions.width;
            spriteHeight = (int)dimensions.height;
        }

        public void stepForward(int increment = 1)
        {
            if(currentFrameId + increment > spriteCt)
            {
                Message.neonError("Frame outside of animation bounds [" + Convert.ToString(currentFrameId + increment) + " > " + Convert.ToString(spriteCt) + "]");
            }
            else
            {
                currentFrameId += increment;
                currentFrame = spriteFrames[currentFrameId];
            }
        }

        public void stepBack(int increment = 1)
        {
            if(currentFrameId - increment < 0)
            {
                Message.neonError("Frame outside of animation bounds [" + Convert.ToString(currentFrameId - increment) + " < 0]");
            }
            else
            {
                currentFrameId -= increment;
                currentFrame = spriteFrames[currentFrameId];
            }
        }

        public void stepTo(int framenum)
        {
            if(framenum > spriteCt)
            {
                Message.neonError("Frame outside of animation bounds [" + Convert.ToString(framenum) + " > " + Convert.ToString(spriteCt) + "]");
            }
            else if(framenum < spriteCt)
            {
                Message.neonError("Frame outside of animation bounds [" + Convert.ToString(framenum) + " < 0]");
            }
            else
            {
                currentFrameId = framenum;
                currentFrame = spriteFrames[currentFrameId];
            }
        }

    }
}
