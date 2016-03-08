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
                        
                        g.DrawImage(placeholder.currentFrame, new Rectangle(placeholder.spriteX, placeholder.spriteY, placeholder.spriteWidth, placeholder.spriteHeight));
                    }
                    else if(scene.renderlist[i].GetType() == typeof(Prop))
                    {
                        //its a prop
                        Prop placeholder = (Prop)scene.renderlist[i];

                        g.DrawImage(placeholder.propSource, new Rectangle(placeholder.propX, placeholder.propY, placeholder.propWidth, placeholder.propHeight));
                    }
                    else if(scene.renderlist[i].GetType() == typeof(Scene.TextStruct))
                    {
                        //its text
                        Scene.TextStruct placeholder = (Scene.TextStruct)scene.renderlist[i];

                        g.DrawString(placeholder.stringtext, placeholder.stringfont, placeholder.stringcolor, placeholder._x, placeholder._y);
                    }
                    else if(scene.renderlist[i].GetType() == typeof(Scene.LineStruct))
                    {
                        //its a line
                        Scene.LineStruct placeholder = (Scene.LineStruct)scene.renderlist[i];

                        g.DrawLine(placeholder.p, new Point(placeholder.line.lx1, placeholder.line.ly1), new Point(placeholder.line.lx2, placeholder.line.ly2));

                    }
                    else if(scene.renderlist[i].GetType() == typeof(Scene.RectStruct))
                    {
                        //its a rect
                        Scene.RectStruct placeholder = (Scene.RectStruct)scene.renderlist[i];

                        g.DrawRectangle(placeholder.p, placeholder.rect.rectx, placeholder.rect.recty, placeholder.rect.rectw, placeholder.rect.recth);
                    }
                    else if(scene.renderlist[i].GetType() == typeof(Scene.EllipsStruct))
                    {
                        //its an ellipse
                        Scene.EllipsStruct placeholder = (Scene.EllipsStruct)scene.renderlist[i];

                        g.DrawEllipse(placeholder.p, placeholder.ell.ellipsx, placeholder.ell.ellipsy, placeholder.ell.ellipsw, placeholder.ell.ellipsh);
                    }
                    else if(scene.renderlist[i].GetType() == typeof(Scene.TriStruct))
                    {
                        //its a triangle
                        Scene.TriStruct placeholder = (Scene.TriStruct)scene.renderlist[i];

                        g.DrawLine(placeholder.p, new Point(placeholder.tri.trix, placeholder.tri.triy + placeholder.tri.trih), new Point(placeholder.tri.trix + (int)(placeholder.tri.triw / 2), placeholder.tri.triy));
                        g.DrawLine(placeholder.p, new Point(placeholder.tri.trix + (int)(placeholder.tri.triw / 2), placeholder.tri.triy), new Point(placeholder.tri.trix + placeholder.tri.triw, placeholder.tri.triy + placeholder.tri.trih));
                        g.DrawLine(placeholder.p, new Point(placeholder.tri.trix, placeholder.tri.triy + placeholder.tri.trih), new Point(placeholder.tri.trix + placeholder.tri.triw, placeholder.tri.triy + placeholder.tri.trih));
                    }
                    
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
