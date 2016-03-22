using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neon2d
{
    /// <summary>
    /// Represents a colour with Alpha, Red, Green and Blue components.
    /// </summary>
    public class Colour
    {
        /// <summary>
        /// Red colour. A = 255, R = 255, G = 0, B = 0
        /// </summary>
        public static readonly Colour RED = new Colour(0xFFFF0000);

        /// <summary>
        /// Green colour. A = 255, R = 0, G = 255, B = 0
        /// </summary>
        public static readonly Colour GREEN = new Colour(0xFF00FF00);

        /// <summary>
        /// Blue Colour. A = 255, R = 0, G = 0, B = 255
        /// </summary>
        public static readonly Colour BLUE = new Colour(0xFF0000FF);

        /// <summary>
        /// White colour. A = 255, R = 255, G = 255, B = 255
        /// </summary>
        public static readonly Colour WHITE = new Colour(0xFFFFFFFF);

        /// <summary>
        /// Black colour. A = 255, R = 0, G = 0, B = 0
        /// </summary>
        public static readonly Colour BLACK = new Colour(0xFF000000);
        
        private long _A;
        
        /// <summary>
        /// The alpha component of this colour.
        /// Integer (32 Bit). Should be between 0 and 255
        /// </summary>
        public int A
        {
            get
            {
                return (int)_A;
            }
            set
            {
                _A = value;
            }
        }

        /// <summary>
        /// The red component of this colour
        /// Integer (32 Bit). Should be between 0 and 255
        /// </summary>
        public int R;

        /// <summary>
        /// The green component of this colour
        /// Integer (32 Bit). Should be between 0 and 255
        /// </summary>
        public int G;

        /// <summary>
        /// The blue componenet of this colour
        /// Integer (32 Bit). Should be between 0 and 255
        /// </summary>
        public int B;

        /// <summary>
        /// Creates a new ARGB colour.
        /// </summary>
        /// <param name="a">Alpha Compnent. Integer (32 bit). Between 0 and 225.</param>
        /// <param name="r">Red Compnent. Integer (32 bit). Between 0 and 225.</param>
        /// <param name="g">Green Compnent. Integer (32 bit). Between 0 and 225.</param>
        /// <param name="b">Blue Compnent. Integer (32 bit). Between 0 and 225.</param>
        public Colour(int a, int r, int g, int b)
        {
            this._A = a;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        /// <summary>
        /// Takes in a hexidecimal colour and assigns the A, R, G and B components
        /// based of the colour.
        /// </summary>
        /// <param name="argb">Hexidecimal colour. Should be in the form 0xAARRGGBB</param>
        public Colour(uint argb)
        {
            this._A = (argb & 0xFF000000) >> 24;
            this.R = (int)(argb & 0x00FF0000) >> 16;
            this.G = (int)(argb & 0x0000FF00) >> 8;
            this.B = (int)(argb & 0x000000FF);
        }
        
        /// <summary>
        /// Converts the R, G, B components into a 32 bit integer;
        /// </summary>
        /// <returns>int (32 bit)</returns>
        public int getRGB()
        {
            return ((this.R & 0xFF) << 16) + ((this.G & 0xFF) << 8) + (this.B & 0xFF);
        }

        /// <summary>
        /// Converts the A, R, G, B components into a 32 bit integer.
        /// </summary>
        /// <returns>int (32 bit)</returns>
        public int getARGB()
        {
            return (((int)this._A & 0xFF) << 24) + ((this.R & 0xFF) << 16) + ((this.G & 0xFF) << 8) + (this.B & 0xFF);
        }

        /// <summary>
        /// Returns a string representation of this colour
        /// In the format: "Alpha: [A] Red: [R] Green [G] Blue [B] [Newline] Hexidecimal: #AARRGGBB"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string rgb = "Alpha: " + (int)this._A + " Red: " + this.R + " Green: " + this.G + " Blue: " + this.B;
            string hex = "Hexidecimal: #" + string.Format("{0:X}", getARGB());
            return rgb + "\n" + hex;
        }
    }
}
