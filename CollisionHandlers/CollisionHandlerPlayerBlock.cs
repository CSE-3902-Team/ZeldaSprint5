using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.CollisionHandlers
{
    public class CollisionHandlerPlayerBlock : ICollisionHandler
    {
        private Player player;
        private ITile block;
        //private enum CollisionsDirections collisionsDirection;
        private int overlap;
        private int xDirection;
        private int yDirection;
        public CollisionHandlerPlayerBlock(Player player, ITile block, int overlap)
        {
            this.player = player;
            this.block = block;
            this.overlap = overlap;
            //this.collisionDirection = collisionDirection;
        }
        public void HandleCollision()
        {
            
        }
    }
}
