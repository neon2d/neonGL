using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace neon2d
{
    public class Window
    {

        public Form gamewindow;

        public Window(int width, int height, string title, bool fullscreen = false)
        {
            gamewindow = new Form();
            gamewindow.Width = width;
            gamewindow.Height = height;
            gamewindow.Text = title;
            gamewindow.BackColor = Color.Black;

            if (fullscreen)
            {
                gamewindow.WindowState = FormWindowState.Maximized;
                gamewindow.FormBorderStyle = FormBorderStyle.None;
            }

            SetDoubleBuffered(gamewindow);
        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            //thanks to stack overflow for this one
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

    }
}
