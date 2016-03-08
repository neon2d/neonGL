using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Media;
using System.Drawing;

namespace neon2d
{
    public class Scene
    {

        public Object[] renderlist = new Object[999999];
        public int renderct = 0;

        public Form ownerwindow;

        public Keys downkey;
        public bool keytrue;
        public bool keyuptrue;

        public bool clicktrue;
        public bool doubleclicktrue;
        public bool heldtrue;

        public int mousex = 0;
        public int mousey = 0;

        public Scene(Window owner)
        {
            ownerwindow = owner.gamewindow;
            ownerwindow.KeyDown += Gamewindow_KeyDown;
            ownerwindow.KeyUp += Ownerwindow_KeyUp;
            ownerwindow.MouseMove += Ownerwindow_MouseMove;
            ownerwindow.Click += Ownerwindow_Click;
            ownerwindow.MouseDown += Ownerwindow_MouseDown;
            ownerwindow.DoubleClick += Ownerwindow_DoubleClick;
            ownerwindow.MouseUp += Ownerwindow_MouseUp;
        }

        private void Ownerwindow_MouseDown(object sender, MouseEventArgs e)
        {
            heldtrue = true;
        }

        private void Ownerwindow_MouseUp(object sender, MouseEventArgs e)
        {
            heldtrue = false;
            clicktrue = false;
            doubleclicktrue = false;
        }

        //mouse input stuff
        private void Ownerwindow_DoubleClick(object sender, EventArgs e)
        {
            doubleclicktrue = true;
        }
        
        private void Ownerwindow_Click(object sender, EventArgs e)
        {
            clicktrue = true;
        }

        private void Ownerwindow_MouseMove(object sender, MouseEventArgs e)
        {
            mousex = e.X;
            mousey = e.Y;
        }

        private void Ownerwindow_KeyUp(object sender, KeyEventArgs e)
        {
            keyuptrue = true;
        }

        private void Gamewindow_KeyDown(object sender, KeyEventArgs e)
        {
            keyuptrue = false;
            downkey = e.KeyCode;
        }

        public void render(Sprite render)
        {
            renderlist[renderct] = render;
            renderct++;
        }

        public void render(Prop render)
        {
            renderlist[renderct] = render;
            renderct++;
        }

        public void render(Text stringtext)
        {
            renderlist[renderct] = stringtext;
            renderct++;
        }

        //shape stuff goes here
        //starting with some special structs to hold them in the arrays
        //DEVS DON'T NEED TO USE THESE STRUCTS! THEY ARE MERELY USED AS THE DATATYPE FOR THE ARRAYS
        //SO WE CAN HOLD LINES, BRUSHES, AND INT WIDTHS IN THE SAME ARRAY.

        public struct linestruct
        {

            public Shape.Line line;
            public Pen p;

            public linestruct(Shape.Line l, Pen c)
            {
                line = l;
                p = c;
            }
        }

        public struct rectstruct
        {

            public Shape.Rectangle rect;
            public Pen p;

            public rectstruct(Shape.Rectangle r, Pen c)
            {
                rect = r;
                p = c;
            }
        }

        public struct ellipsstruct
        {

            public Shape.Ellipse ell;
            public Pen p;

            public ellipsstruct(Shape.Ellipse e, Pen c)
            {
                ell = e;
                p = c;
            }
        }

        public struct tristruct
        {

            public Shape.Triangle tri;
            public Pen p;

            public tristruct(Shape.Triangle t, Pen c)
            {
                tri = t;
                p = c;
            }
        }

        //THE ACTUAL SHAPE RENDERING IS HERE
        
        public void render(Shape.Line line, int thickness = 1, Brush color = null)
        {
            Pen pcolor;
            if(color == null)
            {
                pcolor = new Pen(Brushes.Black, thickness);
            }
            else
            {
                pcolor = new Pen(color, thickness);
            }
            linestruct ls = new linestruct(line, pcolor);
            renderlist[renderct] = ls;
            renderct++;
        }

        public void render(Shape.Rectangle rect, int thickness = 1, Brush color = null)
        {
            Pen pcolor;
            if (color == null)
            {
                pcolor = new Pen(Brushes.Black, thickness);
            }
            else
            {
                pcolor = new Pen(color, thickness);
            }
            rectstruct rs = new rectstruct(rect, pcolor);
            renderlist[renderct] = rs;
            renderct++;
        }

        public void render(Shape.Ellipse ellipse, int thickness = 1, Brush color = null)
        {
            Pen pcolor;
            if (color == null)
            {
                pcolor = new Pen(Brushes.Black, thickness);
            }
            else
            {
                pcolor = new Pen(color, thickness);
            }
            ellipsstruct es = new ellipsstruct(ellipse, pcolor);
            renderlist[renderct] = es;
            renderct++;
        }

        public void render(Shape.Triangle triangle, int thickness = 1, Brush color = null)
        {
            Pen pcolor;
            if (color == null)
            {
                pcolor = new Pen(Brushes.Black, thickness);
            }
            else
            {
                pcolor = new Pen(color, thickness);
            }
            tristruct ts = new tristruct(triangle, pcolor);
            renderlist[renderct] = ts;
            renderct++;
        }

        public bool readKeyDown(Keys keyToDetect)
        {
            if(downkey == keyToDetect)
            {
                keytrue = true;
            }
            else
            {
                keytrue = false;
            }
            return keytrue;
        }

        public bool keyUp()
        {
            return keyuptrue;
        }

        public void cleanRenderBuffer()
        {
            for(int i = 0; i <= 999998; i++)
            {
                renderlist[i] = null;
            }
            renderct = 0;
        }

        public void playSound(Sound gamesound, bool loop = false)
        {
            SoundPlayer psound = new SoundPlayer(gamesound.soundsource);
            if(loop)
            {
                psound.PlayLooping();
            }
            else
            {
                psound.Play();
            }
        }

        public bool mouseClick()
        {
            return clicktrue;
        }

        public bool mouseDoubleClick()
        {
            return doubleclicktrue;
        }

        public bool mouseHeld()
        {
            return heldtrue;
        }

        public int getMouseX()
        {
            return mousex;
        }

        public int getMouseY()
        {
            return mousey;
        }

    }
}
