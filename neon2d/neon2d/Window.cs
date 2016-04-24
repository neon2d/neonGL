using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using System.Drawing;

namespace neon2d
{
    public class Window
    {
        public GameWindow gamewindow;

        public Window(int width, int height, string title, bool fullscreen = false)
        {
            gamewindow = new GameWindow(width, height, OpenTK.Graphics.GraphicsMode.Default, title);
            
            if(fullscreen)
            {
                gamewindow.WindowState = WindowState.Fullscreen;
            }
        }

    }
}
