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
        private Texture2D texture;
        private SpriteBatch batch;
        private int frame;
        private int x;
        private int y;
        private Rectangle sourceRect;
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

        public ProjectileBomb(Texture2D texture, SpriteBatch batch, Vector2 position, int x, int y)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.frame = 1;
            this.x = x;
            this.y = y;
            isRunning = false;
            rotation = 0f;
            sourceRect = new Rectangle(276, 192, 14, 25);
        }

        public float GetDirection(int x, int y)
        {
            return 0f;
        }
        public void Draw()
        {
            Rectangle destinationRect = new Rectangle((int)position.X, (int)position.Y, 14, 25);
            frame++;
            if (frame < 40)
            {
                IsRunning = true;
                sourceRect = new Rectangle(193, 276, 14, 25);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 14, 25);
            }
            else if (frame >= 40 && frame < 50)
            {
                sourceRect = new Rectangle(206, 277, 24, 24);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 24, 24);
            }
            else if (frame >= 50 && frame < 60)
            {
                sourceRect = new Rectangle(232, 276, 24, 24);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 24, 24);
            }
            else if (frame >= 60 && frame < 70)
            {
                sourceRect = new Rectangle(259, 276, 24, 24);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 24, 24);
            }
            else
            {
                IsRunning = false;
                sourceRect = new Rectangle(400, 400, 0, 0);
            }

            batch.Begin();
            batch.Draw(
                 texture,  
                 destinationRect,
                 sourceRect, 
                Color.White,
                rotation,
                new Vector2(sourceRect.Width, sourceRect.Height),
                SpriteEffects.None,
                0f
                );
            batch.End();
        }
    }
}


    

