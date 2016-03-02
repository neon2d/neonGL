using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using neon2d;
using System.Drawing;
using System.Windows.Forms;

namespace n2d
{
    class Program
    {

        public static Window mywindow = new Window(800, 600, "neon2d window");
        public static Scene myscene;

        public static bool shouldDraw = true;

        public static int imagey = 0;
        public static int imagex = 0;
        public static bool moveUp = false;
        public static bool moveDown = false;
        public static bool moveLeft = false;

        public static void Main(string[] args)
        {
            myscene = new Scene(mywindow);
            Game mygame = new Game(mywindow, myscene, new Action(updateVoid));
            //Sound mysound = new Sound(@"C:\Users\Matthew\Music\gachigasm.wav");
            //myscene.playSound(mysound, true);
            mygame.runGame();
        }

        public static void updateVoid()
        {
            Bitmap neonlogo = new Bitmap(@"C:\Users\Matthew\Documents\Visual Studio 2015\Projects\neon2d\neon2d\demoimage.png");
            Prop logoprop = new Prop(neonlogo, imagex, imagey);
            myscene.renderProp(logoprop);
            checkInput();
        }

        public static void checkInput()
        {
            if (myscene.readKeyDown(Keys.Up))
            {
                moveUp = true;
            }
            if(myscene.readKeyDown(Keys.Down))
            {
                moveDown = true;
            }
            if (myscene.keyUp())
            {
                moveUp = false;
                moveDown = false;
            }
            if(myscene.mouseHeld())
            {
                moveLeft = true;
            }
            if (moveUp)
            {
                moveDown = false;
                imagey -= 4;
            }
            if(moveDown)
            {
                moveUp = false;
                imagey += 4;
            }
            if(moveLeft)
            {
                moveLeft = false;
                imagex -= 4;
            }
        }
    }
}
