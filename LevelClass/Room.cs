using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.TileClass;
using Sprint0.ItemClass;
using Sprint0.Collision;
using Sprint0.PlayerClass;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Sprint0.enemy;
using Sprint0.DoorClass;
using System;

namespace Sprint0.LevelClass
{
    public class Room
    {


        private ADoor[] doorList;
        private ICollision colliderDetector;
    
        private readonly List<IEnemySprite> enemyList;
        private AItem[] itemList;
        private ITile[] tileList;
        private AItem[] combineList;
        private readonly List<IProjectile> projectileList;
        private Player _player;
        private int enemyKillCount;
        private Dictionary<IEnemySprite, AItem> enemyHoldItem;
        public List<IProjectile> ProjectileList
        {
            get { return projectileList; }
        }

        public ICollision ColliderDetector
        {
            get { return colliderDetector; }
        }

        public Player Player
        {
            get { return _player; }
        }

        public ADoor[] DoorList
        {
            get { return doorList; }
        }
        public Room(ADoor[] doorList, List<IEnemySprite> enemyList, AItem[] itemList, ITile[] tileList, Player player,Dictionary<IEnemySprite, AItem> enemyHoldItem) {
            this.doorList = doorList;
            this.enemyList = enemyList;
            this.itemList = itemList;
            this.tileList = tileList;
            this.enemyHoldItem = enemyHoldItem;
            projectileList = new List<IProjectile>();
            _player = player;
            colliderDetector = new SortSweep();
            SortTilesByDrawOrder();

            for (int x = 0; x < doorList.Length; x++) { 
                colliderDetector.AddToList(doorList[x] as IBoxCollider);
            }
           
            for (int x = 0; x < enemyList.Count; x++) {
                colliderDetector.AddToList(enemyList[x] as IBoxCollider);
            }

            foreach (AItem currentItem in itemList)
            {
                colliderDetector.AddToList(currentItem as IBoxCollider);
            }
    
            foreach (AItem currentItem in enemyHoldItem.Values)
            {
                colliderDetector.AddToList(currentItem as IBoxCollider);
            }
            foreach (IEnemySprite currentEnemy in enemyHoldItem.Keys)
            {
                colliderDetector.AddToList(currentEnemy as IBoxCollider);
            }
          

            foreach (ITile currentTile in tileList) {
                if (!currentTile.Walkable) {
                    //Console.Write(currentTile.GetType());
                    colliderDetector.AddToList(currentTile as IBoxCollider);
                }
            }

            colliderDetector.AddToList(_player);
        }


        public void drawRoom() {
            drawRoom(0, 0, false);
        }

        public void drawRoom(int xOffset, int yOffset, bool transition) {
            for (int x = 0; x < tileList.Length; x++)
            {
                tileList[x].draw(xOffset, yOffset);
            }
            foreach (ADoor currentDoor in doorList)
            {
                currentDoor.draw(xOffset, yOffset);
            }
            foreach (AItem currentItem in itemList)
            {
                currentItem.draw(xOffset, yOffset);
            }

            foreach (IEnemySprite currentEnemy in enemyList) {
                currentEnemy.draw(xOffset, yOffset);
            }

            foreach (IProjectile currentProjectile in projectileList)
            {
                currentProjectile.Draw(xOffset, yOffset);
            }
            for (int x = 0; x < enemyHoldItem.Count; x++)
            {
                enemyHoldItem.ElementAt(x).Key.draw(xOffset, yOffset);
                if (!enemyHoldItem.ElementAt(x).Key.IsAlive)
                {
                    enemyHoldItem.ElementAt(x).Value.myPos.X = enemyHoldItem.ElementAt(x).Key.position.X;
                    enemyHoldItem.ElementAt(x).Value.myPos.Y = enemyHoldItem.ElementAt(x).Key.position.Y;
                    enemyHoldItem.ElementAt(x).Value.TopLeft.X= (int)enemyHoldItem.ElementAt(x).Key.position.X;
                    enemyHoldItem.ElementAt(x).Value.TopLeft.Y = (int)enemyHoldItem.ElementAt(x).Key.position.Y;
                    enemyHoldItem.ElementAt(x).Value.BottomRight.X = (int)enemyHoldItem.ElementAt(x).Key.position.X+64;
                    enemyHoldItem.ElementAt(x).Value.BottomRight.Y = (int)enemyHoldItem.ElementAt(x).Key.position.Y + 64;
                    enemyHoldItem.ElementAt(x).Value.draw(xOffset, yOffset);
                }
                else
                {
                    enemyHoldItem.ElementAt(x).Value.TopLeft.X =0;
                    enemyHoldItem.ElementAt(x).Value.TopLeft.Y =0;
                    enemyHoldItem.ElementAt(x).Value.BottomRight.X = 0;
                    enemyHoldItem.ElementAt(x).Value.BottomRight.X = 0;
                }
            }
            if (!transition)
            {
                Player.Draw();
            }
        }

