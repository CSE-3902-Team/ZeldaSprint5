using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.DoorClass;
using Sprint0.LevelClass;
using Microsoft.Xna.Framework;

namespace Sprint0.Collision
{

    class CollisionHandlerProjectileDoor : ICollisionHandler
    {
        IProjectile projectile;
        ADoor door;

        public CollisionHandlerProjectileDoor(IProjectile p, ADoor d)
        {
            projectile = p;
            door = d;
        }

        public void HandleCollision()
        {
            if (projectile is ProjectilePlayerBomb && door is WeakWall)
            {
                
                BlowUpDoor(LevelManager.Instance.currentRoomNum,door.DoorSide);

                int linkedDoorRoom = door.connection;
                DoorFactory.Side linkedDoorDirection = DoorFactory.InvertSide(door.DoorSide);
                BlowUpDoor(linkedDoorRoom, linkedDoorDirection);
            }
            KillProjectile();
        }

        public void BlowUpDoor(int roomNum,DoorFactory.Side targetSide)
        {
            ADoor[] doorlist = LevelManager.Instance.RoomList[roomNum].DoorList;
            DoorFactory factory = DoorFactory.Instance;
            for (int x = 0; x < doorlist.Length; x++)
            {
                if (doorlist[x].DoorSide == targetSide) {
                    doorlist[x].IsRunning = false;
                    doorlist[x] = factory.CreateDoorSprite(factory.getDoor("Hole"), targetSide, doorlist[x].connection);
                    LevelManager.Instance.RoomList[roomNum].ColliderDetector.AddToList(doorlist[x] as IBoxCollider);
                }
            }
        }



        public void KillProjectile() {
            projectile.IsRunning = false;
        }


    }
}
