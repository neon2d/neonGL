using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neon2d
{
    public class BasicGame
    {
        private Game master;
        private Window window;
        protected Scene scene;

        public BasicGame(int width, int height, string title)
        {
            window = new Window(width, height, title);
            scene = new Scene(window);

            master = new Game(window, scene, new Action(onUpdate));
            onStart();
            master.runGame();
        }

        public virtual void onUpdate() { }
        public virtual void onStart() { }
    }
}