        public void updateRoom() {
            UpdateEnemies();
            UpdateProjectiles();
            UpdateEnemiesHoldItem();
            Player.Update();
            colliderDetector.HandleCollisions();
            if (enemyList.Count == 0&&(enemyKillCount>=enemyHoldItem.Count))
            {
                UnlockDoors();
            }
            CheckPressurePlate();


        }

        public void UpdateProjectiles()
        {
            for (int x = 0; x < projectileList.Count; x++)
            {
                if (!projectileList[x].IsRunning)
                {
                    projectileList.RemoveAt(x);
                    x--;
                }
                else
                {
                    projectileList[x].Update();
                }
            }
        }

        public void UpdateEnemies()
        {
            for (int x = 0; x < enemyList.Count; x++)
            {
                if (!enemyList[x].IsAlive)
                {
                    enemyList.RemoveAt(x);
                    x--;
                }
                else
                {
                    enemyList[x].Update();
                }
            }
        }
        public void UpdateEnemiesHoldItem()
        {
            for (int x = 0; x < enemyHoldItem.Count; x++)
            {
                if (!enemyHoldItem.ElementAt(x).Key.IsAlive)
                {
                    enemyKillCount++;
                }
                else
                {
                    enemyHoldItem.ElementAt(x).Key.Update();
                }
            }
        }

        private void SortTilesByDrawOrder()
        {
            Array.Sort(tileList, delegate (ITile a, ITile b)
            {
                if (a.GetType() == typeof(PushableTile) || a.GetType() == typeof(RightFire) || a.GetType() == typeof(LeftFire))
                {
                    return 1;
                }
                else if (b.GetType() == typeof(PushableTile)|| b.GetType() == typeof(RightFire) || b.GetType() == typeof(LeftFire))
                {
                    return -1;
                }
                else {
                    return ((int)a.Position.X + (int)a.Position.Y * -1).CompareTo((int)a.Position.X + (int)a.Position.Y * -1);
                }
                
            });
        }

        public void UnlockDoors()
        {
            DoorFactory factory = DoorFactory.Instance;
            for (int x = 0; x < doorList.Length; x++)
            {
                if (doorList[x] is DoorClosed) {
                    doorList[x].IsRunning = false;
                    doorList[x] = DoorFactory.Instance.CreateDoorSprite(DoorFactory.Door.Open, doorList[x].DoorSide, doorList[x].connection);
                    colliderDetector.AddToList(doorList[x] as IBoxCollider);
                }
            }
        }

        private void CheckPressurePlate()
        {
            Vector2 platePos = Vector2.Zero;
            Vector2 pushablePos = Vector2.Zero;
            for (int x = 0; x < tileList.Length; x++)
            {
                if (tileList[x] is PressurePlate)
                {
                    platePos = tileList[x].Position;
                }
                if (tileList[x] is PushableTile)
                {
                    pushablePos = tileList[x].Position;
                }
            }
            if (platePos.Equals(Vector2.Zero) || pushablePos.Equals(Vector2.Zero)) return;

            if ((int)platePos.X == (int)pushablePos.X && (int)platePos.Y == (int)pushablePos.Y)
            {
                Console.WriteLine("pressure plate triggered");
                UnlockDoors();
            }
        }

    }
}
