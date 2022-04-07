using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Sprint0.LevelClass;

namespace Sprint0
{
    public class ProjectilePlayerBomb : IProjectile,IBoxCollider
    {
        private Vector2 position;
        private Vector2 direction;

        private Rectangle sourceRect;
        private Rectangle destinationRect;
        private Texture2D texture;
        private SpriteBatch batch;
        private readonly TopLeft topLeft;
        private readonly BottomRight bottomRight;

        private int frame;
        private float rotation;

        // Used by the Player class to know if the projectile is still in animation
        private Boolean isRunning;

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
        public Boolean IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }
        public TopLeft TopLeft
        {
            get { return topLeft; }
        }
        public BottomRight BottomRight
        {
            get { return bottomRight; }
        }
        public ProjectilePlayerBomb(Texture2D texture, SpriteBatch batch, Vector2 position, Vector2 direction)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.direction = direction;

            sourceRect = new Rectangle(276, 192, 14, 25);
            topLeft = new TopLeft((int)position.X, (int)position.Y,this);
            bottomRight = new BottomRight((int)position.X + 30, (int)position.Y + 30,this);
            frame = 0;
            isRunning = true;
            rotation = 0f;
        }

        public void Update()
        {
            if (IsRunning == true)
            {
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 30, 40);
                frame++;
                if (frame < 25)
                {
                    IsRunning = true;
                    sourceRect = new Rectangle(193, 276, 14, 24);
                }
                else if (frame >= 25 && frame < 30)
                {
                    sourceRect = new Rectangle(206, 277, 24, 24);
                    
                    destinationRect = new Rectangle((int)position.X, (int)position.Y, 45, 45);
                }
                else if (frame >= 30 && frame < 32)
                {
                   SoundManager.Instance.Play(SoundManager.Sound.BombBlow);
                    sourceRect = new Rectangle(232, 276, 24, 24);
                    destinationRect = new Rectangle((int)position.X, (int)position.Y, 45, 45);
                }
                else if (frame >= 32 && frame < 34)
                {
                    sourceRect = new Rectangle(259, 276, 24, 24);
                    destinationRect = new Rectangle((int)position.X, (int)position.Y, 45, 45);
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

            UpdateCollisionBox();

        }

        public void Draw() {
            Draw(0, 0);
        }

        public void Draw(int xOffset, int yOffset)
        {
            batch.Begin();
            Rectangle dest = new Rectangle(destinationRect.X + xOffset, destinationRect.Y + yOffset, destinationRect.Width, destinationRect.Height);
            batch.Draw(
                 texture,
                 dest,
                 sourceRect,
                Color.White,
                rotation,
                new Vector2(sourceRect.Width / 2, sourceRect.Height / 2),
                SpriteEffects.None,
                0f
                );
            batch.End();
        }

        private void UpdateCollisionBox()
        {
            topLeft.X = (int)position.X;
            topLeft.Y = (int)position.Y;
            bottomRight.X = (int)position.X + 30;
            bottomRight.Y = (int)position.Y + 30;
        }
    }
}




