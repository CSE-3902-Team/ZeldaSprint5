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
        private int rowdeathExplosion;
        private int change;
        public int explosionFrame;
        private int frame;
        private int frame1;
        private int frame2;
        private bool temp=true;
        private int cloudAppear;
        private int row2;
        bool flipHorizontal = false;
        bool fire = false;
        private TopLeft topLeft;
        private BottomRight botRight;
        private bool isAlive;
        EnemyProjectile proj;
        private int trigger;
        private int hit;
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
            if (cloudAppear >= 150)
            {
                if (isAlive && deathCount < 3)
                {
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
                    UpdateCollisionBox();
                }


                frame3++;
            }
        }

        public void draw() 
        {
            draw(0, 0);
        }

        public void draw(int xOffset, int yOffset)
        { 
            Vector2 origin = new Vector2(0, 0);
            Vector2 location = new Vector2(currentPos.X+xOffset, currentPos.Y+yOffset);
            int row = currentFrame;
            int row1 = projectileFrame;

            Rectangle sourceRectangle = new Rectangle(35 * row + 444, 24, 32, 45);
            Rectangle sourceRectangleProjectile = new Rectangle(18 * row1 + 580,25, 18, 35);

            Vector2 location1 = new Vector2(pCurrentPos.X, pCurrentPos.Y);


            if (isAlive)
            {
                batch.Begin();
                if (cloudAppear < 150)
                {
                    batch.Draw(Texture, new Vector2((int)currentPos.X + xOffset, (int)currentPos.Y + yOffset), new Rectangle(35 * row2 + 639, 25, 35, 40), Color.White, 0.01f, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
                    cloudAppear++;
                    row2++;
                    if (row2 == 5)
                        row2 = 0;
                }
                else
                {
                    if (deathCount < 3)
                    {
                        if (trigger != deathCount && hit < 50)
                        {
                            if (hit % 2 == 0)
                            {
                                if (proj.IsRunning)
                                {


                                    batch.Draw(Texture, location1, sourceRectangleProjectile, Color.White, 0.01f, origin, 1.5f, SpriteEffects.FlipHorizontally, 1);
                                }
                                if (flipHorizontal)
                                {

                                    batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 1.5f, SpriteEffects.FlipHorizontally, 1);
                                }

                                else
                                {

                                    batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 1.5f, SpriteEffects.None, 1);
                                }
                            }
                            else
                            {
                                if (proj.IsRunning)
                                {


                                    batch.Draw(Texture, location1, sourceRectangleProjectile, Color.Red, 0.01f, origin, 1.5f, SpriteEffects.FlipHorizontally, 1);
                                }
                                if (flipHorizontal)
                                {

                                    batch.Draw(Texture, location, sourceRectangle, Color.Red, 0.01f, origin, 1.5f, SpriteEffects.FlipHorizontally, 1);
                                }

                                else
                                {

                                    batch.Draw(Texture, location, sourceRectangle, Color.Red, 0.01f, origin, 1.5f, SpriteEffects.None, 1);
                                }
                            }

                            hit++;
                        }
                        else
                        {
                            if (proj.IsRunning)
                            {


                                batch.Draw(Texture, location1, sourceRectangleProjectile, Color.White, 0.01f, origin, 1.5f, SpriteEffects.FlipHorizontally, 1);
                            }
                            if (flipHorizontal)
                            {

                                batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 1.5f, SpriteEffects.FlipHorizontally, 1);
                            }

                            else
                            {

                                batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 1.5f, SpriteEffects.None, 1);
                            }
                        }
                    }
                    if (deathCount >= 3)
                    {

                        topLeft.X = 0;
                        topLeft.Y = 0;
                        botRight.X = 0;
                        botRight.Y = 0;

                        if (explosionFrame < 50)
                        {


                            batch.Draw(Texture, new Vector2((int)currentPos.X + change + xOffset, (int)currentPos.Y + change + yOffset), new Rectangle(18 * rowdeathExplosion + 820, 338, 18, 23), Color.White, 0.01f, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
                            batch.Draw(Texture, new Vector2((int)currentPos.X + change + xOffset + 25, (int)currentPos.Y - change + yOffset + 25), new Rectangle(18 * rowdeathExplosion + 820, 338, 18, 23), Color.White, 135f, new Vector2(0, 0), 1f, SpriteEffects.FlipVertically, 1);
                            batch.Draw(Texture, new Vector2((int)currentPos.X - change + xOffset, (int)currentPos.Y - change + yOffset), new Rectangle(18 * rowdeathExplosion + 820, 338, 18, 23), Color.White, 0.01f, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
                            batch.Draw(Texture, new Vector2((int)currentPos.X - change + xOffset, (int)currentPos.Y + change + yOffset), new Rectangle(18 * rowdeathExplosion + 820, 338, 18, 23), Color.White, 0.01f, new Vector2(0, 0), 1f, SpriteEffects.FlipHorizontally, 1);
                        }
                        else
                        {
                            isAlive = false;
                        }
                        rowdeathExplosion++;
                        if (rowdeathExplosion == 5)
                        {
                            rowdeathExplosion = 0;
                        }
                        explosionFrame++;
                        change += 2;
                    }
                }
                batch.End();
                if (hit == 50)
                {
                    trigger++;
                    hit = 0;
                }
            }
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

