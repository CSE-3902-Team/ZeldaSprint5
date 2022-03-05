using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.PlayerClass;

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

            //TODO: Reduce coupling by passing direction into state and letting it handle the state positions. Collisions shouldn't know
            //about states
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

            //Console.WriteLine("yDirection=" + yDirection);
        }
    }
}
