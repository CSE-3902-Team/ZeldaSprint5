using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.enemy
{

    class MoveEnemy
    {
        private Vector2 movement;
        private Vector2 Pos;
        int destinationX;
        int destinationY;
        public MoveEnemy(Vector2 direction, Vector2 currentPos,Vector2 destination)

        {
            this.destinationX = (int)destination.X;
            this.destinationY = (int)destination.Y;
            this.movement = direction;
            this.Pos = currentPos;
        }
        public Vector2 Move()
        {
            switch (movement.X)
            {

                case 0:
                    if (Pos.Y < destinationY)

                        Pos.Y++;
                    else if (Pos.Y > destinationY)
                       Pos.Y--;

                    break;
                case 1:
                    if (Pos.X < destinationX)
                        Pos.X++;
                    else if (Pos.X > destinationX)
                      Pos.X--;
                    break;
            }
            return Pos;
        }
        public Vector2 GoriyaMove()
        {
            return Pos;
        }
        public Vector2 DragonMove()
        {
            Vector2 result;
            if (Pos.X < destinationX)
            {
                destinationX = 600;
               Pos.X++;
            }
            if (Pos.X >= destinationX)
            {
                destinationX = 400;
               Pos.X--;
            }
            result.X = destinationX;
            result.Y = Pos.X;
            return result;
        }
    }
}
