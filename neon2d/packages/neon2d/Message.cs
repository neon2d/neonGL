using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neon2d
{
    public static class Message
    {

        public static void neonError(string msg)
        {
            //neonError is intended for error reporting within neon2d
            //for easy to use dialogs, use Message.send
            MessageBox.Show(msg, "neon2d has encountered an error");
        }
        
        public static void send(string msg, string caption = "")
        {
            MessageBox.Show(msg, caption);
        }

        public static void log(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}
