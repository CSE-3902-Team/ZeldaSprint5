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
            sourceRect = new Rectangle(542, 0, 34, 56);
        }

        public void draw()
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 34, 56);
            frame++;
            if (frame <= 40)
            {
                sourceRect = new Rectangle(542, 0, 34, 56);
            }
            else if (frame > 40)
            {
                sourceRect = new Rectangle(542, 0, 34, 56);
            }
            else if (frame > 80)
            {
                frame = 1;
            }

            batch.Begin();
            batch.Draw(
                 texture,
                 destinationRectangle,
                 sourceRect,
                Color.White,
                0f,
                new Vector2(sourceRect.Width / 2, sourceRect.Height / 2),
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


    

