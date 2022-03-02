using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;



namespace Sprint0.Collision
{
    public enum CollisionDirections {North,South,East,West,None}
    class SortSweep : ICollision 
    {
        Game1 myGame;
        private List<List<Object>> targets;
        private List<CollisionPoint> collisionPoints;
        public List<CollisionPoint> CollisionPoints { get { return collisionPoints; }  }
        public SortSweep(Game1 g) {
            myGame = g;
            targets = new List<List<Object>>();
            collisionPoints = new List<CollisionPoint>();
        }
        public void HandleCollisions()
        {
            FindCollisionsX();
            //SortY()
            //AssignHandlers();
        }

        


        private void FindCollisionsX()
        {
            List<Object> active = new List<Object>();

            //TODO: check if this is insertion sort
            //sorts objects by their x cordinates in ascending order
            collisionPoints.Sort(delegate (CollisionPoint a, CollisionPoint b)
            {
                return a.X.CompareTo(b.X);
            });

            //PrintList();

            for (int x = 0; x < collisionPoints.Count; x++)
            {
                if (Type.Equals(collisionPoints[x].GetType(), typeof(TopLeft)))
                {
                    active.Add(collisionPoints[x].Parent);
                }
                else if (Type.Equals(collisionPoints[x].GetType(), typeof(BottomRight)))
                {
                    List<Object> sublist = new List<Object>(active);
                    targets.Add(sublist);
                    active.Remove(collisionPoints[x].Parent); 
                }
            }


            Console.WriteLine();
            //PrintList();
            //PrintCollisions();
            AssignHandlers();
            targets.Clear();
        }


        private CollisionDirections GetCollisionDirection(IBoxCollider origin, IBoxCollider agiator )
        {
            int magX = 0;
            CollisionDirections xDir = CollisionDirections.None;
            //check x's, we can assume that agiator is colliding on some xDirection
            if (agiator.BottomRight.X > origin.TopLeft.X)
            {
                xDir = CollisionDirections.West;
                magX = agiator.BottomRight.X - origin.BottomRight.X;
            }
            else if(agiator.TopLeft.X < origin.BottomRight.X){
                xDir = CollisionDirections.East;
                magX = origin.BottomRight.X - agiator.TopLeft.X;
            }

            //check y's
            int magY = 0;
            CollisionDirections yDir = CollisionDirections.None;
            if (agiator.BottomRight.Y > origin.TopLeft.Y)
            {
                //Up
                magY = agiator.BottomRight.Y - origin.TopLeft.Y;
                yDir = CollisionDirections.North;
            }
            else if (origin.BottomRight.Y > agiator.TopLeft.Y)
            {
                //Down
                magY = origin.BottomRight.Y - agiator.TopLeft.Y;
                yDir = CollisionDirections.South;
            }

            if (magY > magX)
            {
                return yDir;
            }
            else 
            {
                return xDir; 
            }
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
            foreach (List<Object> ListItem in targets)
            {
                //Let's just assume that every collusion is just two objects
                if (ListItem.Count > 2)
                {
                    throw new ArgumentException("n-way collusions are unspecified");
                }
                else if (ListItem.Count > 1) {
                    if (ListItem[0].GetType() == typeof(Player))
                    {
                        CollisionDirections dir = GetCollisionDirection(ListItem[0] as IBoxCollider, ListItem[1] as IBoxCollider);
                        Console.WriteLine("Player is Colliding from the "+ dir.ToString() +" direction");

                    }
                    else if(ListItem[1].GetType() == typeof(Player))
                    {
                        CollisionDirections dir = GetCollisionDirection(ListItem[1] as IBoxCollider, ListItem[0] as IBoxCollider);
                        Console.WriteLine("Player is Colliding from the ", dir.ToString(), " direction");
                    }
                }
            }
        }

        public void AddToList(IBoxCollider box) 
        {
            collisionPoints.Add(box.TopLeft);
            collisionPoints.Add(box.BottomRight);
        }

        private void PrintList() {
            for (int x = 0; x < collisionPoints.Count; x++)
            {
                Console.Write(collisionPoints[x].Parent.GetType()+ ": "+collisionPoints[x].X+" |");
            }
            Console.WriteLine();
        }

        private void PrintCollisions() {
            foreach (List<Object> ListItem in targets)
            {
                Console.Write("[");
                for (int x = 0; x < ListItem.Count; x++)
                {
                    Console.Write(ListItem[x].GetType() + " ");
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }

    }
}
