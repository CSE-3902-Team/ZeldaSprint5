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
        private Vector2 direction;

        private Texture2D texture;
        private SpriteBatch batch;
        private Rectangle sourceRect;
        private Rectangle destinationRect;

        private int frame;
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
        
        //Vector direction should only use 0, 1, -1
        public ProjectileFireball(Texture2D texture, SpriteBatch batch, Vector2 position, Vector2 direction)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.direction = direction;

            sourceRect = new Rectangle(287, 276, 22, 26);

            isRunning = false;
            frame = 0;
            rotation = 0f;


        }

        public void Update()
        {
            destinationRect = new Rectangle((int)position.X, (int)position.Y, 22, 26);
            frame++;

            if (frame < 20)
            {
                IsRunning = true;
                position.X += direction.X * 5f;
                position.Y += direction.Y * 5f;
                
            }
            else if (frame >= 20 && frame < 40)
            {
                //This is when the fireball sits in place 
            }
            else
            {
                IsRunning = false;
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