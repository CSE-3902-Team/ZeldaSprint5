using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collision
{
    class CollisionHandlerEnemyBlock:ICollisionHandler
    {


        private IEnemySprite enemy;
        private ITile block;
        private int overlap;
        private CollisionDirections collisionDirections;
        public Vector2 Pos
        {
            get { return Pos; }
            set { }
        }
        public CollisionHandlerEnemyBlock(IEnemySprite enemy, ITile block, CollisionDirections collisionDirections, int overlap)
        {
            this.enemy = enemy;
            this.block = block;
            this.overlap = overlap;
            this.collisionDirections = collisionDirections;
        }
        public void HandleCollision()
        {

            float xDirection;
            float yDirection;
            if(enemy is Sprint0.enemy.enemyBat)
            {
                return;
            }
            switch (collisionDirections)
            {
                case CollisionDirections.North:
                    yDirection = -1;
                    xDirection = 0;
                    break;
                case CollisionDirections.East:
                    yDirection = 0;
                    xDirection = 1;
                    break;
                case CollisionDirections.South:
                    yDirection = 1;
                    xDirection = 0;
                    break;
                case CollisionDirections.West:
                    yDirection = 0;
                    xDirection = -1;
                    break;
                default:
                    yDirection = 0;
                    xDirection = 0;
                    break;
            }

            //Console.WriteLine("a"+ yDirection);
            enemy.Destination = new Vector2(enemy.position.X +8*(xDirection * (float)overlap), enemy.position.Y + 8*(yDirection * (float)overlap));

        }
    
    }
    }

