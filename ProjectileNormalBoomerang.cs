using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class ProjectileNormalBoomerang : IProjectile
    {
        private Vector2 position;
        private Texture2D texture;
        private SpriteBatch batch;
        private int frame;
        private int x;
        private int y;
        private Rectangle sourceRect;
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

        public ProjectileNormalBoomerang(Texture2D texture, SpriteBatch batch, Vector2 position, int x, int y)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.x = x;
            this.y = y;
            frame = 1;
            sourceRect = new Rectangle(95, 280, 14, 17);
            isRunning = false;
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

        public void Draw()
        {
            Rectangle destinationRect = new Rectangle((int)position.X, (int)position.Y, 14, 17);
            float direction = GetDirection(x, y);
            float rotation = 0f;
            frame++;

            if (y == 0)
            {
                if (frame < 30)
                {
                    IsRunning = true;
                    position.X += direction * 3f;
                    rotation += (float)Math.PI / 4f;
                }
                else if (frame >= 30 && frame < 40)
                {
                    position.X += direction;
                    rotation += (float)Math.PI / 4f;
                }
                else if (frame >= 40 && frame < 45)
                {
                    position.X += direction * 0f;
                    rotation += (float)Math.PI / 4f;
                }
                else if (frame >= 45 && frame < 55)
                {
                    position.X += direction * -1f;
                    rotation += (float)Math.PI / 4f;
                }
                else if (frame >= 55 && frame < 85)
                {
                    position.X += direction * -3f;
                    rotation = 0f;
                }
                else
                {
                    IsRunning = false;
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

    }
}