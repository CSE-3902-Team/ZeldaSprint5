using Microsoft.Xna.Framework;
using System;
using Sprint0.ItemClass;

namespace Sprint0.Collision
{
    public class CollisionHandlerPlayerItem : ICollisionHandler
    {
        private AItem item;


        public CollisionHandlerPlayerItem(AItem item)
        {
            this.item = item;

        }
        public void HandleCollision()
        {
            //Remove from item list
            //Remove from collision list
            item.IsPickedUp = true;
        }
    }
}
