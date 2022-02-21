using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class ProjectileFireball : IProjectile
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
            get { return position; }
            set { position = value; }
        }
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }
       
        
        //Vector direction should only use 0, 1, -1
        public ProjectileFireball(Texture2D texture, SpriteBatch batch, Vector2 position, Vector2 direction)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.direction = direction;

            sourceRect = new Rectangle(287, 276, 22, 26);

            isRunning = true;
            frame = 0;
            rotation = 0f;


        }

        public void Update()
        {
            destinationRect = new Rectangle((int)position.X, (int)position.Y, 30, 40);
            frame++;

            if (frame < 10)
            {
                position.X += direction.X * 5f;
                position.Y += direction.Y * 5f;
                
            }
            else if (frame >= 10 && frame < 12)
            {
                sourceRect = new Rectangle(283, 304, 27, 27);
            }
            else if (frame >= 12 && frame < 14)
            {
                sourceRect = new Rectangle(287, 276, 22, 26);
            }
            else if (frame >= 14 && frame < 16)
            {
                sourceRect = new Rectangle(283, 304, 27, 27);
            }
            else if (frame >= 16 && frame < 18)
            {
                sourceRect = new Rectangle(287, 276, 22, 26);
            }
            else if (frame >= 18 && frame < 20)
            {
                sourceRect = new Rectangle(283, 304, 27, 27);
            }
            else
            {
                IsRunning = false;
                sourceRect = new Rectangle(400, 400, 0, 0);
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