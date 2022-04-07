using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.enemy
{
    public class bossDragon : IEnemySprite, IBoxCollider
    {

        public Texture2D Texture;

        private int currentFrame;
        private int FireBallCurrentFrame;
        private int total;
        private SpriteBatch batch;
        private bool fire;
        DragonFireBall dragonBreath1;
        DragonFireBall1 dragonBreath2;
        DragonFireBall2 dragonBreath3;
        private Vector2 FireballCurrent1;
        private Vector2 FireballCurrent2;
        private Vector2 FireballCurrent3;
        ICommand command;

        private Vector2 direction;
        private Vector2 currentPos;
        private Vector2 destination;
        int x = 600;

        private int frame;
        private int frame1=200;

        private TopLeft topLeft;
        private BottomRight botRight;
        private bool isAlive;

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
                destination = value;


            }
        }

        public bossDragon(Texture2D texture, SpriteBatch batch, Vector2 location, ICommand c)
        {
            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentPos.Y = location.Y;
            currentPos.X = location.X;
            destination.X = 400;
            destination.Y = 200;
            topLeft = new TopLeft((int)currentPos.X, (int)currentPos.Y, this);
            botRight = new BottomRight((int)currentPos.X + 160, (int)currentPos.Y +200, this);
            isAlive = true;
            command = c;
            FireballCurrent1.X = 400;
            FireballCurrent1.Y = 200;
       dragonBreath1 = new DragonFireBall(Texture, batch,FireballCurrent1, direction, destination, FireBallCurrentFrame, frame1, currentPos,isAlive);
          dragonBreath2 = new DragonFireBall1(Texture, batch,FireballCurrent2, direction, destination, FireBallCurrentFrame, frame1, currentPos);
             dragonBreath3 = new DragonFireBall2(Texture, batch,FireballCurrent3, direction, destination, FireBallCurrentFrame, frame1, currentPos);
        }

        public void Update()
        {
            dragonBreath1.Direction = currentPos;
            dragonBreath2.Direction = currentPos;
            dragonBreath3.Direction = currentPos;
            FrameChaningforEnemy action = new FrameChaningforEnemy(currentPos, direction, destination, currentFrame);
            dragonBreath1.Update();
            dragonBreath2.Update();
            dragonBreath3.Update();
            MoveEnemy dragonMove = new MoveEnemy(direction, currentPos, destination);
            Vector2 result = dragonMove.DragonMove();
            if (frame == 5)
            {

                currentFrame = action.dragon();

                FireBallCurrentFrame = dragonBreath1.ProjectileFrameChange();
                FireBallCurrentFrame = dragonBreath2.ProjectileFrameChange();
                FireBallCurrentFrame = dragonBreath3.ProjectileFrameChange();


                frame = 0;
            }
       
            currentPos.X = result.Y;
            destination.X = result.X;

        
            if (frame1 % 15 == 0 )
            {
                command.LoadCommand(dragonBreath1);
                command.Execute();
                command.LoadCommand(dragonBreath2);
                command.Execute();
                command.LoadCommand(dragonBreath3);
                command.Execute();
            }
         
            if (frame1 == 200)
            {
       
                fire = true;
                frame1 = 0;
         


            }
            if (fire)
            {

              
                if (frame1 == 200)
                {

                    fire = false;
             
                }
            }
            frame++;
            frame1++;
            UpdateCollisionBox();
            Console.WriteLine(topLeft.X);
            Console.WriteLine(topLeft.Y);
            Console.WriteLine(botRight.X);
            Console.WriteLine(botRight.Y);
        }


        public void draw() {
            draw(0, 0);
        }

        public void draw(int xOffset, int yOffset)
        {

            Vector2 temp = new Vector2();
            int row = currentFrame;
        
            Rectangle sourceRectangle = new Rectangle(50 * row+3, 11, 48,82);

            Rectangle destinationRectangle = new Rectangle((int)currentPos.X + xOffset, (int)currentPos.Y + yOffset, 160, 200);
      
            batch.Begin();
            if (isAlive)
            {
                batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            batch.End();
        }

        private void UpdateCollisionBox()
        {
            topLeft.X = (int)currentPos.X;
            topLeft.Y = (int)currentPos.Y;
            botRight.X = (int)currentPos.X + 160;
            botRight.Y = (int)currentPos.Y + 200;

        }


    }
}
