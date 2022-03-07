using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.enemy
{
    class CollisionHandlerEnemyBlock:ICollisionHandler
    {
      
     
        private Vector2 direction;
        public Vector2 currentPos;
        private Vector2 destination;
        public Vector2 result;
        Rectangle destinationRectangle;
        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);
        public Vector2 Pos
        {
            get { return Pos; }
            set { }
        }
        public CollisionHandlerEnemyBlock(Vector2 Direction, Vector2 CurrentPos,  Vector2 Destination)
        {
            this.destination = Destination;
            this.direction = Direction;
            this.currentPos = CurrentPos;
       
        }
        public void HandleCollision()
        {

    

        }
        public Vector2 AvoidCollision()
        {
            if (destinationRectangle.Right == 790 || (destinationRectangle.Bottom == 500)|| destinationRectangle.Top==130||destinationRectangle.Left==140)
            {
                destination.X = currentPos.X;
                destination.Y=currentPos.Y;
                Console.WriteLine("yes");
                
            }
            return destination;
        }
        public void UpdateCollisionBox()
        {
             destinationRectangle = new Rectangle((int)currentPos.X, (int)currentPos.Y, 64, 64);

        }
    }
    }

