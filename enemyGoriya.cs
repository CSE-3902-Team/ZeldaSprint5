using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint0
{
    public class enemyGoriya : IEnemySprite
    {
        public Texture2D Texture;

        private int currentFrame;
        private int total;
        private SpriteBatch batch;
        Random temp = new Random();
        Random temp1 = new Random();
        Random temp2 = new Random();
        private int currentX;
        private int currentY;
        private int randomNum;
        private int direction;
        private int flip;
        int x = 400;
        int y = 200;
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
            switch (direction)
            {//make the enemies move in a random route.

                case 0:
                    if (currentY < y)
                    {


                    
                            currentFrame = 0;
                        currentY++;
                    }
                    if (currentY > y)
                    {

                        currentFrame = 1;
                        currentY--;
                    }
                    break;
                case 1:
                    if (currentX < x)
                    {
                        total = 4;
                        currentFrame++;
                        if (currentFrame >= total)
                            currentFrame = 2;
                        currentX++;
                    }
                    if (currentX > x)
                    {
                        total = 4;
                        currentFrame++;
                        if (currentFrame >= total)
                            currentFrame = 2;
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



        }


        public Vector2 draw()
        {
            Vector2 temp = new Vector2();

            int row = currentFrame;

            Rectangle sourceRectangle = new Rectangle(16 * row + 222, 11, 16, 16);
            Rectangle destinationRectangle = new Rectangle(currentX, currentY, 40, 40);



            batch.Begin();
            batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            Thread.Sleep(90);

            batch.End();
            temp.X = currentX;
            temp.Y = currentY;
            return temp;
        }


    }
}
