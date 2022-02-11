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
        private Rectangle sourceRect;
        private float rotation;

        public ProjectileBomb(Texture2D texture, SpriteBatch batch, Vector2 position)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.frame = 1;
            rotation = 0f;
            sourceRect = new Rectangle(276, 192, 14, 25);
        }

        public void draw(Vector2 position, int x, int y)
        {
            Rectangle destinationRect = new Rectangle((int)position.X, (int)position.Y, 14, 25);
            frame++;
            if (frame <= 40)
            {
                sourceRect = new Rectangle(193, 276, 14, 25);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 14, 25);
            }
            else if (frame <= 80)
            {
                sourceRect = new Rectangle(206, 277, 24, 24);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 24, 24);
            }
            else if (frame > 80)
            {
                frame = 1;
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

        public Vector2 Position
        {
            get;
            set;
        }


    }
}


    

