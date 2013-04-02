using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Particles
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ParticleComponent particleComponent;

        Random random;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            graphics.ApplyChanges();

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            random = new Random();

            particleComponent = new ParticleComponent(this);
            this.Components.Add(particleComponent);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Emitter fireEmitter = new Emitter();
            fireEmitter.Active = true;
            fireEmitter.TextureList.Add(Content.Load<Texture2D>("fire"));
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
            smokeEmitter.TextureList.Add(Content.Load<Texture2D>("smoke"));
            smokeEmitter.RandomEmissionInterval = new RandomMinMax(45);
            smokeEmitter.ParticleLifeTime = 1350;
            smokeEmitter.ParticleDirection = new RandomMinMax(-15, 15);
            smokeEmitter.ParticleSpeed = new RandomMinMax(4.5f);
            smokeEmitter.ParticleRotation = new RandomMinMax(0);
            smokeEmitter.RotationSpeed = new RandomMinMax(-0.008f, 0.008f);
            smokeEmitter.ParticleFader = new ParticleFader(true, true);
            smokeEmitter.ParticleScaler = new ParticleScaler(0.2f, 1.2f, 50, smokeEmitter.ParticleLifeTime);
            smokeEmitter.Position = new Vector2(640, 550);

            particleComponent.particleEmitterList.Add(fireEmitter);
            particleComponent.particleEmitterList.Add(smokeEmitter);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
