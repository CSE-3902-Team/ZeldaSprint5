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
        private readonly List<IProjectile> projectileList;
        private Player _player;

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
        public Room(ADoor[] doorList, List<IEnemySprite> enemyList, AItem[] itemList, ITile[] tileList, Player player) {
            this.doorList = doorList;
            this.enemyList = enemyList;
            this.itemList = itemList;
            this.tileList = tileList;
            projectileList = new List<IProjectile>();
            _player = player;
            colliderDetector = new SortSweep();

           

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


            foreach (ITile currentTile in tileList) {
                if (!currentTile.Walkable) {
                    //Console.Write(currentTile.GetType());
                    colliderDetector.AddToList(currentTile as IBoxCollider);
                }
            }

            colliderDetector.AddToList(_player);
        }


        public void drawRoom() {
            foreach (ITile currentTile in tileList)
            {
                currentTile.draw();
            }
            foreach (ADoor currentDoor in doorList)
            {
                currentDoor.draw();
            }
            foreach (AItem currentItem in itemList)
            {
                currentItem.draw();
            }

            foreach (IEnemySprite currentEnemy in enemyList) {
                currentEnemy.draw();
            }

            foreach (IProjectile currentProjectile in projectileList)
            {
                currentProjectile.Draw();
            }


            Player.Draw();
        }

        public void updateRoom() {
            UpdateEnemies();
            UpdateProjectiles();
            Player.Update();
            colliderDetector.HandleCollisions();
            if (enemyList.Count == 0)
            {
                UnlockDoors();
            }
            Console.Write("[");
            for(int x = 0; x < enemyList.Count; x++)
            {
                Console.Write(enemyList[x]);
            }
            Console.Write("]");
            Console.WriteLine();
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

        public void UnlockDoors()
        {
            DoorFactory factory = DoorFactory.Instance;
            for (int x = 0; x < doorList.Length; x++)
            {
                if (doorList[x] is DoorLocked) {
                    doorList[x].IsRunning = false;
                    doorList[x] = DoorFactory.Instance.CreateDoorSprite(DoorFactory.Door.Open, doorList[x].DoorSide, doorList[x].connection);
                }
            }
        }

    }
}
