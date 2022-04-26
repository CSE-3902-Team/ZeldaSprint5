using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collision
{
    class CollisionHandlerUnknown : ICollisionHandler
    {
        object other;
        public CollisionHandlerUnknown(object o)
        {
            other = o;
        }
        public void HandleCollision()
        {
        }
    }
}
