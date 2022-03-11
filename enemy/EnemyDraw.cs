using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.enemy
{

    class EnemyDraw
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
        private bool isRunning;
        private int projectileFrame;
        private Vector2 currentPos;
        private int currentFrame;
        private bool isAlive;
        private bool flip;



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
        public EnemyDraw(Texture2D texture, SpriteBatch batch, Vector2 projectilePos, Vector2 direction, Vector2 destination, int projectileFrame, int frameCount, int currentFrame, Vector2 currentPos, Boolean active,Boolean flip)

        {
            this.Texture = texture;
            this.batch = batch;
            this.destinationX = (int)destination.X;
            this.destinationY = (int)destination.Y;
            this.movement = direction;
            this.projectilePos = projectilePos;
            this.projectileFrame = projectileFrame;
            this.currentPos = currentPos;
            this.result = projectileFrame;
            this.currentFrame = currentFrame;
            FrameCount = frameCount;
            isRunning = active;
            this.flip = flip;


        }


        public void DrawFireBall()
        {
            int rowFireBall = projectileFrame;


            Rectangle FireballSourceRectangle = new Rectangle(9 * rowFireBall + 100, 11, 8, 15);


            Rectangle FireBallDestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, 20, 20);
            batch.Begin();
            if (isRunning)
                batch.Draw(Texture, FireBallDestinationRectangle, FireballSourceRectangle, Color.White);
            batch.End();
        }
        public void DrawBat()
        {
            int row = currentFrame;
            if (isRunning)
            {
                Rectangle sourceRectangle = new Rectangle(32 * row + 366, 22, 32, 32);
                Rectangle destinationRectangle = new Rectangle((int)currentPos.X, (int)currentPos.Y, 40, 40);

                batch.Begin();
                batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

                batch.End();
            }

        }
        public void DrawGel()
        {
            int row = currentFrame;
            if (isRunning)
            {
                Rectangle sourceRectangle = new Rectangle(16 * row + 4, 22, 16, 32);
                Rectangle destinationRectangle = new Rectangle((int)currentPos.X, (int)currentPos.Y, 64, 64);

                batch.Begin();
                batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

                batch.End();
            }
        }
        public void DrawHand()
        {
            int row = currentFrame;
            if (isRunning)
            {
                Rectangle sourceRectangle = new Rectangle(32 * row +847,388, 32, 32);
                Rectangle destinationRectangle = new Rectangle((int)currentPos.X, (int)currentPos.Y, 40, 40);

                batch.Begin();
                batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

                batch.End();
            }
        }
        public void DrawSkeleton()
        {
     
            Vector2 location = new Vector2((int)currentPos.X, (int)currentPos.Y);
            Vector2 origin = new Vector2(0, 0);
            Rectangle sourceRectangle = new Rectangle(2, 118, 32, 32);
            if (isRunning)
            {


                batch.Begin();

                if (currentFrame % 2 == 0)
                    batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 2f, SpriteEffects.FlipHorizontally, 1);




                else
                    batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 2f, SpriteEffects.None, 1);
                batch.End();
            }
        }
      public void DrawGoriya(bool Run)
        {
            Vector2 origin = new Vector2(0, 0);
            Vector2 location = new Vector2(currentPos.X, currentPos.Y);
            int row = currentFrame;
            int row1 = projectileFrame;

            Rectangle sourceRectangle = new Rectangle(35 * row + 444, 24, 32, 33);
            Rectangle sourceRectangleProjectile = new Rectangle(18 * row1 + 580, 20, 18, 35);

            Vector2 location1 = new Vector2(projectilePos.X, projectilePos.Y);


            if (isRunning)
            {
                batch.Begin();

                if (Run)
                {
                    

                        batch.Draw(Texture, location1, sourceRectangleProjectile, Color.White, 0.01f, origin, 2f, SpriteEffects.FlipHorizontally, 1);
                }
                if (flip)
                {

                    batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 2f, SpriteEffects.FlipHorizontally, 1);
                }

                else
                {

                    batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 2f, SpriteEffects.None, 1);
                }

                batch.End();
            }
        }
    }
}

