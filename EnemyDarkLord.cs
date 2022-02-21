using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint0
{
    public class EnemyDarkLord : IEnemySprite
    {
        public Texture2D Texture;

        private int currentFrame;
        private int total;
        private SpriteBatch batch;
        Random temp = new Random();
        Random temp1 = new Random();
        Random temp2 = new Random();
        private int currentX = 400;
        private int currentY = 200;
        private int randomNum;
        private int direction;
        private int flip;
        int x = 400;
        int y = 200;
        private int frame;
        bool flipHorizontal = false;
        public EnemyDarkLord(Texture2D texture, SpriteBatch batch, Vector2 location)
        {
            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentX = (int)location.X;
            currentY = (int)location.Y;




        }

        public void Update()
        {
            if (frame == 5)
            {
                switch (direction)
                {//make the enemies move in a random route.

                    case 0:
                        if (currentY < y)
                        {


                            total = 2;
                            currentFrame++;
                            if (currentFrame >= total)
                                currentFrame = 0;
                           
                        }
                        if (currentY > y)
                        {

                            currentFrame = 2;
                          
                        }
                        break;
                    case 1:
                        if (currentX < x)
                        {
                            total = 5;
                            currentFrame++;
                            if (currentFrame >= total)
                                currentFrame = 3;
                            
                        }
                        if (currentX > x)
                        {
                            total = 5;
                            currentFrame++;
                            if (currentFrame >= total)
                                currentFrame = 3;
                          
                        }

                        break;
                }

                frame = 0;
            }
            switch (direction)
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
                        flipHorizontal = false;

                        currentX++;
                    }
                    else if (currentX > x)
                    {

                        flipHorizontal = true;
                        currentX--;
                    }
                    break;
            }
            if (currentX == x || currentY == y)
            {
                randomNum = temp.Next(50, 100);
                direction = temp1.Next(0, 2);
                flip = temp2.Next(0, 2);

                switch (direction)
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

            Rectangle sourceRectangle = new Rectangle(16 * row+2, 90, 16, 16);
            Rectangle destinationRectangle = new Rectangle(currentX, currentY, 40,40);
       
           batch.Begin();
         if(flipHorizontal)
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
