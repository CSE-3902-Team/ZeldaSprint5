using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collision
{
    class CollisionHandlerEnemyProjectile : ICollisionHandler
    {
        private IEnemySprite enemy;
        private IProjectile projectile;
        private int overlap;
        private CollisionDirections collisionDirections;
        private int deathcount;
        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);


        public CollisionHandlerEnemyProjectile(IEnemySprite enemy, IProjectile projectile, CollisionDirections collisionDirections, int overlap)
        {
            this.enemy = enemy;
            this.projectile = projectile;
            this.overlap = overlap;
            this.collisionDirections = collisionDirections;

        }
        public void HandleCollision()
        {
            if (this.projectile is Sprint0.enemy.EnemyProjectile)
            {
                return;
            }
            enemy.deathCount++;
         
       
          
     
        
            projectile.IsRunning = false;

        }


        
    }
}

