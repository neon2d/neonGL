using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using neon2d;

namespace n2d
{
    class InterfaceDemo : BasicGame
    {
        public InterfaceDemo()
            : base(800, 600, "Hello World!")
        {
        }

        public override void OnStart()
        {
        }

        public override void OnUpdate()
        {
        }

        public override void OnRender()
        {
        }

        public static void Main(string [] args)
        {
            InterfaceDemo demo = new InterfaceDemo();
        }
    }
}
