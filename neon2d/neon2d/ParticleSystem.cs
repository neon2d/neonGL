using System;
using System.Collections;
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
        public int left;
        public int right;
        public int up;
        public int down;
        public int speed;
        public int maxage;

        public ArrayList particles = new ArrayList();
        public int particleCt = 0;

        //fluctuations
        public int movementFluctuation;

        public Random fluctCalc = new Random();

        public ParticleSystem(int leftStrength, int rightStrength, int upStrenght, int downStrength, int movementspeed = 3, int maxage = 5)
        {
            left = leftStrength;
            right = rightStrength;
            up = upStrenght;
            down = downStrength;
            speed = movementspeed;
            this.maxage = maxage;
        }
        public ParticleSystem(Vector2i horizontalStrength, Vector2i verticalStrength, int movementspeed = 3, int maxage = 5)
        {
            left = horizontalStrength.x;
            right = horizontalStrength.y;
            up = verticalStrength.x;
            down = verticalStrength.y;
            speed = movementspeed;
            this.maxage = maxage;
        }

        public struct ParticleStruct
        {
            public Object particleSource;
            public int x;
            public int y;
            public int age;
            public ParticleStruct(Object particleSource, int x= 0, int y= 0, int age = 0)
            {
                this.particleSource = particleSource;
                this.x = x;
                this.y = y;
                this.age = age;
            }
        }

        public void addParticle(Prop particleSource)
        {
            particles.Add(new ParticleStruct(particleSource, 0, 0));
            particleCt++;
        }
        public void addParticle(Sprite particleSource)
        {
            particles.Add(new ParticleStruct(particleSource, 0, 0));
            particleCt++;
        }

        //movement and rendering
        public void step()
        {
            for(int i = 0; i <= particles.Count - 1; i++)
            {
                if(particles[i].GetType() == typeof(ParticleStruct))
                {
                    ParticleStruct placeholder = (ParticleStruct)particles[i];
                    if (placeholder.age < maxage)
                    {
                        placeholder.age++;
                        //move everything (based on max speed and strength)
                        if (this.left != 0)
                        {
                            int offset = fluctCalc.Next(left - movementFluctuation, left + movementFluctuation);
                            placeholder.x -= offset;
                        }
                        if (this.right != 0)
                        {
                            int offset = fluctCalc.Next(right - movementFluctuation, right + movementFluctuation);
                            placeholder.x += offset;
                        }
                        if (this.up != 0)
                        {
                            int offset = fluctCalc.Next(up - movementFluctuation, up + movementFluctuation);
                            placeholder.y -= offset;
                        }
                        if (this.down != 0)
                        {
                            int offset = fluctCalc.Next(down - movementFluctuation, down + movementFluctuation);
                            placeholder.y += offset;
                        }
                        //save back changes
                        particles[i] = placeholder;
                    }
                    else
                    {
                        killParticle(placeholder);
                    }
                    Console.WriteLine(particleCt);
                }
            }
        }

        public void setFluctuation(int movementVariation = 3)
        {
            movementFluctuation = movementVariation;
        }

        public void setStrength(int leftStrength, int rightStrength, int upStrength, int downStrength)
        {
            this.left = leftStrength;
            this.right = rightStrength;
            this.up = upStrength;
            this.down = downStrength;
        }

        void killParticle(ParticleStruct particle)
        {
            particles.Remove(particle);
            particleCt--;
        }

    }
}
