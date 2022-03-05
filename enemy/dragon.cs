using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
        private int currentX = 400;
        private int currentY = 200;
        private int FireBallCurrentX = 400;
        private int FireBallCurrentY = 200;
        private int FireBallCurrentY1 = 200;
        private int FireBallCurrentY2 = 200;

        private Vector2 direction;
        private Vector2 currentPos;
        private Vector2 destination;
        int x =600;

        private int frame;
        private int frame1;

        private TopLeft topLeft;
        private BottomRight botRight;



        public bossDragon(Texture2D texture, SpriteBatch batch, Vector2 location)
        {
            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentPos.Y = 200;
            currentPos.X = 400;
            destination.X = 400;
            destination.Y = 200;
            topLeft = new TopLeft(400, 200,this);
            botRight = new BottomRight(480, 300, this);

        }

        public void Update()
        {
            FrameChaningforEnemy action = new FrameChaningforEnemy(currentPos, direction, destination, currentFrame);
            FrameChaningforEnemy dragonBreath = new FrameChaningforEnemy(currentPos, direction, destination, FireBallCurrentFrame);
            MoveEnemy dragonMove = new MoveEnemy(direction, currentPos, destination);
            Vector2 result = dragonMove.DragonMove();
            if (frame == 5)
            {
          
                currentFrame = action.dragon();
                FireBallCurrentFrame = dragonBreath.fireBall();
               
                
                frame = 0;
            }
         
            currentPos.X = result.Y;
            destination.X = result.X;
            if (frame1==200 )
            {
                fire = true;
                frame1 = 0;
                FireBallCurrentX = (int)currentPos.X - 15;
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
            UpdateCollisionBox();
        }

        
        public Vector2 draw()
        {

            Vector2 temp = new Vector2();
            int row = currentFrame;
            int rowFireBall = FireBallCurrentFrame;

            Rectangle sourceRectangle = new Rectangle(25 * row , 11, 24, 32);
            Rectangle FireballSourceRectangle = new Rectangle(9* rowFireBall+100, 11,8, 15);

            Rectangle destinationRectangle = new Rectangle((int)currentPos.X, (int)currentPos.Y, 80,100);
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

        private void UpdateCollisionBox()
        {
            topLeft.X = (int)currentPos.X;
            topLeft.Y = (int)currentPos.Y;
            botRight.X = (int)currentPos.X + 80;
            botRight.Y = (int)currentPos.Y + 100;

        }


    }
}
