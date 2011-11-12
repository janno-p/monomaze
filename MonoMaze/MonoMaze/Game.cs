using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoMaze
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D starfishTexture;

        private float rotation;
        private float dx;
        private Vector2 position = new Vector2(100, 100);

        private bool? moveForward = null;
        private Vector2 speed = new Vector2(MathHelper.TwoPi * 32, 0);

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 500;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            Window.Title = "MonoMaze v0.1";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            starfishTexture = Content.Load<Texture2D>("starfish");
        }

        protected override void Update(GameTime gameTime)
        {
            if (moveForward.HasValue)
            {
                var direction = moveForward.Value ? 1 : -1;
                dx += (float)(gameTime.ElapsedGameTime.TotalSeconds * speed.X * direction);
                rotation += (float)(gameTime.ElapsedGameTime.TotalSeconds * MathHelper.TwoPi * direction);
            }

            if (Math.Abs(dx) >= Math.Abs(speed.X))
            {
                position.X += speed.X * (moveForward.Value ? 1 : -1);

                moveForward = null;
                dx = 0;
                rotation = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                moveForward = true;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                moveForward = false;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
            spriteBatch.Draw(starfishTexture, position + new Vector2(dx, 0), null, Color.White, rotation, new Vector2(64, 64), 0.5f, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}