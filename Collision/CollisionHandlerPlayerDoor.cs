using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.DoorClass;
using Microsoft.Xna.Framework;
using Sprint0.LevelClass;


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

            if (door is DoorLocked)//TODO Check for key
            {
                UnlockDoor(LevelManager.Instance.currentRoomNum, door.DoorSide);
            }

        }

        public void UnlockDoor(int roomNum, DoorFactory.Side targetSide)
        {
            ADoor[] doorlist = LevelManager.Instance.RoomList[roomNum].DoorList;
            DoorFactory factory = DoorFactory.Instance;
            for (int x = 0; x < doorlist.Length; x++)
            {
                if (doorlist[x].DoorSide == targetSide)
                {
                    doorlist[x].IsRunning = false;
                    doorlist[x] = factory.CreateDoorSprite(factory.getDoor("Normal"), targetSide, doorlist[x].connection);
                    LevelManager.Instance.RoomList[roomNum].ColliderDetector.AddToList(doorlist[x] as IBoxCollider);
                }
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
