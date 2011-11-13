using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoMaze
{
    public class RunningStar
    {
        private const int size = 64;

        private readonly Random random = new Random();
        
        private Texture2D texture;
        private Vector2 position;
        private Vector2 speed;
        private float dx;
        private float rotation;

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("starfish");
        }

        public void Update(GameTime gameTime)
        {
            switch (random.Next(3))
            {
                case 1: speed = new Vector2(0, 0); break;
                case 2: speed = new Vector2(0, 0); break;
                default: speed = new Vector2(0, 0); break;
            }
            /*
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

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                moveForward = true;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                moveForward = false;
             */
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
            spriteBatch.Draw(texture, Vector2.Zero, Color.White);
            //spriteBatch.Draw(starfishTexture, position + new Vector2(dx, 0), null, Color.White, rotation, new Vector2(64, 64), 0.5f, SpriteEffects.None, 0);
            spriteBatch.End();
        }

        private bool IsMoveCompleted()
        {
            return false;
        }
    }
}