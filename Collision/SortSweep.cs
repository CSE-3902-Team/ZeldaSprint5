using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.ItemClass;



namespace Sprint0.Collision
{
    public enum CollisionDirections {North,South,East,West,None}
    class SortSweep : ICollision
    {
        private List<List<Object>> targets;
        private List<CollisionPoint> collisionPoints;
        public List<CollisionPoint> CollisionPoints { get { return collisionPoints; } }
        public SortSweep() {
            targets = new List<List<Object>>();
            collisionPoints = new List<CollisionPoint>();
        }
        public void HandleCollisions()
        {
            PruneProjectilesAndItems();
            FindCollisionsX();
            ProcessCollisions();
            targets.Clear();
        }




        private void FindCollisionsX()
        {
            List<Object> active = new List<Object>();

            collisionPoints.Sort(delegate (CollisionPoint a, CollisionPoint b)
            {
                return a.X.CompareTo(b.X);
            });

            PrintList();

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


            //PrintCollisions();

        }




        private void ProcessCollisions()
        {
            //Go through list of objects intersecting on x-axis
            for (int listInd = 0; listInd < targets.Count; listInd++)
            {
                SortSublistByType(targets[listInd]);


                for (int x = 1; x < targets[listInd].Count; x++) {
                    //Console.WriteLine();
                    //foreach (object obj in targets[listInd])
                   // {
                    //    Console.Write(" " + obj.GetType());
                    //}

                    if (targets[listInd][0].GetType() == typeof(Player)){ 
                        List<Object> result = InspectCollision(targets[listInd][0] as IBoxCollider, targets[listInd][x] as IBoxCollider);
                        CollisionDirections direction = (CollisionDirections)Enum.Parse(typeof(CollisionDirections), result[0].ToString());
                        if (direction != CollisionDirections.None)
                        {
                            AssignPlayerHandler(targets[listInd][0] as Player, targets[listInd][x], direction, (int)result[1]);
                        }
                        
                    }


                }

               
            
                
            }
        }
        //Returns the magnitude and direction of a collision between two objects
        //The first item in the list is direction, the second item is magnitude
        private List<Object> InspectCollision(IBoxCollider agiator, IBoxCollider origin)
        {
            //Console.WriteLine("agiator botR: " + agiator.BottomRight.X + " agiator TL: " + agiator.TopLeft.X + " origin BR" + origin.BottomRight.X + " orgin TL: " + origin.TopLeft.X); ;

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
                //Console.WriteLine("D = " + yDir.ToString() + " magY = " + magY + " magX =" + magX);
                return new List<Object> { yDir, magY };
            }
            else
            {
                //Console.WriteLine("D = " + xDir.ToString() + " magY = " + magY + " magX =" + magX);
                return new List<Object> { xDir, magX };
            }
        }

        private void AssignPlayerHandler(Player player, Object other, CollisionDirections dir, int magnitude)
        {
            ICollisionHandler handler;
            if (other is ITile)
            {
                handler = new CollisionHandlerPlayerBlock(player, other as ITile, dir, magnitude);
            }
            else if (other is IEnemySprite)
            {
                handler = new CollisionHandlerPlayerEnemy(player, other as IEnemySprite, dir);
            }
            else if (other is AItem)
            {
                handler = new CollisionHandlerPlayerItem(other as AItem);
            }
            else 
            {
                handler = new CollisionHandlerUnknown(other);
            }
            handler.HandleCollision();
            return;
        }

        private void AsssignEnemyHandler(IEnemySprite enemy, Object other, CollisionDirections dir, int magnitude)
        {
            return;
        }

        private void AssignProjectileHandler(IEnemySprite enemy, Object other, CollisionDirections dir, int magnitude)
        {
            return;
        }

        public void AddToList(IBoxCollider box)
        {
            collisionPoints.Add(box.TopLeft);
            collisionPoints.Add(box.BottomRight);
        }

        private void PruneProjectilesAndItems()
        {
            for (int x = 0; x < collisionPoints.Count; x++)
            {
                if (collisionPoints[x].Parent is AItem)
                {
                    if ((collisionPoints[x].Parent as AItem).IsPickedUp)
                    {
                        collisionPoints.RemoveAt(x);
                        x--;
                    }
                }
                else if (collisionPoints[x].Parent is IProjectile)
                {
                    if (!(collisionPoints[x].Parent as IProjectile).IsRunning)
                    {
                        collisionPoints.RemoveAt(x);
                        x--;
                    }
                }
            }
        }

        private void SortSublistByType(List<Object> sublist)
        {
            sublist.Sort(delegate (Object a, Object b)
            {
                if (a.GetType() == typeof(Player))
                {
                    return -2;
                }
                else if (a.GetType() == typeof(IEnemySprite))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
        }

        private void PrintList()
        {
            for (int x = 0; x < collisionPoints.Count; x++)
            {
                Console.Write(collisionPoints[x].Parent.GetType() + ": " + collisionPoints[x].X + " |");
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        private void PrintCollisions()
        {
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
