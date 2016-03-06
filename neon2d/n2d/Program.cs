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

            Prop demoimage = new Prop(new Bitmap(@"C:\Users\Matthew\Documents\Visual Studio 2015\Projects\neon2d\neon2d\demoimage.png"), 10, imagey, 150, 150);
            //myscene.renderProp(demoimage);

            Physics.Bodies.Rect rect1 = new Physics.Bodies.Rect(0, 0, 50, 50);
            Physics.Bodies.Rect rect2 = new Physics.Bodies.Rect(10, 10, 30, 30);

            Physics.World gameworld = new Physics.World();

            
            Shape.Triangle tri = new Shape.Triangle(100, 100, 50, 50);
            Shape.Rectangle rect = new Shape.Rectangle(300, 300, 45, 80);
            Shape.Ellipse ell = new Shape.Ellipse(50, 50, 30, 50);
            Shape.Line li = new Shape.Line(600, 400, 650, 350);

            myscene.renderTriangle(tri, 2, Brushes.Blue);
            myscene.renderRectangle(rect, 1, Brushes.Green);
            myscene.renderEllipse(ell, 3, Brushes.Red);
            myscene.renderLine(li, 4, Brushes.Yellow);

            int mx = myscene.getMouseX();
            int my = myscene.getMouseY();

            myscene.renderText(new Text(mx.ToString(), 0, 0, Brushes.White));
            myscene.renderText(new Text(my.ToString(), 0, 15, Brushes.White));

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
