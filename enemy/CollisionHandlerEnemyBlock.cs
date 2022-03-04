using Microsoft.Xna.Framework;
using System;

namespace Sprint0.enemy
{
    class CollisionHandlerEnemyBlock : ICollisionHandler
    {

        private Vector2 movement;
        Vector2 result;
        private Vector2 direction;
        public Vector2 currentPos;
        private Vector2 destination;
        int randomNum;
        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);

        public CollisionHandlerEnemyBlock(Vector2 Direction, Vector2 CurrentPos, Vector2 Destination)
        {
            this.result = Destination;
            this.movement = Direction;
            this.currentPos = CurrentPos;
        }
        public void HandleCollision()
        {

        }
        public Vector2 hitWall()
        {
            switch (movement.X)
            {

                case 0:
                    if (movement.Y == 0)
                        result.X = (int)currentPos.X - randomNum;
                    else
                        result.X = (int)currentPos.X + randomNum;
                    break;
                case 1:
                    if (movement.Y == 1)
                        result.Y = (int)currentPos.Y - randomNum;
                    else
                        result.Y = (int)currentPos.Y + randomNum;
                    break;
            }

            return result;
        }

    }
}

