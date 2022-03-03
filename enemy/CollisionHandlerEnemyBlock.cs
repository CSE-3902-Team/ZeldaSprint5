using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.enemy
{
    class CollisionHandlerEnemyBlock:ICollisionHandler
    {
        int enemyX;
        int enemyY;
        public CollisionHandlerEnemyBlock(int currentX,int currentY)
        {
            this.enemyX = currentX;
            this.enemyY = currentY;
        }
        public void HandleCollision()
        {

        }
    }
}
