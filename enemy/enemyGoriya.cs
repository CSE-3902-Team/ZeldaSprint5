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
        private bool temp=true;
     
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
            topLeft = new TopLeft ((int)location.X, (int)location.Y, this);
            botRight = new BottomRight((int)location.X+40, (int)location.Y+40, this);
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
         
                    frame2++;

                    projectileFrame = proj.ProjectileFrameChange();
                  proj.Update();
        

                    pCurrentPos = proj.Position;




                    if (frame2 == 200)
                    {


                        fire = false;
                 
                    }
                }






         


                frame++;
     
                    }
            else
            {
                currentPos.X = 0;
                currentPos.Y = 0;
            }
            UpdateCollisionBox();
            frame3++;
        }


            public Vector2 draw()
            {
                Vector2 temp = new Vector2();
       

            EnemyDraw draw = new EnemyDraw(Texture, batch, pCurrentPos, direction, destination, projectileFrame, 0, currentFrame, currentPos, isAlive, flipHorizontal);
            
       
            draw.DrawGoriya(proj.IsRunning);


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

