using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.enemy
{
    class CollisionHandlerEnemyProjectile : ICollisionHandler
    {

        private Vector2 movement;
        Vector2 result;
    
        public Vector2 currentPos;

        public Player link;
  
        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);


        public CollisionHandlerEnemyProjectile(Vector2 Direction, Vector2 CurrentPos, Vector2 Destination, Player player)
        {
            this.result = Destination;
            this.movement = Direction;
            this.currentPos = CurrentPos;
            link = player;

        }
        public void HandleCollision()
        {
            //if((link.pPosition.X>=(currentPos.X-64)&& link.pPosition.X <= (currentPos.X + 64))&& (link.pPosition.Y >= (currentPos.Y -64) && link.pPosition.Y <= (currentPos.Y + 64)))
            //    Console.WriteLine("hit");

        }


        
    }
}

