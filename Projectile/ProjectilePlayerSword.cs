using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Sprint0.LevelClass;

namespace Sprint0
{
    public class ProjectilePlayerSword : IProjectile, IBoxCollider
    {
        private Vector2 position;
        Player.Directions orientation;
        private Rectangle sourceRect;
        private Rectangle destinationRect;
        private Texture2D texture;
        private SpriteBatch batch;
        private readonly TopLeft topLeft;
        private readonly BottomRight bottomRight;
        private const int SWORD_THICKNESS = 30;
        private const int SWORD_LENGTH = 50;

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
            get { return new Vector2(2, 2); }
            set { return; }
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
        public ProjectilePlayerSword(Vector2 position, Player.Directions dir)
        {
            texture = null;
            batch = null;
            this.position = position;
            orientation = dir;

            switch (dir)
            {
                case Player.Directions.Down:
                    topLeft = new TopLeft((int)position.X - SWORD_THICKNESS / 2, (int)position.Y, this);
                    bottomRight = new BottomRight((int)position.X + SWORD_THICKNESS / 2, (int)position.Y + SWORD_LENGTH, this);
                    break;
                case Player.Directions.Up:
                    topLeft = new TopLeft((int)position.X - SWORD_THICKNESS / 2, (int)position.Y - SWORD_LENGTH, this);
                    bottomRight = new BottomRight((int)position.X + SWORD_THICKNESS / 2, (int)position.Y, this);
                    break;
                case Player.Directions.Left:
                    topLeft = new TopLeft((int)position.X-SWORD_LENGTH, (int)position.Y - SWORD_THICKNESS / 2, this);
                    bottomRight = new BottomRight((int)position.X, (int)position.Y + SWORD_THICKNESS / 2, this);
                    break;
                case Player.Directions.Right:
                    topLeft = new TopLeft((int)position.X, (int)position.Y - SWORD_THICKNESS / 2, this);
                    bottomRight = new BottomRight((int)position.X + SWORD_LENGTH, (int)position.Y + SWORD_THICKNESS / 2, this);
                    break;

            }
            isRunning = true;

        }

        public void Update()
        {
            

        }
        public void Draw()
        {
            // destinationRect = new Rectangle(topLeft.X, TopLeft.Y, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
            //Rectangle sourceRect = new Rectangle(0, 0, 300, 300);

        }

        public void Draw(int xOffset, int yOffset)
        {
        
        }

        private void UpdateCollisionBox()
        {
            switch (orientation)
            {
                case Player.Directions.Down:
                    topLeft.X = (int)position.X - SWORD_THICKNESS / 2;
                    topLeft.Y = (int)position.Y;
                    bottomRight.X = (int)position.X + SWORD_THICKNESS / 2;
                    bottomRight.Y = (int)position.Y + SWORD_LENGTH;
                    break;
                case Player.Directions.Up:
                    topLeft.X = (int)position.X - SWORD_THICKNESS / 2;
                    topLeft.Y = (int)position.Y - SWORD_LENGTH;
                    bottomRight.X = (int)position.X + SWORD_THICKNESS / 2;
                    bottomRight.Y = (int)position.Y;
                    break;
                case Player.Directions.Left:
                    topLeft.X = (int)position.X - SWORD_LENGTH;
                    topLeft.Y = (int)position.Y - SWORD_THICKNESS / 2;
                    bottomRight.X = (int)position.X;
                    bottomRight.Y = (int)position.Y + SWORD_THICKNESS / 2;
                    break;
                case Player.Directions.Right:
                    topLeft.X = (int)position.X;
                    topLeft.Y = (int)position.Y - SWORD_THICKNESS / 2;
                    bottomRight.X = (int)position.X + SWORD_LENGTH;
                    bottomRight.Y = (int)position.Y + SWORD_THICKNESS / 2;
                    break;
            }

            topLeft.X = (int)position.X;
            topLeft.Y = (int)position.Y;
            bottomRight.X = (int)position.X + 45;
            bottomRight.Y = (int)position.Y + 45;


        }
    }
}




