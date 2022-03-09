using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0
{
    public class ProjectilePlayerFireball : IProjectile, IBoxCollider
    {
        private Vector2 position;
        private Vector2 direction;

        private Texture2D texture;
        private SpriteBatch batch;
        private Rectangle sourceRect;
        private Rectangle destinationRect;
        private readonly TopLeft topLeft;
        private readonly BottomRight bottomRight;

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
            set { position = value; UpdateCollisionBox(); }
        }
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public TopLeft TopLeft
        {
            get { return topLeft; }
        }
        public BottomRight BottomRight
        {
            get { return bottomRight; }
        }

        //Vector direction should only use 0, 1, -1
        public ProjectilePlayerFireball(Texture2D texture, SpriteBatch batch, Vector2 position, Vector2 direction)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.direction = direction;

            sourceRect = new Rectangle(287, 276, 22, 26);
            topLeft = new TopLeft((int)position.X, (int)position.Y, this);
            bottomRight = new BottomRight((int)position.X + 45, (int)position.Y + 45, this);
            isRunning = true;
            frame = 0;
            rotation = 0f;


        }

        public void Update()
        {

            destinationRect = new Rectangle((int)position.X, (int)position.Y, 30, 40);
            frame++;

            if (frame < 10)
            {
                position.X += direction.X * 5f;
                position.Y += direction.Y * 5f;

            }
            else if (frame >= 10 && frame < 30)
            {
                if (frame % 10 < 5)
                {
                    sourceRect = new Rectangle(287, 276, 22, 27);
                }
                else
                {
                    sourceRect = new Rectangle(287, 304, 22, 27);
                }
            }
            else
            {
                IsRunning = false;
                sourceRect = new Rectangle(400, 400, 0, 0);
            }
            UpdateCollisionBox();


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
            UpdateCollisionBox();
        }

        private void UpdateCollisionBox()
        {
            topLeft.X = (int)position.X;
            topLeft.Y = (int)position.Y;
            bottomRight.X = (int)position.X + 45;
            BottomRight.Y = (int)position.Y + 45;
        }

    }
}