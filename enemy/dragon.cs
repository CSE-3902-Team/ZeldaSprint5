using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.enemy
{
    public class bossDragon : IEnemySprite, IBoxCollider
    {

        public Texture2D Texture;
        private static Texture2D rect;
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
        private int currentFrameHurt;
        private Vector2 direction;
        private Vector2 currentPos;
        private Vector2 destination;
        int x = 600;
        private int trigger;
        private int hit;
        private int row1;
        private int change;
        public int explosionFrame;
        private int frame;
        private int frame1=200;

        private TopLeft topLeft;
        private BottomRight botRight;
        private bool isAlive;
        private int DeathCount;
        public int deathCount
        {
            get { return DeathCount; }
            set { DeathCount = value; }
        }
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
        { if (isAlive && deathCount < 10)
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


                if (frame1 % 15 == 0)
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
            }
   
 
      
        }


        public void draw() {
            draw(0, 0);
        }

        public void draw(int xOffset, int yOffset)
        {

            Vector2 temp = new Vector2();
            int row = currentFrame;

            Rectangle sourceRectangle = new Rectangle(50 * row + 3, 11, 48, 82);

            Rectangle destinationRectangle = new Rectangle((int)currentPos.X + xOffset, (int)currentPos.Y + yOffset, 160, 200);

            batch.Begin();
            if (isAlive)
            {
                if (deathCount < 10)
                {
                    if (rect == null)
                    {
                        rect = new Texture2D(batch.GraphicsDevice, 1, 1);
                        rect.SetData(new[] { Color.White });
                    }
                    batch.Draw(rect, new Rectangle((int)topLeft.X, (int)topLeft.Y, 20, 20), Color.Fuchsia);
                    batch.Draw(rect, new Rectangle((int)botRight.X, (int)botRight.Y, 20, 20), Color.Fuchsia);
                    if (trigger != deathCount && hit < 50)
                    {

                        batch.Draw(Texture, new Rectangle((int)currentPos.X + xOffset - 15, (int)currentPos.Y + yOffset + 15, 200, 200), new Rectangle(61 * currentFrameHurt + 515, 444, 64, 90), Color.White);




                        hit++;
                    }
                    else
                    {


                        batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                    }
                }
                if (deathCount >= 10)
                {

                    topLeft.X = 0;
                    topLeft.Y = 0;
                    botRight.X = 0;
                    botRight.Y = 0;

                    if (explosionFrame < 200)
                    {


                        batch.Draw(Texture, new Vector2((int)currentPos.X + change + xOffset, (int)currentPos.Y + change + yOffset), new Rectangle(18 * row1 + 820, 338, 18, 23), Color.White, 0.01f, new Vector2(0, 0), 2f, SpriteEffects.None, 1);
                        batch.Draw(Texture, new Vector2((int)currentPos.X + change + xOffset + 25, (int)currentPos.Y - change + yOffset + 25), new Rectangle(18 * row1 + 820, 338, 18, 23), Color.White, 135f, new Vector2(0, 0), 2f, SpriteEffects.FlipVertically, 1);
                        batch.Draw(Texture, new Vector2((int)currentPos.X - change + xOffset, (int)currentPos.Y - change + yOffset), new Rectangle(18 * row1 + 820, 338, 18, 23), Color.White, 0.01f, new Vector2(0, 0), 2f, SpriteEffects.None, 1);
                        batch.Draw(Texture, new Vector2((int)currentPos.X - change + xOffset, (int)currentPos.Y + change + yOffset), new Rectangle(18 * row1 + 820, 338, 18, 23), Color.White, 0.01f, new Vector2(0, 0), 2f, SpriteEffects.FlipHorizontally, 1);
                    }
                    else
                    {
                        isAlive = false;
                    }
                    row1++;
                    if (row1 == 5)
                    {
                        row1 = 0;
                    }
                    explosionFrame++;
                    change += 2;
                }

            }


            batch.End();
            currentFrameHurt++;
            if (hit == 50)
            {
                trigger++;
                hit = 0;
            }
            if (currentFrameHurt == 4)
            {
                currentFrameHurt = 0;
            }
       
        }

        private void UpdateCollisionBox()
        {
            topLeft.X = (int)currentPos.X+10;
            topLeft.Y = (int)currentPos.Y+30;
            botRight.X = (int)currentPos.X +160;
            botRight.Y = (int)currentPos.Y + 180;

        }


    }
}
