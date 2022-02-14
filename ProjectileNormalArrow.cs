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

        public void draw(int x, int y)
        {
            Rectangle destinationRect = new Rectangle((int)position.X, (int)position.Y, 26, 14);
            frame++;
            float direction = 1f;
            
            if (x == 0 && y > 0)
            {
                rotation = (float)Math.PI * 3f / 2f;
                direction = -1f;
            }
            else if (x == 0 && y < 0)
            {
                rotation = (float)Math.PI / 2f;
                direction = 1f;
            }
            else if (x > 0 && y == 0)
            {
                rotation = 0f;
                direction = 1f;
            }
            else if (x < 0 && y == 0)
            {
                rotation = (float)Math.PI;
                direction = -1f;
            }

            if (y == 0)
            {
                if (frame < 10)
                {
                    position.X += direction * 2f;
                }else if (frame >= 10 && frame < 20)
                {
                    position.X += direction * 2f;
                }
                else if (frame >= 20 && frame < 30)
                {
                    position.X += direction * 2f;
                }
                else if (frame >= 30 && frame < 40)
                {
                    position.X += direction * 2f;
                }
                else if (frame >= 40 && frame < 50)
                {
                    position.X += direction * 2f;
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

            }

            if (x == 0)
            {
                if (frame < 10)
                {
                    position.Y += direction * 2f;
                }
                else if (frame >= 10 && frame < 20)
                {
                    position.Y += direction * 2f;
                }
                else if (frame >= 20 && frame < 30)
                {
                    position.Y += direction * 2f;
                }
                else if (frame >= 30 && frame < 40)
                {
                    position.Y += direction * 2f;
                }
                else if (frame >= 40 && frame < 50)
                {
                    position.Y += direction * 2f;
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
