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

        public Bitmap backgroundimg = null;
        public bool backgroundtiling = true;

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

        public struct SpriteStruct
        {
            public Sprite s;
            public int x;
            public int y;

            public SpriteStruct(Sprite s, int x, int y)
            {
                this.s = s;
                this.x = x;
                this.y = y;
            }
        }

        public struct PropStruct
        {
            public Prop p;
            public int x;
            public int y;

            public PropStruct(Prop p, int x, int y)
            {
                this.p = p;
                this.x = x;
                this.y = y;
            }
        }

        public void render(Sprite render, int x, int y)
        {
            renderlist[renderct] = new SpriteStruct(render, x, y);
            renderct++;
        }

        public void render(Prop render, int x, int y)
        {
            renderlist[renderct] = new PropStruct(render, x, y);
            renderct++;
        }

        //differs from ParticleSystem.ParticleStruct!!
        public struct ParticleRenderStruct
        {
            public int x;
            public int y;
            public ParticleSystem ps;

            public ParticleRenderStruct(int x, int y, ParticleSystem ps)
            {
                this.x = x;
                this.y = y;
                this.ps = ps;
            }

        }

        public void render(ParticleSystem ps, int x, int y)
        {
            renderlist[renderct] = new ParticleRenderStruct(x, y, ps);
            renderct++;
        }

        public struct TextStruct
        {
            public string stringtext;
            public int _x;
            public int _y;
            public Brush stringcolor;
            public Font stringfont;

            public TextStruct(string text, int x, int y, Brush textcolor, Font textfont)
            {
                stringtext = text;
                _x = x;
                _y = y;
                stringcolor = textcolor;
                stringfont = textfont;
            }

        }

        public void render(string text, int x, int y, Brush textcolor = null, Font textfont = null)
        {
            Brush tempcolor;
            Font tempfont;
            if (textcolor == null)
            {
                tempcolor = Brushes.White;
            }
            else
            {
                tempcolor = textcolor;
            }

            if (textfont == null)
            {
                tempfont = SystemFonts.DialogFont;
            }
            else
            {
                tempfont = textfont;
            }
            renderlist[renderct] = new TextStruct(text, x, y, tempcolor, tempfont);
            renderct++;
        }

        //shape stuff goes here
        //starting with some special structs to hold them in the arrays
        //DEVS DON'T NEED TO USE THESE STRUCTS! THEY ARE MERELY USED AS THE DATATYPE FOR THE ARRAYS
        //SO WE CAN HOLD LINES, BRUSHES, AND INT WIDTHS IN THE SAME ARRAY.

        public struct LineStruct
        {

            public Shape.Line line;
            public Pen p;

            public LineStruct(Shape.Line l, Pen c)
            {
                line = l;
                p = c;
            }
        }

        public struct RectStruct
        {

            public Shape.Rectangle rect;
            public Pen p;

            public RectStruct(Shape.Rectangle r, Pen c)
            {
                rect = r;
                p = c;
            }
        }

        public struct EllipsStruct
        {

            public Shape.Ellipse ell;
            public Pen p;

            public EllipsStruct(Shape.Ellipse e, Pen c)
            {
                ell = e;
                p = c;
            }
        }

        public struct TriStruct
        {

            public Shape.Triangle tri;
            public Pen p;

            public TriStruct(Shape.Triangle t, Pen c)
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
            LineStruct ls = new LineStruct(line, pcolor);
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
            RectStruct rs = new RectStruct(rect, pcolor);
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
            EllipsStruct es = new EllipsStruct(ellipse, pcolor);
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
            TriStruct ts = new TriStruct(triangle, pcolor);
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

        //Background Stuff
        public void renderBackground(Prop background, bool tiling = true)
        {
            backgroundimg = background.propSource;
            backgroundtiling = tiling;
        }
        public void renderBackground(Bitmap background, bool tiling = true)
        {
            backgroundimg = background;
            backgroundtiling = tiling;
        }

    }
}
