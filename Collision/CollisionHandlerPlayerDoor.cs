using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.DoorClass;
using Microsoft.Xna.Framework;

namespace Sprint0.Collision
{

    class CollisionHandlerPlayerDoor : ICollisionHandler
    {
        Player player;
        ADoor door;
        CollisionDirections direction;
        int overlap;

        public CollisionHandlerPlayerDoor(Player p, ADoor d, CollisionDirections dir, int o)
        {
            player = p;
            door = d;
            overlap = o;
            direction = dir;
        }

        public void HandleCollision()
        {
            if (door is DoorClosed || door is DoorLocked || door is DoorWall)
            {
                MovePlayerAwayFromDoor();
            }
            else if (door is DoorOpen || door is DoorHole) {
                Console.WriteLine("Room transition");
                door.ChangeRoom();
                player.Position = new Vector2(540,609);
            }

        }
        public void MovePlayerAwayFromDoor() { 
            int xDirection;
            int yDirection;
            switch (direction)
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
            player.Position = new Vector2(player.Position.X + (xDirection * overlap), player.Position.Y + (yDirection * overlap));
        }


    }
}
