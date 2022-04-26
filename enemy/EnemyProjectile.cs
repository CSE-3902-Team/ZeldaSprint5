using Microsoft.Xna.Framework;
using System;

namespace Sprint0.enemy
{

    class EnemyProjectile : IProjectile, IBoxCollider
    {
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
            set { projectilePos = value;
                UpdateCollisionBox();
            }
        }
        public EnemyProjectile(Vector2 direction, Vector2 currentPos, Vector2 destination, Vector2 ProjectilePos, int frameCount, int projectileFrame)

        {
      
            this.destinationX = (int)destination.X;
            this.destinationY = (int)destination.Y;
            this.movement = direction;
            this.Pos = currentPos;
            this.projectilePos = ProjectilePos;
            this.result = projectileFrame;
            this.FrameCount = frameCount;
            isRunning = true;
            topLeft = new TopLeft(400, 200, this);
            botRight = new BottomRight(440, 240, this);
        }

        public void Update()
        {



            UpdateCollisionBox();
            if (isRunning)
            {
                if (FrameCount < 100)
                {
                    switch (movement.X)
                    {

                        case 0:
                            if (Pos.Y < destinationY)

                                projectilePos.Y += 2;
                            else if (Pos.Y > destinationY)
                                projectilePos.Y -= 2;

                            break;
                        case 1:
                            if (Pos.X < destinationX)
                            {
                                projectilePos.X += 2;
                            }
                            else if (Pos.X > destinationX)
                            {
                                projectilePos.X -= 2;
                            }
                            break;
                    }
                }
                else if (FrameCount >= 100)
                {
                    switch (movement.X)
                    {

                        case 0:
                            if (Pos.Y < destinationY)

                                projectilePos.Y -= 2;
                            else if (Pos.Y > destinationY)
                                projectilePos.Y += 2;

                            break;
                        case 1:
                            if (Pos.X < destinationX)
                            {
                                projectilePos.X -= 2;
                            }
                            else if (Pos.X > destinationX)
                            {
                                projectilePos.X += 2;
                            }
                            break;
                    }
                }

            }
            else if(FrameCount>=170)
            {
                projectilePos.X = 0;

                projectilePos.Y=0;
            }
            return;
        }
        public void Draw()
        {

        }

        public void Draw(int xOffset, int yOffset) 
        {
        
        }

        public int ProjectileFrameChange()
        {
            if (FrameCount % 3 == 0)
            {
                result++;
                if (result > 2)
                    result = 0;
            }
            return result;
        }
        private void UpdateCollisionBox()
        {
            topLeft.X = (int)projectilePos.X;
            topLeft.Y = (int)projectilePos.Y;
            botRight.X = (int)projectilePos.X +30;
            botRight.Y = (int)projectilePos.Y +30;

        }
    }
}

