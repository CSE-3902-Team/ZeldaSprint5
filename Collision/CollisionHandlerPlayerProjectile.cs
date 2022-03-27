using System;
using Sprint0.LevelClass;
namespace Sprint0.Collision
{
    public class CollisionHandlerPlayerProjectile : ICollisionHandler
    {
        private Player player;
        private IProjectile projectile;
        private CollisionDirections collisionDirections;
        public CollisionHandlerPlayerProjectile(Player player, IProjectile projectile, CollisionDirections collisionDirections)
        {
            this.player = player;
            this.projectile = projectile;
            this.collisionDirections = collisionDirections;

        }
        public void HandleCollision()
        {
            float xDirection;
            float yDirection;

            //Check for Friendly fire 
            if (projectile is ProjectilePlayerBoomerang)
            {
                projectile.IsRunning = false;
                return;
            }

            if (projectile is ProjectilePlayerSpecialBoomerang)
            {
                projectile.IsRunning = false;
                return;
            }

            if (projectile is ProjectilePlayerBomb)
            {
                return;
            }

            if (projectile is ProjectilePlayerFireball)
            {
                return;
            }

            if (projectile is ProjectilePlayerNormalArrow)
            {
                return;
            }

            if (projectile is ProjectilePlayerSpecialArrow)
            {
                return;
            }
     

            if (projectile is ProjectilePlayerSword)
            {
                return;
            }

            switch (collisionDirections)
            {
                case CollisionDirections.North:
                    player.DamageLink(Player.Directions.Down);

                    break;
                case CollisionDirections.East:
                    player.DamageLink(Player.Directions.Left);

                    break;
                case CollisionDirections.South:
                    player.DamageLink(Player.Directions.Up);
                    break;
                case CollisionDirections.West:
                    player.DamageLink(Player.Directions.Right);
                    break;
                default:
                    break;
            }
            LevelManager.Instance.SoundManager.Play(SoundManager.Sound.LinkHurt);
            projectile.IsRunning = false;

        }
    }
}
