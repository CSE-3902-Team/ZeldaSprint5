using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collision
{
    class CollisionHandlerEnemyProjectile : ICollisionHandler
    {
        private IEnemySprite enemy;
        private IProjectile projectile;
        private int overlap;
        private CollisionDirections collisionDirections;
        private int deathcount;
        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);


        public CollisionHandlerEnemyProjectile(IEnemySprite enemy, IProjectile projectile, CollisionDirections collisionDirections, int overlap,int repeat)
        {
            this.enemy = enemy;
            this.projectile = projectile;
            this.overlap = overlap;
            this.collisionDirections = collisionDirections;

        }
        public void HandleCollision()
        {
            if (this.projectile is Sprint0.enemy.ManhandlaFire || this.projectile is Sprint0.enemy.ManhandlaFire1 || this.projectile is Sprint0.enemy.ManhandlaFire2 || this.projectile is Sprint0.enemy.DragonFireBall || this.projectile is Sprint0.enemy.DragonFireBall1 || this.projectile is Sprint0.enemy.DragonFireBall2 || this.projectile is Sprint0.enemy.EnemyProjectile)
            {
                return;
            }
            else
            {
                if (overlap % 2 == 0)
                {
                    enemy.deathCount++;

                    if (this.enemy is Sprint0.enemy.bossManhandla)
                    {

                        switch (collisionDirections)
                        {
                            case CollisionDirections.North:
                                enemy.Destination = new Vector2(0, 0);

                                break;
                            case CollisionDirections.East:
                                enemy.Destination = new Vector2(1, 0);

                                break;
                            case CollisionDirections.South:
                                enemy.Destination = new Vector2(0, 1);
                                break;
                            case CollisionDirections.West:
                                enemy.Destination = new Vector2(1, 1);
                                break;
                            default:
                                break;
                        }
                    }



                    projectile.IsRunning = false;
                }
                overlap++;

            }


        }


        
    }
}

