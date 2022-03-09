using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collision
{
    class CollisionHandlerProjectileTile : ICollisionHandler
    { 
    private IProjectile projectile;


        public CollisionHandlerProjectileTile(IProjectile p)
        {
            projectile = p;
        }
        public void HandleCollision()
        {
            projectile.IsRunning = false;
        }
    }
}
