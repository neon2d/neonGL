using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using neon2d;

namespace n2d
{
    class Program
    {

        public static Window mywindow;
        public static Scene myscene;

        public static bool movingup = false;
        public static int imagey = 10;

        public static void Main(string[] args)
        {
            mywindow = new Window(800, 600, "my awesome window");
            myscene = new Scene(mywindow);

            Game maingame = new Game(mywindow, myscene, new Action(updateVoid));
            maingame.runGame();
        }

        public static void updateVoid()
        {
            checkInput();

            if(movingup)
            {
                imagey--;
            }

            Console.WriteLine("tick!");
            Prop demoimage = new Prop(new Bitmap(@"C:\Users\Matthew\Documents\Visual Studio 2015\Projects\neon2d\neon2d\demoimage.png"), 10, imagey, 150, 150);
            myscene.renderProp(demoimage);
        }

        public static void checkInput()
        {
            if(myscene.readKeyDown(Keys.Up))
            {
                movingup = true;
            }

            if(myscene.keyUp())
            {
                movingup = false;
            }
        }

    }
}
