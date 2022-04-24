using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.enemy
{
    public class bossManhandla : IEnemySprite, IBoxCollider
    {

        public Texture2D Texture;
        private static Texture2D rect;
        private int currentFrame;
        private int FireBallCurrentFrame;
        private int total;
        private SpriteBatch batch;
        private bool fire;
        ManhandlaFire Fireball1;
        ManhandlaFire1 Fireball2;
        ManhandlaFire2 Fireball3;
        private Vector2 FireballCurrent1;
        DragonFireBall dragonBreath1;
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
        private int frame1 = 200;
        private int frame2=200;
        private int cloudAppear;
        private int row2 = 4;
        private TopLeft topLeft;
        private BottomRight botRight;
        private bool isAlive;
        private int DeathCount;
        private Player link;
        private int spriteWidth=106;
        private int spriteHeight=105;
        private int spriteXpos=171;
        private int spriteYpos=181;
        private int desRecX=210;
        private int desRecY=210;
        private int spriteWidthBegin = 106;
        private bool topHeadDead=false;
        private bool bottomHeadDead = false;
        private bool leftHeadDead = false;
        private bool rightHeadDead = false;
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


        public bossManhandla(Texture2D texture, SpriteBatch batch, Vector2 location, ICommand c,Player player)
        {
            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentPos.Y = location.Y;
            currentPos.X = location.X;
            destination.X = 400;
            destination.Y = 200;
            topLeft = new TopLeft((int)currentPos.X, (int)currentPos.Y, this);
            botRight = new BottomRight((int)currentPos.X + 160, (int)currentPos.Y + 200, this);
            isAlive = true;
            command = c;
            link = player;
            FireballCurrent1.X = currentPos.X-64;
            FireballCurrent1.Y = currentPos.Y+64;
            Fireball1 = new ManhandlaFire(Texture, batch, FireballCurrent1, direction, destination, FireBallCurrentFrame, frame1, currentPos, true, link);
            Fireball2 = new ManhandlaFire1(Texture, batch, FireballCurrent1, direction, destination, FireBallCurrentFrame, frame1, currentPos, true, link);
            Fireball3 = new ManhandlaFire2(Texture, batch, FireballCurrent1, direction, destination, FireBallCurrentFrame, frame1, currentPos, true, link);


        }

        public void Update()
        {

            if (cloudAppear >= 150)
            {
                if (isAlive && deathCount < 10)
                {
                  
                    Fireball1.Direction = currentPos;

                    Fireball2.Direction = currentPos;

                    Fireball3.Direction = currentPos;
                    FrameChaningforEnemy action = new FrameChaningforEnemy(currentPos, direction, destination, currentFrame);
                    MoveEnemy move = new MoveEnemy(direction, currentPos, destination);
                    NewDestination makeNextMove = new NewDestination(direction, currentPos, destination);
                    Fireball1.Update();
                    Fireball2.Update();
                    Fireball3.Update();
                    if (frame == 5)
                    {
                        currentFrame = action.frameReturn();
                        FireBallCurrentFrame =Fireball1.ProjectileFrameChange();
                        Fireball2.ProjectileFrameChange();
                        Fireball3.ProjectileFrameChange();
                        frame = 0;
                    }
                
                    if (frame1 % 7== 0)
                    {
                        if (!leftHeadDead)
                        {
                            command.LoadCommand(Fireball1);
                            command.Execute();
                        }
                        if (!rightHeadDead)
                        {
                            command.LoadCommand(Fireball2);
                            command.Execute();
                        }
                        if (!bottomHeadDead)
                        {
                            command.LoadCommand(Fireball3);
                            command.Execute();
                        }
                  
                    }

 

                    currentPos = move.Move();
                    if (frame1 == 200)
                    {

                        fire = true;
                        frame1= 0;



                    }
                    if (fire)
                    {


                        if (frame1 == 200)
                        {

                            fire = false;

                        }
                    }
                    frame1++;
                    direction = makeNextMove.RollingDice1();
                    destination = makeNextMove.RollingDice();
                    frame++;
                    UpdateCollisionBox();
              
                }
            }


        }


        public void draw()
        {
            draw(0, 0);
        }

        public void draw(int xOffset, int yOffset)
        {

            Vector2 temp = new Vector2();
            int row = currentFrame;

            Rectangle sourceRectangle = new Rectangle(spriteWidthBegin * row + spriteXpos, spriteYpos, spriteWidth,spriteHeight);

            Rectangle destinationRectangle = new Rectangle((int)currentPos.X + xOffset, (int)currentPos.Y + yOffset, desRecX, desRecY);
        
          
            batch.Begin();
            if (isAlive)
            {
                if (cloudAppear < 150)
                {
                    batch.Draw(Texture, new Vector2((int)currentPos.X + xOffset + 50, (int)currentPos.Y + yOffset + 75), new Rectangle(33 * row2 + 624, 304, 33, 34), Color.White, 0.01f, new Vector2(0, 0), 3f, SpriteEffects.None, 1);
                    cloudAppear++;
                    if (cloudAppear % 60 == 0)
                        row2--;
                    if (row2 == -1)
                        row2 = 4;
                }
                else
                {
                    if (topHeadDead && bottomHeadDead && leftHeadDead && rightHeadDead)
                    {
                        deathCount = 10;
                    }
                    else {
                        if(deathCount>2)
                        deathCount = 1;
                    }
                    if (deathCount < 10)
                    {
                        if (rect == null)
                        {
                            rect = new Texture2D(batch.GraphicsDevice, 1, 1);
                            rect.SetData(new[] { Color.White });
                        }
                        batch.Draw(rect, new Rectangle(topLeft.X, topLeft.Y, 20, 20), Color.Chocolate);
                        batch.Draw(rect, new Rectangle(botRight.X, botRight.Y, 20, 20),Color.Chocolate);
                        switch (destination.X)
                            {
                                case 0:
                                    if (destination.Y == 0&& !topHeadDead)
                                    {

                                        spriteYpos += 35;
                                        spriteHeight -= 34;
                                        desRecY -= 64;
                                    topHeadDead = true;

                        











                                    }
                                   else if (destination.Y == 1&& !bottomHeadDead)
                                    {
                                        spriteYpos -=7;
                                        spriteHeight -= 34;
                                        desRecY -= 64;
                                    bottomHeadDead = true;
                                    }
                                    break;
                                case 1:
                                    if (destination.Y == 1&& !leftHeadDead)
                                    {
                                        spriteXpos += 40;
                                   
                                        spriteWidth -= 34;
                                    
                                        desRecX -=75;
                                   leftHeadDead = true;
                                }
                                   else if (destination.Y == 0&&!rightHeadDead)
                                    {
                                 
                                    spriteWidth -= 40;
                                    desRecX -=75;
                                    rightHeadDead = true;
                                }
                                    break;
                            }

                    

                        if (trigger != deathCount && hit < 50)
                        {
                            
                      

                            if (hit % 2 == 0)
                            {
                                batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                            }
                            else
                            {
                                batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.Red);
                            }




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


                            batch.Draw(Texture, new Vector2((int)currentPos.X + change + xOffset, (int)currentPos.Y + change + yOffset), new Rectangle(18 * row1 + 721, 478, 18, 32), Color.White, 0.01f, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
                            batch.Draw(Texture, new Vector2((int)currentPos.X + change + xOffset + 25, (int)currentPos.Y - change + yOffset + 25), new Rectangle(18 * row1 + 721, 478, 18, 32), Color.White, 135f, new Vector2(0, 0), 1f, SpriteEffects.FlipVertically, 1);
                            batch.Draw(Texture, new Vector2((int)currentPos.X - change + xOffset, (int)currentPos.Y - change + yOffset), new Rectangle(18 * row1 + 721, 478, 18, 32), Color.White, 0.01f, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
                            batch.Draw(Texture, new Vector2((int)currentPos.X - change + xOffset, (int)currentPos.Y + change + yOffset), new Rectangle(18 * row1 + 721, 478, 18, 32), Color.White, 0.01f, new Vector2(0, 0), 1f, SpriteEffects.FlipHorizontally, 1);
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

            }
            batch.End();
            currentFrameHurt++;
            if (hit == 50)
            {
                trigger++;
                hit = 0;
            }
            if (currentFrameHurt == 3)
            {
                currentFrameHurt = 0;
            }

        }

        private void UpdateCollisionBox()
        {
            topLeft.X = (int)currentPos.X ;
            topLeft.Y = (int)currentPos.Y ;
            botRight.X = (int)currentPos.X + 180;
            botRight.Y = (int)currentPos.Y + 180;
            if(rightHeadDead)
                botRight.X = (int)currentPos.X + 150;
            if(leftHeadDead)
                topLeft.X = (int)currentPos.X + 20;
            if(topHeadDead)
                topLeft.Y = (int)currentPos.Y + 20;
            if(bottomHeadDead)
                botRight.Y = (int)currentPos.Y + 120;

        }


    }
}
