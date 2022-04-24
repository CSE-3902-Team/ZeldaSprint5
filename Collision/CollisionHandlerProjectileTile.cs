using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.TileClass;
namespace Sprint0.Collision
{
    class CollisionHandlerProjectileTile : ICollisionHandler
    { 
    private IProjectile projectile;

        ITile tile;
        public CollisionHandlerProjectileTile(IProjectile p, ITile t)
        {
            projectile = p;
            tile = t;
        }
        public void HandleCollision()
        {
            if (tile is SolidNavyTile) {
                return;
            }
            if (tile is WallCollisionBox && projectile is ProjectilePlayerBoomerang)
            {
                ProjectilePlayerBoomerang boomerang = projectile as ProjectilePlayerBoomerang;
                boomerang.IsReturning = true;
                return;
            }
            else if (tile is WallCollisionBox && projectile is ProjectilePlayerSpecialBoomerang) {
                ProjectilePlayerSpecialBoomerang boomerang = projectile as ProjectilePlayerSpecialBoomerang;
                boomerang.IsReturning = true;
                return;
            }
            projectile.IsRunning = false;
        }
    }
}
