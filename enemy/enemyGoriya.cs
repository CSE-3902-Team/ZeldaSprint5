using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint0.enemy
{
    public class enemyGoriya : IEnemySprite, IBoxCollider
    {
        public Texture2D Texture;

        private int currentFrame;

        private SpriteBatch batch;
        Random fireSomething = new Random((int)DateTime.Now.Ticks);
        private int fireCount;
   

        private Vector2 pCurrentPos;
        private int projectileFrame = 0;

        private Vector2 direction;
        public Vector2 currentPos;
        private Vector2 destination;
        public Vector2 ProjectileCurrent;
        ICommand command;

        private int frame;
        private int frame1;
        private int frame2;
     
        bool flipHorizontal = false;
        bool fire = false;
        private TopLeft topLeft;
        private BottomRight botRight;
        private bool isAlive;
        EnemyProjectile proj;


        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
        public TopLeft TopLeft
        {
            get { return topLeft; }
        }

        public BottomRight BottomRight
        {
            get { return botRight; }
        }
        public Vector2 position
        {
            get { return currentPos; }
            set
            {
                currentPos = value;
                UpdateCollisionBox();

            }
        }
        public Vector2 Destination
        {
            get { return destination; }
            set
            {
                destination= value;


            }
        }
        int frame3;
        public enemyGoriya(Texture2D texture, SpriteBatch batch, Vector2 location, ICommand c)
        {
            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentPos.X = (int)location.X;
            currentPos.Y = (int)location.Y;
            topLeft = new TopLeft(400, 200, this);
            botRight = new BottomRight(440, 240, this);
            isAlive = true;
            destination = location;
             fireCount =fireSomething.Next(150, 500);
            proj = new EnemyProjectile(direction, currentPos, destination, pCurrentPos, frame2, projectileFrame);
            command = c;
        }

        public void Update()
        {
            if (isAlive) {
                // the goriya will fire every 210 frames, and reset frame counts
                if (frame1 == fireCount)
                {
                    fire = true;
                    pCurrentPos.X = currentPos.X;
                    pCurrentPos.Y = currentPos.Y;
                    frame1 = 0;
                    frame2 = 0;
                    proj.IsRunning = true;
                 
                 
                }
                if (frame3 == 15)
                {


                    command.LoadCommand(proj);
                    command.Execute();

                    frame3 = 0;
                }
                proj = new EnemyProjectile(direction, currentPos, destination, pCurrentPos, frame2, projectileFrame);
                FrameChaningforEnemy action = new FrameChaningforEnemy(currentPos, direction, destination, currentFrame);
                NewDestination makeNextMove = new NewDestination(direction, currentPos, destination);
               

                direction = makeNextMove.RollingDice1();

                destination = makeNextMove.RollingDice();
                MoveEnemy move = new MoveEnemy(direction, currentPos, destination);

                //every 5 frames,change goriya's action frame
                if (frame == 5)
                {
                    currentFrame = action.goriya();

                    frame = 0;
                }

                if (!fire)
                {
                    proj.IsRunning = false;
                    switch (direction.X)
                    {

                        case 1:
                            if (currentPos.X < destination.X)
                            {

                                flipHorizontal = false;
                            }
                            else if (currentPos.X > destination.X)
                            {

                                flipHorizontal = true;
                            }
                            break;
                        default:
                            break;

                    }
                    currentPos = move.Move();

                    direction = makeNextMove.RollingDice1();

                    destination = makeNextMove.RollingDice();
                    frame1++;
                }
                else
                {
                    proj.IsRunning = true;
                    frame2++;

                    projectileFrame = proj.ProjectileFrameChange();
                  proj.Update();
                    pCurrentPos = proj.Position;
                    Console.WriteLine(proj.IsRunning);




                    if (frame2 == 200)
                    {


                        fire = false;
                        proj.IsRunning = false;
                    }
                }






         


                frame++;
     
                    }
            else
            {
                pCurrentPos.X = 0;
                pCurrentPos.Y = 0;
            }
            UpdateCollisionBox();
            frame3++;
        }


            public Vector2 draw()
            {
                Vector2 temp = new Vector2();
                Vector2 origin = new Vector2(0, 0);
                Vector2 location = new Vector2(currentPos.X, currentPos.Y);
                int row = currentFrame;
                int row1 = projectileFrame;

                Rectangle sourceRectangle = new Rectangle(16 * row + 222, 11, 16, 16);
                Rectangle sourceRectangleProjectile = new Rectangle(8 * row1 + 289, 11, 8, 16);
      
                Vector2 location1 = new Vector2(pCurrentPos.X, pCurrentPos.Y);


            if (isAlive)
            {
                batch.Begin();

                if (fire)
                {
                    if (proj.IsRunning)
                        batch.Draw(Texture, location1, sourceRectangleProjectile, Color.White, 0.01f, origin, 2f, SpriteEffects.FlipHorizontally, 1);
                }
                if (flipHorizontal)
                {

                    batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 3f, SpriteEffects.FlipHorizontally, 1);
                }

                else
                {
              
                    batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 3f, SpriteEffects.None, 1);
                }

                batch.End();
            }
                temp.X = currentPos.X;
                temp.Y = currentPos.Y;
                return temp;
            }

            private void UpdateCollisionBox()
            {
              topLeft.X = (int)currentPos.X;
              topLeft.Y = (int)currentPos.Y;
              botRight.X = (int)currentPos.X +40;
              botRight.Y = (int)currentPos.Y + 40;

            }




    }
}

