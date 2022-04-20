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
        Player Player1;

        ADoor door;
        CollisionDirections direction;
        int overlap;
        const int locationSquareOffsetX = 45;
        const int locationSquareOffsetY = 28;
        const int mapSquareOffset = 40;
        public CollisionHandlerPlayerDoor(Player p, ADoor d, CollisionDirections dir, int o)
        {
            Player1 = p;
            door = d;
            overlap = o;
            direction = dir;

        }

        public void HandleCollision()
        {
            if (door is DoorClosed || door is DoorWall || door is WeakWall)
            {
                MovePlayerAwayFromDoor();
            }
            else if (door is DoorOpen || door is DoorHole || door is DoorInvisible)
            {
                door.ChangeRoom();
                if (door.DoorSide == DoorFactory.Side.Top)
                {
                    LevelManager.Instance.Player1.Position = new Vector2(512, 796);
                    if (LevelManager.Instance.TwoPlayer)
                    {
                        LevelManager.Instance.Player2.Position = new Vector2(512, 796);
                    }

                    LevelManager.Instance.Player1.Inventory.MapLocationY = (LevelManager.Instance.Player1.Inventory.MapLocationY - locationSquareOffsetY);
                    LevelManager.Instance.Player1.Inventory.MapSquareLocationY = (LevelManager.Instance.Player1.Inventory.MapSquareLocationY - mapSquareOffset);

                    if (LevelManager.Instance.TwoPlayer)
                    {
                        LevelManager.Instance.Player2.Inventory.MapLocationY = (LevelManager.Instance.Player2.Inventory.MapLocationY - locationSquareOffsetY);
                        LevelManager.Instance.Player2.Inventory.MapSquareLocationY = (LevelManager.Instance.Player2.Inventory.MapSquareLocationY - mapSquareOffset);
                    }
                }
                else if (door.DoorSide == DoorFactory.Side.Left)
                {
                    LevelManager.Instance.Player1.Position = new Vector2(857, 603);
                    if (LevelManager.Instance.TwoPlayer)
                    {
                        LevelManager.Instance.Player2.Position = new Vector2(857, 603);
                    }
                    LevelManager.Instance.Player1.Inventory.MapLocationX = (LevelManager.Instance.Player1.Inventory.MapLocationX - locationSquareOffsetX);
                    LevelManager.Instance.Player1.Inventory.MapSquareLocationX = (LevelManager.Instance.Player1.Inventory.MapSquareLocationX - mapSquareOffset);
                    if (LevelManager.Instance.TwoPlayer)
                    {
                        LevelManager.Instance.Player2.Inventory.MapLocationY = (LevelManager.Instance.Player2.Inventory.MapLocationY - locationSquareOffsetY);
                        LevelManager.Instance.Player2.Inventory.MapSquareLocationY = (LevelManager.Instance.Player2.Inventory.MapSquareLocationY - mapSquareOffset);
                    }
                }
                else if (door.DoorSide == DoorFactory.Side.Right)
                {
                    LevelManager.Instance.Player1.Position = new Vector2(167, 603);
                    if (LevelManager.Instance.TwoPlayer)
                    {
                        LevelManager.Instance.Player2.Position = new Vector2(167, 603);
                    }

                    LevelManager.Instance.Player1.Inventory.MapLocationX = (LevelManager.Instance.Player1.Inventory.MapLocationX + locationSquareOffsetX);
                    LevelManager.Instance.Player1.Inventory.MapSquareLocationX = (LevelManager.Instance.Player1.Inventory.MapSquareLocationX + mapSquareOffset);

                    if (LevelManager.Instance.TwoPlayer)
                    {
                        LevelManager.Instance.Player2.Inventory.MapLocationY = (LevelManager.Instance.Player2.Inventory.MapLocationY - locationSquareOffsetY);
                        LevelManager.Instance.Player2.Inventory.MapSquareLocationY = (LevelManager.Instance.Player2.Inventory.MapSquareLocationY - mapSquareOffset);
                    }
                }
                else if (door.DoorSide == DoorFactory.Side.Bottom)
                {
                    LevelManager.Instance.Player1.Position = new Vector2(512, 427);
                    if (LevelManager.Instance.TwoPlayer)
                    {
                        LevelManager.Instance.Player2.Position = new Vector2(512, 427);
                    }

                    LevelManager.Instance.Player1.Inventory.MapLocationY = (LevelManager.Instance.Player1.Inventory.MapLocationY + locationSquareOffsetY);
                    LevelManager.Instance.Player1.Inventory.MapSquareLocationY = (LevelManager.Instance.Player1.Inventory.MapSquareLocationY + mapSquareOffset);

                    if (LevelManager.Instance.TwoPlayer)
                    {
                        LevelManager.Instance.Player2.Inventory.MapLocationY = (LevelManager.Instance.Player2.Inventory.MapLocationY - locationSquareOffsetY);
                        LevelManager.Instance.Player2.Inventory.MapSquareLocationY = (LevelManager.Instance.Player2.Inventory.MapSquareLocationY - mapSquareOffset);
                    }

                }
                else if (door.DoorSide == DoorFactory.Side.Ceiling)
                {
                    LevelManager.Instance.Player1.Position = new Vector2(474, 609);
                    if (LevelManager.Instance.TwoPlayer)
                    {
                        LevelManager.Instance.Player2.Position = new Vector2(474, 609);
                    }
                }

            }
            else if (door is DoorLocked)
            {
                if (Player1.Inventory.KeyCount > 0)
                {
                    UnlockDoor(LevelManager.Instance.currentRoomNum, door.DoorSide);
                    Player1.Inventory.KeyCount--;
                }
                else
                {
                    MovePlayerAwayFromDoor();
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
            Player1.Position = new Vector2(Player1.Position.X + (xDirection * overlap), Player1.Position.Y + (yDirection * overlap));

        }


    }
}
