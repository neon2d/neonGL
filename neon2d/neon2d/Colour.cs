using System.Drawing;

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

        /// <summary>
        /// Black colour. A = 255, R = 255, G = 216, B = 0
        /// </summary>
        public static readonly Colour YELLOW = new Colour(0xFFFD800);

        private long _a;
        /// <summary>
        /// The alpha component of this colour.
        /// Integer (32 Bit). Should be between 0 and 255
        /// </summary>
        public int a
        {
            get
            {
                return (int)_a;
            }
            set
            {
                _a = value;
            }
        }


        /// <summary>
        /// The red component of this colour
        /// Integer (32 Bit). Should be between 0 and 255
        /// </summary>
        public int r;

        /// <summary>
        /// The green component of this colour
        /// Integer (32 Bit). Should be between 0 and 255
        /// </summary>
        public int g;

        /// <summary>
        /// The blue componenet of this colour
        /// Integer (32 Bit). Should be between 0 and 255
        /// </summary>
        public int b;

        /// <summary>
        /// Creates a new ARGB colour.
        /// </summary>
        /// <param name="a">Alpha Compnent. Integer (32 bit). Between 0 and 225.</param>
        /// <param name="r">Red Compnent. Integer (32 bit). Between 0 and 225.</param>
        /// <param name="g">Green Compnent. Integer (32 bit). Between 0 and 225.</param>
        /// <param name="b">Blue Compnent. Integer (32 bit). Between 0 and 225.</param>
        public Colour(int a, int r, int g, int b)
        {
            this._a = a;
            this.r = r;
            this.r = g;
            this.r = b;
        }

        /// <summary>
        /// Takes in a hexidecimal colour and assigns the A, R, G and B components
        /// based of the colour.
        /// </summary>
        /// <param name="argb">Hexidecimal colour. Should be in the form 0xAARRGGBB</param>
        public Colour(uint argb)
        {
            this._a = (argb & 0xFF000000) >> 24;
            this.r = (int)(argb & 0x00FF0000) >> 16;
            this.g = (int)(argb & 0x0000FF00) >> 8;
            this.b = (int)(argb & 0x000000FF);
        }

        /// <summary>
        /// Takes in a hexidecimal colour in the format 0xRRGGBB and sets the A, R, G and B components. 
        /// Alpha is assumed to be full (255).
        /// </summary>
        /// <param name="rgb">Hexidecimal colour in the format 0xFFGGBB</param>
        public Colour(int rgb)
        {
            this._a = 255;
            this.r = (int)(rgb & 0xFF0000) >> 16;
            this.g = (int)(rgb & 0x00FF00) >> 8;
            this.b = (int)(rgb & 0x0000FF);
        }

        /// <summary>
        /// Converts the R, G, B components into a 32 bit integer;
        /// </summary>
        /// <returns>int (32 bit)</returns>
        public int getRGB()
        {
            return ((this.r & 0xFF) << 16) + ((this.g & 0xFF) << 8) + (this.b & 0xFF);
        }

        /// <summary>
        /// Converts the A, R, G, B components into a 32 bit integer. [BROKEN]
        /// </summary>
        /// <returns>int (32 bit)</returns>
        public int getARGB()
        {
            return +((this.r & 0xFF) << 16) + ((this.g & 0xFF) << 8) + (this.b & 0xFF);
        }

        /// <summary>
        /// Returns a string representation of this colour
        /// In the format: "Alpha: [A] Red: [R] Green [G] Blue [B] [Newline] Hexidecimal: #AARRGGBB"
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string rgb = "Alpha: " + (int)this._a + " Red: " + this.r + " Green: " + this.g + " Blue: " + this.b;
            string hex = "Hexidecimal: (RGB) #" + string.Format("{0:X}", getRGB()) + "\nHexidecimal: (ARGB) #" + string.Format("{0:X}", getARGB());
            return rgb + "\n" + hex;
        }

        public Color toSysColor()
        {
            return Color.FromArgb(a, r, g, b);
        }

        public Brush toSysBrush()
        {
            return new SolidBrush(toSysColor());
        }
    }

    public static class ColourUtils
    {
        public static Colour toNeonColour(this Color sysColor)
        {
            return new Colour(sysColor.A, sysColor.R, sysColor.G, sysColor.B);
        }
    }

}
