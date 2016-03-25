namespace neon2d.Math
{
    /// <summary>
    /// A two dimensional vector with integer components (X and Y).
    /// </summary>
    public class Vector2i
    {
        /// <summary>
        /// X component of this Vector. Integer.
        /// </summary>
        public int x;

        /// <summary>
        /// Y component Of this vector. Integer.
        /// </summary>
        public int y;

        /// <summary>
        /// Creates an empty Vector2i object and sets x and y to zero.
        /// </summary>
        public Vector2i()
        {
            this.x = 0;
            this.y = 0;
        }

        /// <summary>
        /// Creates an Vector2i setting x to the x parameter  and y to the y parameter .
        /// </summary>
        /// <param name="x">Value of the x component</param>
        /// <param name="y">Value of the y component</param>
        public Vector2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Calcuates the sum of this Vector2i object and the right hand vector.
        /// </summary>
        /// <param name="vector">The right hand vector.</param>
        /// <returns>This. A copy of the left hand vector.</returns>
        public Vector2i add(Vector2i vector)
        {
            this.x += vector.x;
            this.y += vector.y;
            return this;
        }

        /// <summary>
        /// Calculates the difference between this Vector2i object and the right hand vector.
        /// </summary>
        /// <param name="vector">The right hand vector.</param>
        /// <returns>This. A copy of the left hand vector.</returns>
        public Vector2i subtract(Vector2i vector)
        {
            this.x -= vector.x;
            this.y -= vector.y;
            return this;
        }

        /// <summary>
        /// Calculates the product between this Vector2i object and the right hand vector.
        /// </summary>
        /// <param name="vector">The right hand vector.</param>
        /// <returns>This. A Copy of the left hand vector.</returns>
        public Vector2i multiply(Vector2i vector)
        {
            this.x *= vector.x;
            this.y *= vector.y;
            return this;
        }

        /// <summary>
        /// Calculates the quotient of this Vector2i object and the right hand vector.
        /// </summary>
        /// <param name="vector">The right hand vector.</param>
        /// <returns>This. A copy of the left hand vector.</returns>
        public Vector2i divide(Vector2i vector)
        {
            this.x /= vector.x;
            this.y /= vector.y;
            return this;
        }

        public static Vector2i operator+(Vector2i a, Vector2i b)
        {
            return a.add(b);
        }

        public static Vector2i operator-(Vector2i a, Vector2i b)
        {
            return a.subtract(b);
        }

        public static Vector2i operator*(Vector2i a, Vector2i b)
        {
            return a.multiply(b);
        }

        public static Vector2i operator/(Vector2i a, Vector2i b)
        {
            return a.divide(b);
        }

        /// <summary>
        /// Returns the x and y components in the format "[x], [y]". 
        /// </summary>
        /// <returns>Returns a string representation of this vector.</returns>
        public override string ToString()
        {
            return this.x + ", " + this.y;
        }
    }

    /// <summary>
    /// A two dimensional vector with float components (X and Y).
    /// </summary>
    public class Vector2f
    {
        /// <summary>
        /// The x component of this vector.
        /// </summary>
        public float x;
        
        /// <summary>
        /// The y component of this vector.
        /// </summary>
        public float y;

        /// <summary>
        /// Creates an empty Vector2f object and initalises the X and Y components to zero.
        /// </summary>
        public Vector2f()
        {
            this.x = 0f;
            this.y = 0f;
        }

        /// <summary>
        /// Creates a Vecto2f object and initalizes the X and Y components to the x and y parameters.
        /// </summary>
        /// <param name="x">The x component of this vector.</param>
        /// <param name="y">The y component of this vector.</param>
        public Vector2f(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Calcuates the sum of this Vector2f object and the right hand vector.
        /// </summary>
        /// <param name="vector">The right hand vector.</param>
        /// <returns>This. A copy of the left hand vector.</returns>
        public Vector2f add(Vector2f other)
        {
            this.x += other.x;
            this.y += other.y;
            return this;
        }

        /// <summary>
        /// Calculates the difference between this Vector2i object and the right hand vector.
        /// </summary>
        /// <param name="vector">The right hand vector.</param>
        /// <returns>This. A copy of the left hand vector.</returns>
        public Vector2f subtract(Vector2f other)
        {
            this.x -= other.x;
            this.y -= other.y;
            return this;
        }

        /// <summary>
        /// Calculates the product of this Vector2i object and the right hand vector.
        /// </summary>
        /// <param name="vector">The right hand vector.</param>
        /// <returns>This. A copy of the left hand vector.</returns>
        public Vector2f multiply(Vector2f other)
        {
            this.x *= other.x;
            this.y *= other.y;
            return this;
        }

        /// <summary>
        /// Calculates the quotient of this Vector2i object and the right hand vector.
        /// </summary>
        /// <param name="vector">The right hand vector.</param>
        /// <returns>This. A copy of the left hand vector.</returns>
        public Vector2f divide(Vector2f other)
        {
            this.x /= other.x;
            this.y /= other.y;
            return this;
        }

        public static Vector2f operator+(Vector2f a, Vector2f b)
        {
            return a.add(b);
        }

        public static Vector2f operator-(Vector2f a, Vector2f b)
        {
            return a.subtract(b);
        }

        public static Vector2f operator*(Vector2f a, Vector2f b)
        {
            return a.multiply(b);
        }

        public static Vector2f operator/(Vector2f a, Vector2f b)
        {
            return a.divide(b);
        }

        /// <summary>
        /// Returns the x and y components in the format "[x], [y]". 
        /// </summary>
        /// <returns>Returns a string representation of this vector.</returns>
        public override string ToString()
        {
            return x + ", " + y;
        }
    }
}
