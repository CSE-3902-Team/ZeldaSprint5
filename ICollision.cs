using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    interface ICollision 
    {
        void HandleCollisions(); 
        List<IBoxCollider> BoxColliders { get; set; }

    }
}
