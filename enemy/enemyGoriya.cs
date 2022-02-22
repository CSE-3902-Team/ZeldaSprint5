using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint0.enemy
{
    public class enemyGoriya : IEnemySprite
    {
        public Texture2D Texture;

        private int currentFrame;
        private int total;
        private SpriteBatch batch;
        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);
        private int currentX;
        private int currentY;
        private int pCurrentX;
        private int pCurrentY;
        private int randomNum;
        private int Axis;
        private int flip;
        int x = 400;
        int y = 200;
        private int frame;
        private int frame1;
        private int frame2;
        private int currentFrame1 = 0;
        bool flipHorizontal = false;
        bool fire = false;
     
        public enemyGoriya(Texture2D texture, SpriteBatch batch, Vector2 location)
        {
            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentX = (int)location.X;
            currentY = (int)location.Y;


        }

        public void Update()
        {
            // the goriya will fire every 210 frames, and reset frame counts
            if (frame1 == 210)
            {
                fire = true;
                pCurrentX = currentX;
                pCurrentY = currentY;
                frame1 = 0;
                frame2 = 0;
            }
            //every 5 frames, display next pos instead of every frame
            if (frame == 5)
            {
                switch (Axis)
                {//make the enemies move in a random route.

                    case 0:
                        if (currentY < y)
                        {



                            currentFrame = 0;

                        }
                        if (currentY > y)
                        {

                            currentFrame = 1;

                        }
                        break;
                        //moving to up down left and right
                    case 1:
                        if (currentX < x)
                        {
                            total = 4;
                            currentFrame++;
                            if (currentFrame >= total)
                                currentFrame = 2;

                        }
                        if (currentX > x)
                        {
                            total = 4;
                            currentFrame++;
                            if (currentFrame >= total)
                                currentFrame = 2;

                        }
                        break;
                }
                frame = 0;
            }
            if (!fire)
            {
                switch (Axis)
                {

                    case 0:
                        if (currentY < y)

                            currentY++;
                        else if (currentY > y)
                            currentY--;

                        break;
                    case 1:
                        if (currentX < x)
                        {
                            currentX++;
                            flipHorizontal = false;
                        }
                        else if (currentX > x)
                        {
                            currentX--;
                            flipHorizontal = true;
                        }
                        break;

                }
                frame1++;
            }
            // fire projectile here, this is for the forward part of projectile, since it's boomerang, it will fly back.
            else
            {
                frame2++;
                if (frame == 3)
                {
                    currentFrame1++;
                    if (currentFrame1 > 2)
                        currentFrame1 = 0;
                }
                if (frame2 < 100)
                {
                    switch (Axis)
                    {

                        case 0:
                            if (currentY < y)

                                pCurrentY+=2;
                            else if (currentY > y)
                                pCurrentY-=2;

                            break;
                        case 1:
                            if (currentX < x)
                            {
                                pCurrentX+=2;
                            }
                            else if (currentX > x)
                            {
                                pCurrentX-=2;
                            }
                            break;
                    }
                }
                //after the boomerang reaches the destination, it will fly back, similar logic as above, but the projectile's y and x are decreasing this time
                if (frame2 >= 100)
                {
                    switch (Axis)
                    {

                        case 0:
                            if (currentY < y)

                                pCurrentY-=2;
                            else if (currentY > y)
                                pCurrentY+=2;

                            break;
                        case 1:
                            if (currentX < x)
                            {
                                pCurrentX-=2;
                            }
                            else if (currentX > x)
                            {
                                pCurrentX+=2;
                            }
                            break;
                    }
                }
                if (frame2 == 200)
                    fire = false;

            }

           //when it reaches the destination set from previous random call, call random for next movement
                if (currentX == x || currentY == y)
                {
                   
                    randomNum = getDistance.Next(50, 100);
                   Axis = coinFlipForAxis.Next(0, 2);
                    flip = coinFlipForDirection.Next(0, 2);

                    switch (Axis)
                    {

                        case 0:
                            if (flip == 0)
                                x = currentX + randomNum;
                            else
                                x = currentX - randomNum;
                            break;
                        case 1:
                            if (flip == 1)
                                y = currentY + randomNum;
                            else
                                y = currentY - randomNum;
                            break;
                    }
           

            }

         

            frame++;
          
            }


            public Vector2 draw()
            {
                Vector2 temp = new Vector2();
                Vector2 origin = new Vector2(0, 0);
                Vector2 location = new Vector2(currentX, currentY);
                int row = currentFrame;
                int row1 = currentFrame1;

                Rectangle sourceRectangle = new Rectangle(16 * row + 222, 11, 16, 16);
                Rectangle sourceRectangleProjectile = new Rectangle(8 * row1 + 289, 11, 8, 16);
                Rectangle destinationRectangle = new Rectangle(currentX, currentY, 40, 40);
                Vector2 location1 = new Vector2(pCurrentX, pCurrentY);

            
                batch.Begin();
           
               if(fire)
                    batch.Draw(Texture, location1, sourceRectangleProjectile, Color.White, 0.01f, origin, 2f, SpriteEffects.FlipHorizontally, 1);
                    if (flipHorizontal)
                        batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 3f, SpriteEffects.FlipHorizontally, 1);

                    else
                        batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 3f, SpriteEffects.None, 1);

              
                batch.End();
                temp.X = currentX;
                temp.Y = currentY;
                return temp;
            }



        }
    }

