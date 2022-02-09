using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class BombProjectile : IProjectile
    {
        private Vector2 position;
        private float speed;
        Texture2D texture;
        private SpriteBatch batch;
        private int frame;
        private Rectangle sourceRect;

        public BombProjectile(Texture2D texture, SpriteBatch batch, Vector2 position, float speed)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.speed = speed;
            this.frame = 1;
            sourceRect = new Rectangle(192, 276, 14, 25);
        }

        public void draw(Vector2 position, int x, int y)
        {
            Rectangle destinationRect = new Rectangle((int)position.X, (int)position.Y, 26, 41);
            frame++;
            if (frame <= 40)
            {
                sourceRect = new Rectangle(192, 276, 14, 25);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 14, 25);
            }
            else if (frame <= 80)
            {
                sourceRect = new Rectangle(287, 276, 22, 26);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 22, 26);
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
                (float)Math.PI,
                new Vector2(sourceRect.Width, sourceRect.Height),
                SpriteEffects.None,
                0f
                );
            batch.End();
        }


        public float Speed
        {
            get;
            set;
        }

        public Vector2 Position
        {
            get;
            set;
        }


    }
}


    

