using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class ProjectileNormalArrow : IProjectile
    {
        private Vector2 position;
        private Vector2 direction;

        private Texture2D texture;
        private SpriteBatch batch;
        private Rectangle sourceRect;
        private Rectangle destinationRect;

        private int frame;
        private float rotation;
        private Boolean isRunning;

        public Boolean IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }

        public Vector2 Position
        {
            get;
            set;
        }

        //Vector direction should only use 0, 1, -1
        public ProjectileNormalArrow(Texture2D texture, SpriteBatch batch, Vector2 position, Vector2 direction)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.direction = direction;

            sourceRect = new Rectangle(14, 282, 26, 14);

            rotation = 0f;
            isRunning = false;
            frame = 1;
            
        }

        public void Update()
        {
            destinationRect = new Rectangle((int)position.X, (int)position.Y, 26, 14);
            GetRotation(direction);
            frame++;

            if (frame < 50)
            {
                IsRunning = true;
                position.X += direction.X * 3f;
                position.Y += direction.Y * 3f;
                
            }
            else if (frame >= 50 && frame < 60)
            {
                sourceRect = new Rectangle(176, 280, 15, 20);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 15, 20);
            }
            else
            {
                IsRunning = false;
                sourceRect = new Rectangle(400, 400, 0, 0);
            }
        }

        public void GetRotation(Vector2 direction)
        {
            if (direction.X == 0 && direction.Y > 0)
            {
                rotation = (float)Math.PI * 3f / 2f;
            }
            else if (direction.X == 0 && direction.Y < 0)
            {
                rotation = (float)Math.PI / 2f;
            }
            else if (direction.X > 0 && direction.Y == 0)
            {
                rotation = 0f;
            }
            else if (direction.X < 0 && direction.Y == 0)
            {
                rotation = (float)Math.PI;
            }
        }
        public void Draw()
        { 
            batch.Begin();
            batch.Draw(
                 texture,
                 destinationRect,
                 sourceRect,
                Color.White,
                rotation,
                new Vector2(sourceRect.Width / 2, sourceRect.Height / 2),
                SpriteEffects.None,
                0f
                );
            batch.End();
        }

    }
}
