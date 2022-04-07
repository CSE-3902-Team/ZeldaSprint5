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
        public void DrawHand()
        {
            
        }
    }
}

