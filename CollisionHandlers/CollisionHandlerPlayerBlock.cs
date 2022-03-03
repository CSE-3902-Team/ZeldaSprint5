using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.CollisionHandlers
{
    public class CollisionHandlerPlayerBlock : ICollisionHandler
    {
        private Player player;
        private ITile block;
        private int overlap;
        private float xDirection;
        private float yDirection;
        private int currentDirection;
        private CollisionDirections collisionDirections;

        public enum CollisionDirections
        {
            North,
            South,
            East,
            West
        }
        
        public CollisionHandlerPlayerBlock(Player player, ITile block, CollisionDirections collisionDirections, int overlap)
        {
            this.player = player;
            this.block = block;
            this.overlap = overlap;
            this.collisionDirections = collisionDirections;

            xDirection = 0f;
            yDirection = 0f;

        }
        public void HandleCollision()
        {
            currentDirection = (int)collisionDirections;
            /*switch ((CollisionDirections)currentDirection)
            {
                case CollisionDirections.North:
                    yDirection = -1;
                    xDirection = 0;
                case CollisionDirections.East:
                    yDirection = 0;
                    xDirection = 1;
                case CollisionDirections.South:
                    yDirection = 1;
                    xDirection = 0;
                case CollisionDirections.West:
                    yDirection = 0;
                    xDirection = -1;
                default:
                    yDirection = 0;
                    xDirection = 0;
            }
            */
            
            //player.Position = new Vector2(player.Position.X + (xDirection * (float)overlap), player.Position.Y + xDirection * (float)overlap);
        }
    }
}
