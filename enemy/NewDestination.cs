using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.enemy
{

    class NewDestination
    {
        private Vector2 movement;
        private Vector2 Pos;
        Vector2 result;
        int randomNum;
        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);
        public NewDestination(Vector2 direction, Vector2 currentPos, Vector2 destination)

        {
            this.result = destination;
            this.movement = direction;
            this.Pos = currentPos;
        }
        public Vector2 RollingDice()
        {
            if (Pos.X == result.X || Pos.Y == result.Y)
            {
       
                switch (movement.X)
                {

                    case 0:
                        if (movement.Y == 0)
                           result.X = (int)Pos.X + randomNum;
                        else
                            result.X = (int)Pos.X - randomNum;
                        break;
                    case 1:
                        if (movement.Y == 1)
                            result.Y = (int)Pos.Y + randomNum;
                        else
                            result.Y = (int)Pos.Y - randomNum;
                        break;
                }

           


            }
            return result;
        }
        public Vector2 RollingDice1()
        {
            if (Pos.X == result.X || Pos.Y == result.Y)
            {
                randomNum = getDistance.Next(50, 100);
                movement.X = coinFlipForAxis.Next(0, 2);
                movement.Y = coinFlipForDirection.Next(0, 2);



            }
            return movement;
        }
    }
}
