using Microsoft.Xna.Framework;
using System;
using Sprint0.TileClass;
using Sprint0.LevelClass;

namespace Sprint0.Collision
{
    public class CollisionHandlerPlayerBlock : ICollisionHandler
    {
        private Player player;
        private ITile block;
        private int overlap;
        private CollisionDirections collisionDirections;


        public CollisionHandlerPlayerBlock(Player player, ITile block, CollisionDirections collisionDirections, int overlap)
        {
            this.player = player;
            this.block = block;
            this.overlap = overlap;
            this.collisionDirections = collisionDirections;

        }
        public void HandleCollision()
        {
            if (player.PlayerHp == 0)
            {
                return;
            }
            float xDirection;
            float yDirection;
            if (block.GetType() == typeof(StairsTile)) {
                LevelManager.Instance.RoomTransition(1, DoorClass.DoorFactory.Side.Floor);
            }
            switch (collisionDirections)
            {
                case CollisionDirections.North:
                    yDirection = -1;
                    xDirection = 0;
                    break;
                case CollisionDirections.East:
                    yDirection = 0;
                    xDirection = 1;
                    break;
                case CollisionDirections.South:
                    yDirection = 1;
                    xDirection = 0;
                    break;
                case CollisionDirections.West:
                    yDirection = 0;
                    xDirection = -1;
                    break;
                default:
                    yDirection = 0;
                    xDirection = 0;
                    break;
            }

            if (!(block is PushableTile))
            {
                player.Position = new Vector2(player.Position.X + (xDirection * overlap), player.Position.Y + yDirection * (float)overlap);
            }
            else
            {
                player.Position = new Vector2(player.Position.X + overlap*(xDirection), player.Position.Y + overlap *(yDirection));
                block.Position = new Vector2(block.Position.X + overlap*(xDirection * -1), block.Position.Y + overlap*(yDirection * -1));
            }

            //Console.WriteLine("yDirection=" + yDirection);
        }
    }
}
