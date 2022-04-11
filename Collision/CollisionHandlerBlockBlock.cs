using Microsoft.Xna.Framework;
using System;
using Sprint0.TileClass;

namespace Sprint0.Collision
{
    public class CollisionHandlerBlockBlock : ICollisionHandler
    {
        private ITile agiatorBlock;
        private ITile orginBlock;
        private int overlap;
        private CollisionDirections collisionDirections;


        public CollisionHandlerBlockBlock(ITile agiatorBlock, ITile orginBlock, CollisionDirections collisionDirections, int overlap)
        {
            this.agiatorBlock = agiatorBlock;
            this.orginBlock = orginBlock;
            this.overlap = overlap;
            this.collisionDirections = collisionDirections;

        }
        public void HandleCollision()
        {
            float xDirection;
            float yDirection;

            if(orginBlock is SolidNavyTile)
            {
                return;
            }

            if (!(agiatorBlock is PushableTile)) {
                return;
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
            agiatorBlock.Position = new Vector2(agiatorBlock.Position.X + overlap*(xDirection), agiatorBlock.Position.Y + overlap*(yDirection));

        }
    }
}
