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
        public ProjectileFireball(Texture2D texture, SpriteBatch batch, Vector2 position, int x, int y)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.x = x;
            this.y = y;
            isRunning = false;
            frame = 1;
            rotation = 0f;
            sourceRect = new Rectangle(287, 276, 22, 26);
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
            Rectangle destinationRect = new Rectangle((int)position.X, (int)position.Y, 22, 26);
            float direction = GetDirection(x, y);
            frame++;
            

            if(frame < 30)
            {
                IsRunning = true;
                if(y == 0)
                {
                    position.X += direction * 3f; 
                }else if (x == 0)
                {
                    position.Y += direction * 3f;
                }
            }
            else if(frame >= 30 && frame < 40)
            {

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