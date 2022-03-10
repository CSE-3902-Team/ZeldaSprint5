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


            //PrintCollisions();

        }




        private void ProcessCollisions()
        {
            //Go through list of objects intersecting on x-axis
            for (int listInd = 0; listInd < targets.Count; listInd++)
            {
                SortSublistByType(targets[listInd]);

                for (int handlerTarget = 0; handlerTarget < targets[listInd].Count; handlerTarget++)
                {
                    for (int x = 0; x < targets[listInd].Count; x++)
                    {
                        if (targets[listInd][handlerTarget].GetType() == typeof(Player))
                        {
                            List<Object> result = InspectCollision(targets[listInd][handlerTarget] as IBoxCollider, targets[listInd][x] as IBoxCollider);
                            CollisionDirections direction = (CollisionDirections)Enum.Parse(typeof(CollisionDirections), result[0].ToString());
                            if (direction != CollisionDirections.None)
                            {
                                AssignPlayerHandler(targets[listInd][handlerTarget] as Player, targets[listInd][x], direction, (int)result[1]);
                            }

                        }
                        if (targets[listInd][handlerTarget] is IEnemySprite)
                        {
                            List<Object> result = InspectCollision(targets[listInd][handlerTarget] as IBoxCollider, targets[listInd][x] as IBoxCollider);
                            CollisionDirections direction = (CollisionDirections)Enum.Parse(typeof(CollisionDirections), result[0].ToString());
                            if (direction != CollisionDirections.None)
                            {
                                AssignEnemyHandler(targets[listInd][handlerTarget] as IEnemySprite, targets[listInd][x], direction, (int)result[1]);
                            }

                        }

                        if (targets[listInd][handlerTarget] is IProjectile)
                        {
                            List<Object> result = InspectCollision(targets[listInd][handlerTarget] as IBoxCollider, targets[listInd][x] as IBoxCollider);
                            CollisionDirections direction = (CollisionDirections)Enum.Parse(typeof(CollisionDirections), result[0].ToString());
                            if (direction != CollisionDirections.None)
                            {
                                AssignProjectileHandler(targets[listInd][handlerTarget] as IProjectile, targets[listInd][x], direction, (int)result[1]);
                            }

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
            else if (other is IProjectile) 
            {
                handler = new CollisionHandlerPlayerProjectile(player, other as IProjectile, dir);
            }
            else
            {
                handler = new CollisionHandlerUnknown(other);
            }
            handler.HandleCollision();
            return;
        }

        private void AssignEnemyHandler(IEnemySprite enemy, Object other, CollisionDirections dir, int magnitude)
        {
            ICollisionHandler handler;
            if (other is ITile)
            {
                handler = new CollisionHandlerEnemyBlock(enemy, other as ITile, dir, magnitude);
                handler.HandleCollision();
            }
            else if (other is IProjectile) { 

                handler = new CollisionHandlerEnemyProjectile(enemy, other as ITile, dir, magnitude);

                handler.HandleCollision();


            }
            else
            {
                handler = new CollisionHandlerUnknown(other);
                handler.HandleCollision();
            }
       
            return;
        }

        private void AssignProjectileHandler(IProjectile projectile, Object other, CollisionDirections dir, int magnitude)
        {
            if (other is IProjectile)
            {
                return;
            }
            else if (other is AItem)
            {
                return;
            }
            else if (other is Player)
            {
       
                return;
            }
            else if (other is IEnemySprite)
            {
                ICollisionHandler handler = new CollisionHandlerProjectileTile(projectile);
                handler.HandleCollision();
                //The logic when a player projectile hit an enemy is same as hit a tile
            }
            else if (other is ITile)
            {
                ICollisionHandler handler = new CollisionHandlerProjectileTile(projectile);
                handler.HandleCollision();
            }
            else
            {
                ICollisionHandler handler = new CollisionHandlerUnknown(other);
                handler.HandleCollision();
            }
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
                else if (a.GetType() == typeof(IProjectile))
                {
                    return 0;
                }
                else
                {
                    //items and tiles
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
