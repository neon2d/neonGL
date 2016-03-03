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

        public Sprite[] spritelist = new Sprite[999999];
        public int spritect = 0;

        public Prop[] proplist = new Prop[999999];
        public int propct = 0;

        public Text[] textlist = new Text[999999];
        public int textct = 0;

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

        public void renderSprite(Sprite render)
        {
            spritelist[spritect] = render;
            spritect++;
        }

        public void renderProp(Prop render)
        {
            proplist[propct] = render;
            propct++;
        }

        public void renderText(Text stringtext)
        {
            textlist[textct] = stringtext;
            textct++;
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
                spritelist[i] = null;
                proplist[i] = null;
            }
            spritect = 0;
            propct = 0;
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
