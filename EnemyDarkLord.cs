using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint0
{
   public class EnemyDarkLord:IEnemySprite
    {
        public Texture2D Texture;

        private int currentFrame;
        private int total;
        private SpriteBatch batch;
        Random temp = new Random();
        Random temp1 = new Random();
        private int currentX=400;
        private int currentY = 200;
        private int randomNum;
        private int direction;
        int x = 400;
        int y = 200;
        public EnemyDarkLord(Texture2D texture, SpriteBatch batch)
        {
            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            total = 2;
       
           
        }

        public void Update()
        {
            switch (direction)
            {//make the enemies move in a random route.

                case 0:
                    if (currentY < y)
                    {
                        currentY++;
                       
                        currentFrame++;
                        if (currentFrame >= total)
                            currentFrame = 0;

                    }
                    if (currentY > y)
                    {
                        currentY--;
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
                        currentX++;
                    }
                    if (currentX > x)
                    {
                        total = 5;
                        currentFrame++;
                        if (currentFrame >= total)
                            currentFrame = 3;
                        currentX--;
                    }
                    break;
            }
            if (currentX == x||currentY==y)
            {
                randomNum = temp.Next(-60, 80);
                direction = temp1.Next(0, 2);
                switch (direction)
                {

                    case 0:
                        x += randomNum;
                        break;
                    case 1:
                        y += randomNum;
                        break;
                }

            }


          
        }

      

        public void draw()
        {


            int row = currentFrame;

            Rectangle sourceRectangle = new Rectangle(16 * row+2, 90, 16, 16);
            Rectangle destinationRectangle = new Rectangle(currentX, currentY, 40,40);

           batch.Begin();
           batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            Thread.Sleep(90);
            batch.End();
        }

       
    }
}
