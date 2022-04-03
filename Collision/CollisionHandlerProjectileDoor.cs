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
            if (projectile is ProjectilePlayerBomb && door is DoorLocked)
            {
                BlowUpDoor();
            }
            KillProjectile();
        }

        public void BlowUpDoor()
        {
            DoorFactory.Side targetSide = door.DoorSide;
            ADoor[] doorlist = LevelManager.Instance.CurrentRoom.DoorList;
            DoorFactory factory = DoorFactory.Instance;
            for (int x = 0; x < doorlist.Length; x++)
            {
                if (doorlist[x].DoorSide == targetSide) {
                    doorlist[x].IsRunning = false;
                    doorlist[x] = factory.CreateDoorSprite(factory.getDoor("Hole"), targetSide);
                }
            }
        }
        public void KillProjectile() {
            projectile.IsRunning = false;
        }


    }
}
