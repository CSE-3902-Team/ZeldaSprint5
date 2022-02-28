using Microsoft.Xna.Framework;
using System;

namespace Sprint0
{
    interface IBoxCollider : IComparable<IBoxCollider>
    {
        Rectangle CollisionBox { get; set; } 

        
    }
}
