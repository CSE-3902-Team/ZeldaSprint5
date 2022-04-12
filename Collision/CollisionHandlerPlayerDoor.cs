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
        const int locationSquareOffsetX = 45;
        const int locationSquareOffsetY = 28;
        const int mapSquareOffset = 40;
        public CollisionHandlerPlayerDoor(Player p, ADoor d, CollisionDirections dir, int o)
        {
            player = p;
            door = d;
            overlap = o;
            direction = dir;
        }

        public void HandleCollision()
        {
            if (door is DoorClosed || door is DoorWall)
            {
                MovePlayerAwayFromDoor();
            }
            else if (door is DoorOpen || door is DoorHole)
            {
                Console.WriteLine("Room transition");
                door.ChangeRoom();
                if (door.DoorSide == DoorFactory.Side.Top)
                {
                    player.Position = new Vector2(512, 796);
                    player.Inventory.MapLocationY = (player.Inventory.MapLocationY - locationSquareOffsetY);
                    player.Inventory.MapSquareLocationY = (player.Inventory.MapSquareLocationY - mapSquareOffset);

                }
                else if (door.DoorSide == DoorFactory.Side.Left)
                {
                    player.Position = new Vector2(857, 603);
                    player.Inventory.MapLocationX = (player.Inventory.MapLocationX - locationSquareOffsetX);
                    player.Inventory.MapSquareLocationX = (player.Inventory.MapSquareLocationX - mapSquareOffset);
                }
                else if (door.DoorSide == DoorFactory.Side.Right)
                {
                    player.Position = new Vector2(167, 603);
                    player.Inventory.MapLocationX = (player.Inventory.MapLocationX + locationSquareOffsetX);
                    player.Inventory.MapSquareLocationX = (player.Inventory.MapSquareLocationX + mapSquareOffset);
                }
                else if (door.DoorSide == DoorFactory.Side.Bottom)
                {
                    player.Position = new Vector2(512, 427);
                    player.Inventory.MapLocationY = (player.Inventory.MapLocationY + locationSquareOffsetY);
                    player.Inventory.MapSquareLocationY = (player.Inventory.MapSquareLocationY + mapSquareOffset);

                }
            }
            else if (door is DoorLocked)
            {
                if (player.Inventory.KeyCount > 0)
                {
                    UnlockDoor(LevelManager.Instance.currentRoomNum, door.DoorSide);
                    player.Inventory.KeyCount--;
                }
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
