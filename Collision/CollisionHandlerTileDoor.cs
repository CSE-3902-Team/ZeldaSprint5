using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.DoorClass;
using Sprint0.LevelClass;
using Microsoft.Xna.Framework;
using Sprint0.TileClass;

namespace Sprint0.Collision
{

    class CollisionHandlerTileDoor : ICollisionHandler
    {
        ITile tile;
        ADoor door;
        CollisionDirections collisionDirections;
        int overlap;

        
        public CollisionHandlerTileDoor(ITile t, ADoor d, CollisionDirections c, int o)
        {
            tile = t;
            door = d;
            overlap = o;
            collisionDirections = c;
        }

        public void HandleCollision()
        {
            float xDirection;
            float yDirection;

            if (!(tile is PushableTile))
            {
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

            tile.Position = new Vector2(tile.Position.X + overlap * (xDirection), tile.Position.Y + overlap * (yDirection));

        }

        






    }
}
