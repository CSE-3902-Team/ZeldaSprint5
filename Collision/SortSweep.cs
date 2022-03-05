using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;



namespace Sprint0.Collision
{
    public enum CollisionDirections {North,South,East,West,None}
    class SortSweep : ICollision 
    {
        private List<List<Object>> targets;
        private List<CollisionPoint> collisionPoints;
        public List<CollisionPoint> CollisionPoints { get { return collisionPoints; }  }
        public SortSweep() {
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
            ProcessCollisions();
            targets.Clear();
        }


        

        private void ProcessCollisions()
        {
            foreach (List<Object> ListItem in targets)
            {
                //TODO: resolve collisions between more than 2 objects
                if (ListItem.Count > 2)
                {
                    Console.Write("Warning collisions for 3 or more objects aren't defined");
                }
                else if (ListItem.Count > 1) {
                    if (ListItem[0].GetType() == typeof(Player))
                    {

                        List<Object> result = InspectCollision( ListItem[1] as IBoxCollider, ListItem[0] as IBoxCollider);
                        CollisionDirections col = (CollisionDirections)Enum.Parse(typeof(CollisionDirections), result[0].ToString());
                        CollisionHandlerPlayerBlock handler = new CollisionHandlerPlayerBlock(ListItem[0] as Player, ListItem[1] as ITile, col,(int)result[1]);
                        handler.HandleCollision();


                        Console.WriteLine("Player is Colliding from the "+ result[0] +" direction with a magnitude of "+result[1]);

                    }
                    else if(ListItem[1].GetType() == typeof(Player))
                    {
                        List<Object> result = InspectCollision(ListItem[0] as IBoxCollider, ListItem[1] as IBoxCollider);
                        CollisionDirections col = (CollisionDirections)Enum.Parse(typeof(CollisionDirections), result[0].ToString());
                        CollisionHandlerPlayerBlock handler = new CollisionHandlerPlayerBlock(ListItem[1] as Player, ListItem[0] as ITile, col, (int)result[1]);
                        handler.HandleCollision();
                        Console.WriteLine("Player is Colliding from the "+ result[0] + " direction with a magnitude of "+result[1]);
                    }
                }
            }
        }

        //Returns the magnitude and direction of a collision between two objects
        //The first item in the list is direction, the second item is magnitude
        private List<Object> InspectCollision(IBoxCollider origin, IBoxCollider agiator)
        {
            //check y's, we can assume that these objects are colliding on x-axis
            Console.WriteLine("agiator botR: " + agiator.BottomRight.X + " agiator TL: " +agiator.TopLeft.X+  " origin BR" + origin.BottomRight.X + " orgin TL: " + origin.TopLeft.X); ;

            int magY = 0;
            CollisionDirections yDir = CollisionDirections.None;
            if (agiator.BottomRight.Y > origin.TopLeft.Y && agiator.BottomRight.Y < origin.BottomRight.Y)
            {
                //North
                magY = agiator.BottomRight.Y - origin.TopLeft.Y;
                yDir = CollisionDirections.North;
            }
            else if (agiator.TopLeft.Y < origin.BottomRight.Y && agiator.TopLeft.Y > origin.TopLeft.Y)
            {
                //South
                magY = origin.BottomRight.Y - agiator.TopLeft.Y;
                yDir = CollisionDirections.South;
            }

            int magX = 0;
            CollisionDirections xDir = CollisionDirections.None;
            //Find out what direction + magnitude x is colliding on. There must be a collision on the y-axis
            if (agiator.BottomRight.X > origin.TopLeft.X && agiator.BottomRight.X < origin.BottomRight.X && yDir != CollisionDirections.None)
            {
                //West
                xDir = CollisionDirections.West;
                magX = agiator.BottomRight.X - origin.TopLeft.X;
            }
            else if (agiator.TopLeft.X < origin.BottomRight.X && agiator.TopLeft.X > origin.TopLeft.X && yDir != CollisionDirections.None)
            {
                //East
                xDir = CollisionDirections.East;
                magX = origin.BottomRight.X - agiator.TopLeft.X;
            }

            if (magY <= magX)
            {
                Console.WriteLine("D = " + yDir.ToString() + " magY = " + magY + " magX =" + magX);
                return new List<Object> { yDir, magY };
            }
            else
            {
                Console.WriteLine("D = " + xDir.ToString() + " magY = " + magY + " magX =" + magX);
                return new List<Object> { xDir, magX };
            }
        }

        public void AssignHandler(CollisionDirections dir, int magnitude)
        {
            return;
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
