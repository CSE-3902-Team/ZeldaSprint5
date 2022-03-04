using System;

namespace Sprint0.Collision
{
    public class CollisionHandlerPlayerEnemy : ICollisionHandler
    {
        private Player player;
        private IEnemySprite enemy;
        private CollisionDirections collisionDirections;
        public CollisionHandlerPlayerEnemy(Player player, IEnemySprite enemy, CollisionDirections collisionDirections)
        {
            this.player = player;
            this.enemy = enemy;
            this.collisionDirections = collisionDirections;

        }
        public void HandleCollision()
        {
            float yDirection;
            float xDirection;
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
            // player.State = new PlayerInjuredState(xDirection, yDirection);
        }
    }
}
