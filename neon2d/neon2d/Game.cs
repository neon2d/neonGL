using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;
using System.Threading;
using System.Reflection;

namespace neon2d
{

    public class Game
    {

        public Window window;
        public Scene scene;
        public Window defaultwindow = new Window(800, 600, "neon2d");
        public int fps = 30;
        public int tick = 0;

        public System.Timers.Timer refreshtimer;

        public Action update;

        public bool windowOpened = false;
        public bool threadRunning = false;
        public bool shouldRender = false;

        Sprite spritetype;
        Prop proptype;
        Text texttype;
        Scene.linestruct linetype;
        Scene.rectstruct recttype;
        Scene.ellipsstruct ellipstype;
        Scene.tristruct tritype;

        public Game(Window mainwindow, Scene mainscene, Action onUpdate, int framerate = 30)
        {
            window = mainwindow;
            scene = mainscene;
            fps = framerate;
            
            window.gamewindow.Focus();
            window.gamewindow.Paint += new System.Windows.Forms.PaintEventHandler(this.window_Paint);

            window.gamewindow.FormClosed += Gamewindow_FormClosed;

            refreshtimer = new System.Timers.Timer(1000 / framerate);
            refreshtimer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            refreshtimer.Enabled = true;

            update = onUpdate;

        }

        private void Gamewindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void window_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            for(int i = 0; i <= 999998; i++)
            {
                if (scene.renderlist[i] != null)
                {
                    if(scene.renderlist[i].GetType() == typeof(Sprite))
                    {
                        //its a sprite
                        Sprite placeholder = (Sprite) scene.renderlist[i];
                        
                        g.DrawImage(placeholder.currentframe, new Rectangle(placeholder.spritex, placeholder.spritey, placeholder.spritewidth, placeholder.spriteheight));
                    }
                    else if(scene.renderlist[i].GetType() == typeof(Prop))
                    {
                        //its a prop
                        Prop placeholder = (Prop)scene.renderlist[i];

                        g.DrawImage(placeholder.propsource, new Rectangle(placeholder.propx, placeholder.propy, placeholder.propwidth, placeholder.propheight));
                    }
                    else if(scene.renderlist[i].GetType() == typeof(Text))
                    {
                        //its text
                        Text placeholder = (Text)scene.renderlist[i];

                        g.DrawString(placeholder.textcontent, placeholder.stringfont, placeholder.stringbrush, (float)placeholder.textx, (float)placeholder.texty);
                    }
                    else if(scene.renderlist[i].GetType() == typeof(Shape.Line))
                    {
                        //its a line
                        Scene.linestruct placeholder = (Scene.linestruct)scene.renderlist[i];

                        g.DrawLine(placeholder.p, new Point(placeholder.line.lx1, placeholder.line.ly1), new Point(placeholder.line.lx2, placeholder.line.ly2));

                    }
                    else if(scene.renderlist[i].GetType() == typeof(Shape.Rectangle))
                    {
                        //its a rect
                        Scene.rectstruct placeholder = (Scene.rectstruct)scene.renderlist[i];

                        g.DrawRectangle(placeholder.p, placeholder.rect.rectx, placeholder.rect.recty, placeholder.rect.rectw, placeholder.rect.recth);
                    }
                    else if(scene.renderlist[i].GetType() == typeof(Shape.Ellipse))
                    {
                        //its an ellipse
                        Scene.ellipsstruct placeholder = (Scene.ellipsstruct)scene.renderlist[i];

                        g.DrawEllipse(placeholder.p, placeholder.ell.ellipsx, placeholder.ell.ellipsy, placeholder.ell.ellipsw, placeholder.ell.ellipsh);
                    }
                    else if(scene.renderlist[i].GetType() == typeof(Shape.Triangle))
                    {
                        //its a triangle
                        Scene.tristruct placeholder = (Scene.tristruct)scene.renderlist[i];

                        g.DrawLine(placeholder.p, new Point(placeholder.tri.trix, placeholder.tri.triy + placeholder.tri.trih), new Point(placeholder.tri.trix + (int)(placeholder.tri.triw / 2), placeholder.tri.triy));
                        g.DrawLine(placeholder.p, new Point(placeholder.tri.trix + (int)(placeholder.tri.triw / 2), placeholder.tri.triy), new Point(placeholder.tri.trix + placeholder.tri.triw, placeholder.tri.triy + placeholder.tri.trih));
                        g.DrawLine(placeholder.p, new Point(placeholder.tri.trix, placeholder.tri.triy + placeholder.tri.trih), new Point(placeholder.tri.trix + placeholder.tri.triw, placeholder.tri.triy + placeholder.tri.trih));
                    }
                    /*
                    THE FOLLOWING WAS INVALIDATED AFTER MODIFYING THE SCENE CLASS
                    if (scene.spritelist[i] != null)
                    {
                        g.DrawImage(scene.spritelist[i].currentframe, new Rectangle(scene.spritelist[i].spritex, scene.spritelist[i].spritey, scene.spritelist[i].spritewidth, scene.spritelist[i].spriteheight));
                    }
                    if (scene.proplist[i] != null)
                    {
                        g.DrawImage(scene.proplist[i].propsource, new Rectangle(scene.proplist[i].propx, scene.proplist[i].propy, scene.proplist[i].propwidth, scene.proplist[i].propheight));
                    }
                    if (scene.linelist[i].p != null && scene.linelist[i].line != null)
                    {
                        g.DrawLine(scene.linelist[i].p, new Point(scene.linelist[i].line.lx1, scene.linelist[i].line.ly1), new Point(scene.linelist[i].line.lx2, scene.linelist[i].line.ly2));
                    }
                    if (scene.rectlist[i].p != null && scene.rectlist[i].rect != null)
                    {
                        g.DrawRectangle(scene.rectlist[i].p, scene.rectlist[i].rect.rectx, scene.rectlist[i].rect.recty, scene.rectlist[i].rect.rectw, scene.rectlist[i].rect.recth);
                    }
                    if (scene.ellipslist[i].p != null && scene.ellipslist[i].ell != null)
                    {
                        g.DrawEllipse(scene.ellipslist[i].p, scene.ellipslist[i].ell.ellipsx, scene.ellipslist[i].ell.ellipsy, scene.ellipslist[i].ell.ellipsw, scene.ellipslist[i].ell.ellipsh);
                    }
                    if (scene.trilist[i].p != null && scene.trilist[i].tri != null)
                    {
                        g.DrawLine(scene.trilist[i].p, new Point(scene.trilist[i].tri.trix, scene.trilist[i].tri.triy + scene.trilist[i].tri.trih), new Point(scene.trilist[i].tri.trix + (int)(scene.trilist[i].tri.triw / 2), scene.trilist[i].tri.triy));
                        g.DrawLine(scene.trilist[i].p, new Point(scene.trilist[i].tri.trix + (int)(scene.trilist[i].tri.triw / 2), scene.trilist[i].tri.triy), new Point(scene.trilist[i].tri.trix + scene.trilist[i].tri.triw, scene.trilist[i].tri.triy + scene.trilist[i].tri.trih));
                        g.DrawLine(scene.trilist[i].p, new Point(scene.trilist[i].tri.trix, scene.trilist[i].tri.triy + scene.trilist[i].tri.trih), new Point(scene.trilist[i].tri.trix + scene.trilist[i].tri.triw, scene.trilist[i].tri.triy + scene.trilist[i].tri.trih));
                    }
                    if (scene.textlist[i] != null)
                    {
                        g.DrawString(scene.textlist[i].textcontent, scene.textlist[i].stringfont, scene.textlist[i].stringbrush, (float)scene.textlist[i].textx, (float)scene.textlist[i].texty);
                    }
                    //ui rendering happens down here
                    */
                }
                else
                {
                    break;
                }
            }
        }

        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //clear draw buffer
            scene.cleanRenderBuffer();
            //refill draw buffer
            
            update();
            //render draw buffer
            shouldRender = true;
            
        }

        public void runGame()
        {
            Thread windowthread = new Thread(windowRender);
            threadRunning = true;
            windowthread.Start();
        }

        public void windowRender()
        {
            if(!windowOpened)
            {
                window.gamewindow.Show();
                window.gamewindow.Refresh();
                window.gamewindow.SuspendLayout();
                window.gamewindow.ResumeLayout();
            }
            while (threadRunning)
            {
                Application.DoEvents();
                if(shouldRender)
                {
                    window.gamewindow.Refresh();
                    shouldRender = false;
                }
            }
        }

    }
}
