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
        private Vector2 direction;

        private Texture2D texture;
        private SpriteBatch batch;
        private Rectangle sourceRect;
        private Rectangle destinationRect;
        private Rectangle collisionBox;

        private int frame;
        private float rotation;

        // Used by the Player class to know if the projectile is still in animation
        private Boolean isRunning;

        public Boolean IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }
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
        public Rectangle CollisionBox
        {
            get { return collisionBox; }
            set { collisionBox = value; }
        }
        //Vector direction should only use 0, 1, -1
        public ProjectileNormalArrow(Texture2D texture, SpriteBatch batch, Vector2 position, Vector2 direction)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.direction = direction;

            sourceRect = new Rectangle(14, 282, 26, 14);
            collisionBox = new Rectangle((int)this.position.X, (int)this.position.Y, 40, 20);

            rotation = 0f;
            isRunning = true;
            frame = 1;
            
        }
        public void GetRotation(Vector2 direction)
        {
            if (direction.X == 0 && direction.Y > 0)
            {
                rotation = (float)Math.PI / 2f;
            }
            else if (direction.X == 0 && direction.Y < 0)
            {
                rotation = (float)Math.PI * 3f / 2f;
            }
            else if (direction.X > 0 && direction.Y == 0)
            {
                rotation = 0f;
            }
            else if (direction.X < 0 && direction.Y == 0)
            {
                rotation = (float)Math.PI;
            }
        }
        public void Update()
        {
            GetRotation(direction);

            if(IsRunning == true)
            {
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 40, 20);
                frame++;

                if (frame < 50)
                {
                    IsRunning = true;
                    position.X += direction.X * 5f;
                    position.Y += direction.Y * 5f;

                }
                else if (frame >= 50 && frame < 60)
                {
                    sourceRect = new Rectangle(176, 280, 15, 20);
                    destinationRect = new Rectangle((int)position.X, (int)position.Y, 20, 25);
                }
                else
                {
                    IsRunning = false;
                    sourceRect = new Rectangle(400, 400, 0, 0);
                }
            }
            else
            {
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
