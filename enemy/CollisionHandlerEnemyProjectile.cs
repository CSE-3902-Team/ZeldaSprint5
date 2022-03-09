using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collision
{
    class CollisionHandlerEnemyProjectile : ICollisionHandler
    {
        private IEnemySprite enemy;
        private ITile block;
        private int overlap;
        private CollisionDirections collisionDirections;

        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);


        public CollisionHandlerEnemyProjectile(IEnemySprite enemy, ITile block, CollisionDirections collisionDirections, int overlap)
        {
            this.enemy = enemy;
            this.block = block;
            this.overlap = overlap;
            this.collisionDirections = collisionDirections;

        }
        public void HandleCollision()
        {
            enemy.IsAlive = false;

        }


        
    }
}

