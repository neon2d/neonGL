using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using neon2d;
using neon2d.Math;

namespace neon2d
{
    class ParticleSystem
    {


        public int x;
        public int y;

        public float left;
        public float right;
        public float up;
        public float down;
        public int speed;

        public object[] particles = new object[999999999];
        public int particleCt = 0;

        public ParticleSystem(int x, int y, float leftStrength, float rightStrength, float upStrenght, float downStrength, int movementspeed = 3)
        {

            this.x = x;
            this.y = y;

            left = leftStrength;
            right = rightStrength;
            up = upStrenght;
            down = downStrength;
            speed = movementspeed;
        }
        public ParticleSystem(int x, int y, Vector2f horizontalStrength, Vector2f verticalStrength, int movementspeed = 3)
        {

            this.x = x;
            this.y = y;

            left = horizontalStrength.x;
            right = horizontalStrength.y;
            up = verticalStrength.x;
            down = verticalStrength.y;
            speed = movementspeed;
        }

        public struct ParticleStruct
        {
            Object particleSource;
            int x;
            int y;
            public ParticleStruct(Object particleSource, int x, int y)
            {
                this.particleSource = particleSource;
                this.x = x;
                this.y = y;
            }
        }

        public void addParticle(Prop particleSource)
        {
            particles[particleCt] = new ParticleStruct(particleSource, 0, 0);
            particleCt++;
        }
        public void addParticle(Sprite particleSource)
        {
            particles[particleCt] = new ParticleStruct(particleSource, 0, 0);
            particleCt++;
        }

    }
}
