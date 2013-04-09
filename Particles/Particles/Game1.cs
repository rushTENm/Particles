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

        Texture2D fire;
        int fireFrameCounter = 0;
        Vector2 firePosition = new Vector2(500, 350);
        int fireWaitCounter = 0;
   
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            particleComponent = new ParticleComponent(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            particleComponent.LoadContent(Content);
            fire = Content.Load<Texture2D>("fire");
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
            particleComponent.Update(gameTime);

            if (fireWaitCounter % 2 == 0)
            {
                if (fireFrameCounter > 14)
                {
                    fireFrameCounter = 0;
                    fireWaitCounter = 0;
                }
                fireFrameCounter++;
            }
            fireWaitCounter++;
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            particleComponent.Draw(spriteBatch);

            var width = fire.Width / 4;
            var height = fire.Height / 4;

            var row = fireFrameCounter / 4;
            var column = fireFrameCounter % 4;

            spriteBatch.Begin();

            spriteBatch.Draw(fire, firePosition, new Rectangle(column * width, row * height, width, height), Color.White, 0.0f, Vector2.Zero, 1.5f, SpriteEffects.FlipHorizontally, 0);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
