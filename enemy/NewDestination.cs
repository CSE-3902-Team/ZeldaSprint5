using Microsoft.Xna.Framework;
using System;

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
                        {
                            result.X = (int)Pos.X + randomNum;
                            if (result.X >= 800)
                                result.X = 750;
                        }
                        else
                        {
                            result.X = (int)Pos.X - randomNum;
                            if (result.X <= 128)
                                result.X = 150;
                        }
                        break;
                    case 1:
                        if (movement.Y == 1)
                        {
                            result.Y = (int)Pos.Y + randomNum;
                            if (result.Y >= 800)
                                result.Y = 750;
                        }
                        else
                        {
                            result.Y = (int)Pos.Y - randomNum;
                            if (result.Y <= 400)
                                result.Y = 350;
                        }
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
    
        public Vector2 trap1(Player player)
        {
             if (player.Position.X < 250|| player.Position.X>750)
            {
                movement.X = 0;

            }
           else if ((player.Position.Y <= 456 ||player.Position.Y>733)&& player.Position.X>250 &&player.Position.X < 750)
            {
                movement.X = 1;

            }
           if (player.Position.X<250|| player.Position.Y < 450)
            {
                movement.Y = 0;

            }
           else if (player.Position.X > 750 ||player.Position.Y > 733)
            {
                movement.Y = 1;

            }


            return movement;
        }
      
    }
}
