using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.enemy
{

    class ManhandlaFire2: IProjectile, IBoxCollider
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
        private bool isRunning = true;
        private int fireBallFrame;
        private Vector2 currentPos;
        private Boolean isalive = true;
        private Player link;
        private float rateX;
        private float rateY;

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
        public ManhandlaFire2(Texture2D texture, SpriteBatch batch, Vector2 projectilePos, Vector2 direction, Vector2 destination, int projectileFrame, int frameCount, Vector2 currentPos, Boolean isalive,Player player)

        {
            this.Texture = texture;
            this.batch = batch;
            this.destinationX = (int)destination.X;
            this.destinationY = (int)destination.Y;
            this.movement = direction;
            this.projectilePos = projectilePos;
            fireBallFrame = projectileFrame;
            this.currentPos = currentPos;
            this.result = projectileFrame;
            this.isalive = isalive;
            FrameCount = frameCount;
            link= player;
            projectilePos.X -= 32;
            projectilePos.Y += 64;
            topLeft = new TopLeft(400, 200, this);
            botRight = new BottomRight(440, 240, this);
        }

        public void Update()

        {
            if (projectilePos.X <= 0|| projectilePos.X >=800|| projectilePos.Y <= 0 || projectilePos.Y >=800)
            {
                projectilePos.X = Direction.X-32;
                projectilePos.Y = Direction.Y+64;
                isRunning = true;
            }
            if(isRunning)
            {
                Console.WriteLine(rateX);
                rateX = currentPos.X / link.Position.X;
                if (rateX >= 1)
                    projectilePos.X -= (1 * (rateX));
                else
                {
                    projectilePos.X += (1* (rateX));
                }

                rateY = currentPos.Y / link.Position.Y;


                if (rateY >= 1)
                    projectilePos.Y -= (1 * (rateY));
                else
                {
                    projectilePos.Y += (1 * (rateY));
                }
            }
            else
            {
                projectilePos.X = 0;
                projectilePos.Y = 0;
            }
            UpdateCollisionBox();
            return;
        }

        public void Draw()
        {
            Draw(0, 0);
        }

        public void Draw(int xOffset, int yOffset)
        {
            int rowFireBall = fireBallFrame;


            Rectangle FireballSourceRectangle = new Rectangle(18 * rowFireBall + 200, 22, 16, 30);


            Rectangle FireBallDestinationRectangle = new Rectangle((int)Position.X + xOffset, (int)Position.Y + yOffset, 40, 40);
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
            botRight.Y = (int)projectilePos.Y +40;

        }
    }
}

