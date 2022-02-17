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

        public ProjectileNormalArrow(Texture2D texture, SpriteBatch batch, Vector2 position)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            frame = 1;
            sourceRect = new Rectangle(14, 282, 26, 14);
        }

        public float GetDirection(int x, int y)
        {
            float direction = 1f;

            if (x == 0 && y > 0)
            {
                direction = -1f;
            }
            else if (x == 0 && y < 0)
            {
                direction = 1f;
            }
            else if (x > 0 && y == 0)
            {
                direction = 1f;
            }
            else if (x < 0 && y == 0)
            {
                direction = -1f;
            }

            return direction;
        }

        public float GetRotation(int x, int y)
        {
            float rotation = 0f;

            if (x == 0 && y > 0)
            {
                rotation = (float)Math.PI * 3f / 2f;
            }
            else if (x == 0 && y < 0)
            {
                rotation = (float)Math.PI / 2f;
            }
            else if (x > 0 && y == 0)
            {
                rotation = 0f;
            }
            else if (x < 0 && y == 0)
            {
                rotation = (float)Math.PI;
            }

            return rotation;
        }
        public void Draw(int x, int y)
        {
            Rectangle destinationRect = new Rectangle((int)position.X, (int)position.Y, 26, 14);
            float direction = GetDirection(x,y);
            float rotation = GetRotation(x, y);
            frame++;
            
            if (frame < 50)
            {
                if (y==0)
                {
                    position.X += direction * 3f;
                }else if (x == 0)
                {
                    position.Y += direction * 3f;
                }
            }
            else if (frame >= 50 && frame < 60)
            {
                sourceRect = new Rectangle(176, 280, 15, 20);
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 15, 20);
            }
            else
            {
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

        public Vector2 Position
        {
            get;
            set;
        }

    }
}
