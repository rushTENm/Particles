using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Particles
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class ParticleComponent : IGameComponent
    {
        public List<Emitter> particleEmitterList;

        public ParticleComponent(Game1 game)
        {
            // TODO: Construct any child components here
            game.Components.Add(this);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public void Initialize()
        {
            particleEmitterList = new List<Emitter>();
        }

        public void LoadContent(ContentManager content)
        {
            Emitter fireEmitter = new Emitter();
            fireEmitter.Active = true;
            fireEmitter.TextureList.Add(content.Load<Texture2D>("fire"));
            fireEmitter.RandomEmissionInterval = new RandomMinMax(330);
            fireEmitter.ParticleLifeTime = 1350;
            fireEmitter.ParticleDirection = new RandomMinMax(0);
            fireEmitter.ParticleSpeed = new RandomMinMax(1f);
            fireEmitter.ParticleRotation = new RandomMinMax(0);
            fireEmitter.RotationSpeed = new RandomMinMax(0);
            fireEmitter.ParticleFader = new ParticleFader(true, true, 0);
            fireEmitter.ParticleScaler = new ParticleScaler(0.8f, 1f, 0, 1000);
            fireEmitter.Position = new Vector2(640, 600);

            Emitter smokeEmitter = new Emitter();
            smokeEmitter.Active = true;
            smokeEmitter.TextureList.Add(content.Load<Texture2D>("smoke"));
            smokeEmitter.RandomEmissionInterval = new RandomMinMax(45);
            smokeEmitter.ParticleLifeTime = 1350;
            smokeEmitter.ParticleDirection = new RandomMinMax(-15, 15);
            smokeEmitter.ParticleSpeed = new RandomMinMax(4.5f);
            smokeEmitter.ParticleRotation = new RandomMinMax(0);
            smokeEmitter.RotationSpeed = new RandomMinMax(-0.008f, 0.008f);
            smokeEmitter.ParticleFader = new ParticleFader(true, true);
            smokeEmitter.ParticleScaler = new ParticleScaler(0.2f, 1.2f, 50, smokeEmitter.ParticleLifeTime);
            smokeEmitter.Position = new Vector2(640, 550);

            particleEmitterList.Add(fireEmitter);
            particleEmitterList.Add(smokeEmitter);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            foreach (Emitter emitter in particleEmitterList)
            {
                emitter.UpdateParticles(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (Emitter emitter in particleEmitterList)
            {
                emitter.DrawParticles(spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
