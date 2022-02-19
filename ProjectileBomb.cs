using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class ProjectileBomb : IProjectile
    {
        private Vector2 position;
        private Vector2 direction;

        private Rectangle sourceRect;
        private Rectangle destinationRect;
        private Texture2D texture;
        private SpriteBatch batch;

        private int frame;
        private float rotation;
        private Boolean isRunning;

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
        public Boolean IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }

        public ProjectileBomb(Texture2D texture, SpriteBatch batch, Vector2 position, Vector2 direction)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.direction = direction;

            sourceRect = new Rectangle(276, 192, 14, 25);

            frame = 0;
            isRunning = true;
            rotation = 0f;
        }

        public void Update()
        {
            destinationRect = new Rectangle((int)position.X, (int)position.Y, 20, 30);
            frame++;
            if (frame < 20)
            {
                IsRunning = true;
                sourceRect = new Rectangle(193, 276, 14, 24);
            }
            else if (frame >= 20 && frame < 22)
            {
                sourceRect = new Rectangle(206, 277, 24, 24);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 40, 40);
            }
            else if (frame >= 22 && frame < 24)
            {
                sourceRect = new Rectangle(232, 276, 24, 24);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 40, 40);
            }
            else if (frame >= 24 && frame < 26)
            {
                sourceRect = new Rectangle(259, 276, 24, 24);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 40, 40);
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


    

