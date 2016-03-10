using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

using neon2d;
using neon2d.Physics;
using neon2d.Math;

namespace n2d
{
    class Program
    {
        public static Window mywindow;
        public static Scene myscene;

        public static bool movingup = false;
        public static int imagey = 10;

        public static Vector2i vector = new Vector2i(10, 20);

        public static void Main(string[] args)
        {
            mywindow = new Window(800, 600, "my awesome window");
            myscene = new Scene(mywindow);

            Game maingame = new Game(mywindow, myscene, new Action(updateVoid));
            onStart();
            maingame.runGame();
        }
        public static void onStart()
        {
            // Vector2f's
            Console.WriteLine(new Vector2f(10, 20.2f) + new Vector2f(20, 10.3f));

            // Vecto2i's
            Console.WriteLine(new Vector2i(10, 20) - new Vector2i(5, 10));
        }

        public static void updateVoid()
        {
            checkInput();

            if(movingup)
            {
                imagey--;
            }

            string imagepath = Environment.CurrentDirectory + @"\..\..\res\demoimage.png"; //this is /bin/Debug/ btw
            Prop demoimage = new Prop(new Bitmap(imagepath), 10, imagey);
            myscene.render(demoimage);

            Rect rect1 = new Rect(0, 0, 60, 60);
            Rect rect2 = new Rect(10, 10, 40, 40);

            if(rect1.intersects(rect2))
            {
                //Console.WriteLine("intersecting!");
            }

            Shape.Triangle tri = new Shape.Triangle(100, 100, 50, 50);
            Shape.Rectangle rect = new Shape.Rectangle(300, 300, 45, 80);
            Shape.Ellipse ell = new Shape.Ellipse(50, 50, 30, 50);
            Shape.Line li = new Shape.Line(600, 400, 650, 350);

            myscene.render(tri, 2, Brushes.Blue);
            myscene.render(rect, 1, Brushes.Green);
            myscene.render(ell, 3, Brushes.Red);
            myscene.render(li, 4, Brushes.Yellow);

            int mx = myscene.getMouseX();
            int my = myscene.getMouseY();

            myscene.render(mx.ToString(), 0, 0);
            myscene.render(my.ToString(), 0, 10);
            myscene.render("Vector result: " + vector.ToString(), 200, 100);

            myscene.renderBackground(demoimage, true);
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
