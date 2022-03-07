using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public interface ICollision 
    {
        public void HandleCollisions();
        public void AddToList(IBoxCollider box);


    }
}
