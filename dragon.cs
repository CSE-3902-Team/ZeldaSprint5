using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint0
{
    public class bossDragon : IEnemySprite
    {

        public Texture2D Texture;

        private int currentFrame;
        private int FireBallCurrentFrame;
        private int total;
        private SpriteBatch batch;
        private bool fire;
        private int currentX = 400;
        private int currentY = 200;
        private int FireBallCurrentX = 400;
        private int FireBallCurrentY = 200;
        private int FireBallCurrentY1 = 200;
        private int FireBallCurrentY2 = 200;

        int x =600;
        int y = 200;
        private int frame;
        private int frame1;
        public bossDragon(Texture2D texture, SpriteBatch batch, Vector2 location)
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
                if (currentX < x)
                {

                    total = 4;
                    currentFrame++;
            
                    if (currentFrame >= total)
                        currentFrame = 0;

                }
                if (currentX >= x)
                {
                  
                    total = 4;
                    currentFrame++;
                  
                    if (currentFrame >= 4)
                        currentFrame = 0;

                }
             
                    total = 5;
                    FireBallCurrentFrame++;

                    if (FireBallCurrentFrame >=5)
                        FireBallCurrentFrame = 0;
                
                frame = 0;
            }
            if (currentX < x)
            {
                x = 600;
                currentX++;
            }
            if (currentX >= x)
            {
                x = 400;
                currentX--;
            }
            if (frame1==200 )
            {
                fire = true;
                frame1 = 0;
                FireBallCurrentX = currentX-15;
            }
            if (fire)
            {
           
                FireBallCurrentX-=3;
                FireBallCurrentY1--;
         FireBallCurrentY2 ++;
                if (FireBallCurrentY1 <= 0)
                {
             
                    fire = false;
                 FireBallCurrentY = 200;
        FireBallCurrentY1 = 200;
         FireBallCurrentY2 = 200;
    }
    }
            frame++;
            frame1++;

        }

        
        public Vector2 draw()
        {

            Vector2 temp = new Vector2();
            int row = currentFrame;
            int rowFireBall = FireBallCurrentFrame;

            Rectangle sourceRectangle = new Rectangle(25 * row , 11, 24, 32);
            Rectangle FireballSourceRectangle = new Rectangle(9* rowFireBall+100, 11,8, 15);

            Rectangle destinationRectangle = new Rectangle(currentX, currentY, 80,100);
            Rectangle FireBallDestinationRectangle = new Rectangle(FireBallCurrentX, FireBallCurrentY, 20, 20);
            Rectangle FireBallDestinationRectangle1 = new Rectangle(FireBallCurrentX, FireBallCurrentY1, 20, 20);
            Rectangle FireBallDestinationRectangle2= new Rectangle(FireBallCurrentX, FireBallCurrentY2, 20, 20);
            batch.Begin();
            batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            if (fire)
            {
                batch.Draw(Texture, FireBallDestinationRectangle, FireballSourceRectangle, Color.White);
                batch.Draw(Texture, FireBallDestinationRectangle1, FireballSourceRectangle, Color.White);
                batch.Draw(Texture, FireBallDestinationRectangle2, FireballSourceRectangle, Color.White);
            }

            batch.End();
      
            return temp;
        }


    }
}
