using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.PlayerClass;
using Sprint0.LevelClass;

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
            if (player.PlayerHp == 0)
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
           SoundManager.Instance.Play(SoundManager.Sound.LinkHurt);
            
            //Console.WriteLine("yDirection=" + yDirection);
        }
    }
}
