using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;



namespace Sprint0.Collision
{
    public enum PointT {Start,End }
    class SortSweep : ICollision 
    {
        Game1 myGame;
        private List<BEPoint> boxColliders;
        private List<List<IBoxCollider>> collisions;
        public List<IBoxCollider> BoxColliders { get { return boxColliders; } set { boxColliders = value; } }
        public SortSweep(Game1 g) {
            myGame = g;
            boxColliders = new List<BEPoint>();
            collisions = new List<List<IBoxCollider>>();
        }
        public void HandleCollisions()
        {
            FindCollisionsX();
            //SortY()
            //AssignHandlers();
        }

        


        private void FindCollisionsX()
        {
            List<IBoxCollider> Active = new List<IBoxCollider>(); 

            //sorts objects by their x cordinates in ascending order
            boxColliders.Sort(delegate (BEPoint x, BEPoint y)
            {
                return x.Cordinate.X.CompareTo(y.Cordinate.X);
            });

            List<BEPoint> active = new List<BEPoint>();
            IBoxCollider currentBox;
            Boolean insideInterval = false;

            for (int x = 0; x < boxColliders.Count - 1; x++)
                if (!insideInterval && boxColliders[x].PointType == PointT.Start)
                {
                    currentBox = boxColliders[0].Box;
                    insideInterval = true;
                }
                else if(insideInterval &&  { }
            }
        }

        private int SortY(IBoxCollider obj1, IBoxCollider obj2)
        {
            //Sort all colliders along the y-axis
            return obj1.CollisionBox.Y.CompareTo(obj2.CollisionBox.Y);
        }

        private void FindCollisionsY()
        { 
            /*See if the collision is inside the x collision list
            //if it is inside the list add y to the final list probably
            want to the clear the x list afterwards.This is really goofy
            with nested lists though
            */
        
        }

        private void AssignHandlers()
        {
            return; 
        }

        public void AddToList(IBoxCollider box) 
        {
            //Beginning point
            boxColliders.Add(new BEPoint(box,
                new Point(box.CollisionBox.X, box.CollisionBox.Y),
                PointT.Start
             ));
            //Ending point
             boxColliders.Add(new BEPoint(box,
                new Point(box.CollisionBox.X + box.CollisionBox.Width,box.CollisionBox.Y+box.CollisionBox.Height),
                PointT.Start
             ));


        }

        private void PrintList() {
            Console.WriteLine();
            for(int x = 0; x < boxColliders.Count; x++) 
            {
                Console.Write(" " + boxColliders[x].GetType() + " " + boxColliders[x].CollisionBox.X); ;
            }
            Console.WriteLine();
        }

        private void PrintCollisions() {
            Console.WriteLine();
            for(int x = 0; x < collisions.Count; x++) 
            {
                Console.Write(collisions[x].ToString()+" ");
            }
        }

    }
}
