using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Sprint0.ItemClass;
using static Sprint0.ItemClass.ItemSpriteFactory;

namespace Sprint0.enemy
{
    public class enemySkeleton : IEnemySprite, IBoxCollider
    {

        public Texture2D Texture;
        private static Texture2D rect;
        private int currentFrame;
        private int trigger;
     
        private int hit;
        private SpriteBatch batch;
        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);
        private int flipHorizontally;
        public  Vector2 direction;
        private int change;
        public int explosionFrame;
        private Vector2 currentPos;
        private int row;
        public Game1 game;
        public int cloudAppear;
        Player link;

        private readonly TopLeft topLeft;
        private readonly BottomRight bottomRight;
        private bool isAlive;

   
        public Vector2 position
        {
            get { return currentPos; }
            set
            {
                currentPos = value;
                UpdateCollisionBox();

            }
        }
        private int DeathCount;
        public int deathCount
        {
            get { return DeathCount; }
            set { DeathCount = value; }
        }
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; UpdateCollisionBox(); }
        }

        public Vector2 Destination
        {
            get { return destination; }
            set
            {
                destination = value;


            }
        }


        private Vector2 destination;
        int x = 400;
        int y = 200;
        private int frame;

        public TopLeft TopLeft
        {
            get { return topLeft; }
        }
        public BottomRight BottomRight
        {
            get { return bottomRight; }
        }
        public enemySkeleton(Texture2D texture, SpriteBatch batch, Vector2 location,Player player)
        {

            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentPos = location;
            destination = location;
            link = player;
            topLeft = new TopLeft(400, 200, this);
            bottomRight = new BottomRight(440, 240, this);
            isAlive = true;
        

        }

        public void Update()
        {
            if (isAlive && deathCount < 6)
            {

                FrameChaningforEnemy action = new FrameChaningforEnemy(currentPos, direction, destination, currentFrame);
                MoveEnemy move = new MoveEnemy(direction, currentPos, destination);
                NewDestination makeNextMove = new NewDestination(direction, currentPos, destination);


                if (frame == 5)
                {

                    currentFrame = action.frameReturn();
                    frame = 0;
                }


                currentPos = move.Move();

                direction = makeNextMove.RollingDice1();

                destination = makeNextMove.RollingDice();



                frame++;



                UpdateCollisionBox();
            }
            

        }

        public void draw() {
            draw(0, 0);
        }
    
        public void draw(int xOffset, int yOffset)
        {
            Vector2 location = new Vector2((int)currentPos.X+xOffset, (int)currentPos.Y+yOffset);
            Vector2 origin = new Vector2(0, 0);
            Rectangle sourceRectangle = new Rectangle(2, 140, 32, 45);

            

            if (isAlive)
            { 
                batch.Begin();
                if (deathCount < 6)
                {
              
                     

                    if (trigger != deathCount && hit < 50)
                    {
                        if (currentFrame % 2 == 0)
                        {
                            batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 1.5f, SpriteEffects.FlipHorizontally, 1);
                        }
                        else
                        {
                            batch.Draw(Texture, location, sourceRectangle, Color.Red, 0.01f, origin, 1.5f, SpriteEffects.None, 1);
                        }

                        hit++;
                    }
                    else
                    {
                        if (currentFrame % 2 == 0)
                        {
                            batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 1.5f, SpriteEffects.FlipHorizontally, 1);
                        }
                        else
                        {
                            batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 1.5f, SpriteEffects.None, 1);
                        }
                    }

                    if (hit == 50)
                    {
                        trigger++;
                        hit = 0;
                    }
                }
                if (deathCount >= 6)
                {
                  
                    topLeft.X = 0;
                    topLeft.Y = 0;
                    bottomRight.X = 0;
                    bottomRight.Y = 0;

                    if (explosionFrame < 50)
                    {


                        batch.Draw(Texture, new Vector2((int)currentPos.X + change + xOffset, (int)currentPos.Y + change + yOffset), new Rectangle(18 * row + 820, 338, 18, 23), Color.White, 0.01f, origin, 1f, SpriteEffects.None, 1);
                        batch.Draw(Texture, new Vector2((int)currentPos.X + change + xOffset+25, (int)currentPos.Y - change + yOffset+25), new Rectangle(18 * row + 820, 338, 18, 23), Color.White,135f, origin, 1f, SpriteEffects.FlipVertically, 1);
                        batch.Draw(Texture, new Vector2((int)currentPos.X - change + xOffset, (int)currentPos.Y- change + yOffset), new Rectangle(18 * row + 820, 338, 18, 23), Color.White, 0.01f, origin, 1f, SpriteEffects.None, 1);
                        batch.Draw(Texture, new Vector2((int)currentPos.X - change + xOffset, (int)currentPos.Y + change + yOffset), new Rectangle(18 * row + 820, 338, 18, 23), Color.White, 0.01f, origin, 1f, SpriteEffects.FlipHorizontally, 1);
                    }
                    else if(explosionFrame >= 50)
                    {
                        isAlive = false;
                        deathCount = 0;
                                }
                    row++;
                    if (row == 5)
                    {
                        row = 0;
                    }
                    explosionFrame++;
                    change += 2;
                }
                batch.End();
            }
       
        }

        private void UpdateCollisionBox() {

            topLeft.X = (int)currentPos.X ;
                topLeft.Y = (int)currentPos.Y;
                bottomRight.X = (int)currentPos.X +30;
                bottomRight.Y = (int)currentPos.Y +35;
            
        
        }
    }
}
 