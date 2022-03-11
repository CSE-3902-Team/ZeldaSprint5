using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.enemy
{

    class DragonFireBall1 : IProjectile, IBoxCollider
    {
        public Texture2D Texture;


        private SpriteBatch batch;
        private Vector2 movement;
        private Vector2 Pos;
        int destinationX;
        int destinationY;
        private int result;
        private int FrameCount;
        private Vector2 projectilePos;
        private TopLeft topLeft;
        private BottomRight botRight;
        private bool isRunning;
        private int fireBallFrame;
        private Vector2 currentPos;


        public TopLeft TopLeft
        {
            get { return topLeft; }
        }

        public BottomRight BottomRight
        {
            get { return botRight; }
        }
        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }
        public Vector2 Direction { get; set; }
        public Vector2 Position
        {
            get { return projectilePos; }
            set { projectilePos = value; }
        }
        public DragonFireBall1(Texture2D texture, SpriteBatch batch, Vector2 projectilePos, Vector2 direction, Vector2 destination, int projectileFrame, int frameCount, Vector2 currentPos)
        {
            Texture = texture;
            this.batch = batch;


            this.destinationX = (int)destination.X;
            this.destinationY = (int)destination.Y;
            this.movement = direction;
            this.projectilePos = projectilePos;
            fireBallFrame = projectileFrame;
            this.currentPos = currentPos;
            this.result = projectileFrame;
            FrameCount = frameCount;
            isRunning = true;
            topLeft = new TopLeft(0, 0, this);
            botRight = new BottomRight(0, 0, this);
        }

        public void Update()

        {
            if (projectilePos.X == 0)
            {
                projectilePos.X = Direction.X-22;
                projectilePos.Y = Direction.Y+6;
                isRunning = true;
            }

            if (isRunning)
            {
                UpdateCollisionBox();

                if (projectilePos.X > 0)
                {
                    projectilePos.X -= 1;
                    projectilePos.Y -= 1;
                }

            }
            else
            {

                projectilePos.X = 0;
                projectilePos.Y = 0;
            }
            return;
        }
        public void Draw()
        {
            int rowFireBall = fireBallFrame;


            Rectangle FireballSourceRectangle = new Rectangle(18 * rowFireBall + 200, 22, 16, 30);


            Rectangle FireBallDestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 40, 40);
            batch.Begin();
            if (isRunning)
                batch.Draw(Texture, FireBallDestinationRectangle, FireballSourceRectangle, Color.White);
            batch.End();
        }

        public int ProjectileFrameChange()
        {

            fireBallFrame++;

            if (fireBallFrame >= 4)
                fireBallFrame = 0;
            return fireBallFrame;
        }
        private void UpdateCollisionBox()
        {
            topLeft.X = (int)projectilePos.X;
            topLeft.Y = (int)projectilePos.Y;
            botRight.X = (int)projectilePos.X + 40;
            botRight.Y = (int)projectilePos.Y + 40;

        }
    }
}

