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
        private Texture2D texture;
        private SpriteBatch batch;
        private int frame;
        private Rectangle sourceRect;
        private float rotation;

        public ProjectileNormalArrow(Texture2D texture, SpriteBatch batch, Vector2 position)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            frame = 1;
            rotation = 0f;
            sourceRect = new Rectangle(14, 282, 26, 14);
        }

        public void draw(Vector2 position, int x, int y)
        {
            Rectangle destinationRect = new Rectangle((int)position.X, (int)position.Y, 26, 14);
            frame++;

            if(frame < 1000)
            {
                if (x == 0 && y > 0)
                {
                    rotation = (float)Math.PI * 3f / 2f;
                    position.Y += 1;
                }
                else if (x == 0 && y < 0)
                {
                    rotation = (float)Math.PI / 2f;
                    position.Y -= 1;
                }
                else if (x > 0 && y == 0)
                {
                    rotation = 0f;
                    position.X += 1;
                }
                else if (x < 0 && y == 0)
                {
                    rotation = (float)Math.PI;
                    position.X -= 1;
                }
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
