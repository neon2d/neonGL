using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using neon2d;

namespace n2dPong
{
    class Pong
    {
        private Window window;
        private Scene scene;

        private Shape.Rectangle player;

        public Pong()
        {
            window = new Window(640, 480, "Pong");
            scene = new Scene(window);
            Game game = new Game(window, scene, new Action(OnUpdate));

            OnStart();
            
            game.runGame();
        }

        private void OnStart()
        {
            player = new Shape.Rectangle(10, 10, 25, 150);
        }

        private void OnUpdate()
        {
            scene.render(player, 1, Brushes.White);
        }

        static void Main(string[] args)
        {
            new Pong();
        }
    }
}
