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
        /// Calculates the magnitude of this vector and returns the length that has already been square rooted.
        /// </summary>
        /// <returns>The magnitude of this vector.</returns>
        public float magnitude()
        {
            float len = (x * x) + (y * y);
            return (float)System.Math.Sqrt(len);
        }

        /// <summary>
        /// Calculates the magnitude of this vector and returns the magnitude that has not been square rooted.
        /// </summary>
        /// <returns></returns>
        public float magnitudeSquared()
        {
            float len = (x * x) + (y * y);
            return len;
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

        /// <summary>
        /// Calculates the sum of vectors a and b.
        /// </summary>
        /// <param name="a">The left hand vector.</param>
        /// <param name="b">The right hand vector</param>
        /// <returns>The sum of vectors a and b</returns>
        public static Vector2i add(Vector2i a, Vector2i b)
        {
            return a.add(b);
        }

        /// <summary>
        /// Calculates the difference between vectors a and b.
        /// </summary>
        /// <param name="a">The left hand vector.</param>
        /// <param name="b">The right hand vector.</param>
        /// <returns>The difference between vectors a and b.</returns>
        public static Vector2i subtract(Vector2i a, Vector2i b)
        {
            return a.subtract(b);
        }

        /// <summary>
        /// Calculates the product of vectors a and b.
        /// </summary>
        /// <param name="a">The left hand vector.</param>
        /// <param name="b">The right hand vector.</param>
        /// <returns>The product between vectors a and b.</returns>
        public static Vector2i multiply(Vector2i a, Vector2i b)
        {
            return a.multiply(b);
        }

        /// <summary>
        /// Calculates the quotient of vectors a and b. 
        /// </summary>
        /// <param name="a">The left hand vector.</param>
        /// <param name="b">The right hand vector.</param>
        /// <returns>The quotient of vector a and b.</returns>
        public static Vector2i divide(Vector2i a, Vector2i b)
        {
            return a.divide(b);
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
        /// Calculates the magnitude of this vector and returns the length that has already been square rooted.
        /// </summary>
        /// <returns>The magnitude of this vector.</returns>
        public float magnitude()
        {
            float len = (x * x) + (y * y);
            return (float)System.Math.Sqrt(len);
        }

        public void normalize()
        {
            float len = magnitude();
            x = (x / len);
            y = (y / len);
        }

        /// <summary>
        /// Calculates the magnitude of this vector and returns the magnitude that has not been square rooted.
        /// </summary>
        /// <returns></returns>
        public float magnitudeSquared()
        {
            float len = (x * x) + (y * y);
            return len;
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

        /// <summary>
        /// Calculates the sum of vectors a and b.
        /// </summary>
        /// <param name="a">The left hand vector.</param>
        /// <param name="b">The right hand vector</param>
        /// <returns>The sum of vectors a and b</returns>
        public static Vector2f add(Vector2f a, Vector2f b)
        {
            return a.add(b);
        }

        /// <summary>
        /// Calculates the difference between vectors a and b.
        /// </summary>
        /// <param name="a">The left hand vector.</param>
        /// <param name="b">The right hand vector.</param>
        /// <returns>The difference between vectors a and b.</returns>
        public static Vector2f subtract(Vector2f a, Vector2f b)
        {
            return a.subtract(b);
        }

        /// <summary>
        /// Calculates the product of vectors a and b.
        /// </summary>
        /// <param name="a">The left hand vector.</param>
        /// <param name="b">The right hand vector.</param>
        /// <returns>The product between vectors a and b.</returns>
        public static Vector2f multiply(Vector2f a, Vector2f b)
        {
            return a.multiply(b);
        }

        /// <summary>
        /// Calculates the quotient of vectors a and b. 
        /// </summary>
        /// <param name="a">The left hand vector.</param>
        /// <param name="b">The right hand vector.</param>
        /// <returns>The quotient of vector a and b.</returns>
        public static Vector2f divide(Vector2f a, Vector2f b)
        {
            return a.divide(b);
        }

        /// <summary>
        /// Normalizes the given vector.
        /// </summary>
        /// <param name="vector">The vector to be normalized.</param>
        public static void normalize(Vector2f vector)
        {
            vector.normalize();
        }

        /// <summary>
        /// Calculates the magnitude of the given vector. (The magnitude has been square rooted).
        /// </summary>
        /// <param name="vector">The vector to calculate the magnitude of.</param>
        /// <returns>Float. The magnitude of given vector.</returns>
        public static float getMagnitude(Vector2f vector)
        {
            return vector.magnitude();
        }

        /// <summary>
        /// Calculates the magnitude of the given vector, squared. (The magnitude has not been square rooted).
        /// </summary>
        /// <param name="vector">The vector to calculate the magnitude (squared) of.</param>
        /// <returns>Float. The magnitude of the given vector.</returns>
        public static float getMagnitudeSquared(Vector2f vector)
        {
            return vector.magnitudeSquared();
        }
    }
}
