using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using neon2d;
using neon2d.Math;

namespace neon2d
{
    public class ParticleSystem
    {
        public float left;
        public float right;
        public float up;
        public float down;
        public int speed;

        public object[] particles = new object[999999];
        public int particleCt = 0;

        public ParticleSystem(float leftStrength, float rightStrength, float upStrenght, float downStrength, int movementspeed = 3)
        {
            left = leftStrength;
            right = rightStrength;
            up = upStrenght;
            down = downStrength;
            speed = movementspeed;
        }
        public ParticleSystem(Vector2f horizontalStrength, Vector2f verticalStrength, int movementspeed = 3)
        {
            left = horizontalStrength.x;
            right = horizontalStrength.y;
            up = verticalStrength.x;
            down = verticalStrength.y;
            speed = movementspeed;
        }

        public struct ParticleStruct
        {
            public Object particleSource;
            public int x;
            public int y;
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

        //movement and rendering
        public void step()
        {
            for(int i = 0; i <= particleCt--; i++)
            {
                if(particles[i].GetType() == typeof(ParticleStruct))
                {
                    ParticleStruct placeholder = (ParticleStruct)particles[i];
                    //move everything (based on max speed and strength)
                    if(this.left != 0)
                    {
                        placeholder.x -= Convert.ToInt32(speed / left);
                    }
                    if(this.right != 0)
                    {
                        placeholder.x += Convert.ToInt32(speed / right);
                    }
                    if(this.up != 0)
                    {
                        placeholder.y -= Convert.ToInt32(speed / up);
                    }
                    if(this.down != 0)
                    {
                        placeholder.y -= Convert.ToInt32(speed / down);
                    }
                    //save back changes
                    particles[i] = placeholder;
                }
            }
        }

    }
}
