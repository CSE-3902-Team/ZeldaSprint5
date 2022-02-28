using System;
using System.Collections.Generic;
using System.Text;



namespace Sprint0.Collision
{
    class SortSweep : ICollision 
    {
        Game1 myGame;
        private List<IBoxCollider> boxColliders;
        private List<List<IBoxCollider>> collisions;
        SortSweep(Game1 g) {
            myGame = g;
            boxColliders = new List<IBoxCollider>();
            collisions = new List<List<IBoxCollider>>();
        }
        public void HandleCollisions()
        {
            LoadList();
            FindCollisionsX();
            SortY()
            AssignHandlers();
        }

        private void LoadList()
        {
            boxColliders.Add(myGame.TileList[1] as IBoxCollider);
            boxColliders.Add(myGame.Player); 
        }

        private int SortX(IBoxCollider obj1, IBoxCollider obj2)
        {
            //Sort all colliders along the x-axis
            return obj1.CollisionBox.X.CompareTo(obj2.CollisionBox.X);
        }

        private void FindCollisionsX()
        {
            List<IBoxCollider> Active = new List<IBoxCollider>(); 
            //Ok so when you enter a new beginning you add it to the list
            //Once you find a beginning value that is greater than the old
            //one you can flush the list and add it to the list of collisions
            //that need to be handled. nested lists? if length is 1 no collisions
            foreach(IBoxCollider colObj : boxColliders)
            {
                 
            }
        }

        private int SortY(IBoxCollider obj1, IBoxCollider obj2)
        {
            //Sort all colliders along the y-axis
            return obj1.CollisionBox.Y.CompareTo(obj2.CollisionBox.Y);
        }

        private void AssignHandlers()
        {
            return; 
        }

    }
}
