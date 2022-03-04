using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    interface ICollision 
    {
        void HandleCollisions();
        void AddToList(IBoxCollider box);


    }
}
