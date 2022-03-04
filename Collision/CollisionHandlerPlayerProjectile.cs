using System;

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

            switch (collisionDirections)
            {
                case CollisionDirections.North:
                    yDirection = 1;
                    xDirection = 0;
                    break;
                case CollisionDirections.East:
                    yDirection = 0;
                    xDirection = -1;
                    break;
                case CollisionDirections.South:
                    yDirection = -1;
                    xDirection = 0;
                    break;
                case CollisionDirections.West:
                    yDirection = 0;
                    xDirection = 1;
                    break;
                default:
                    yDirection = 0;
                    xDirection = 0;
                    break;
            }

            Console.WriteLine("yDirection=" + yDirection);
            projectile.IsRunning = false;
            // player.State = new PlayerInjuredState(xDirection, yDirection);
        }
    }
}
