using Microsoft.Xna.Framework;

namespace Sprint0.enemy
{

    class MoveEnemy
    {
        private Vector2 movement;
        private Vector2 Pos;
        int destinationX;
        int destinationY;
        public MoveEnemy(Vector2 direction, Vector2 currentPos, Vector2 destination)

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
        public Vector2 trapMove(int frame, Vector2 location)
        {

        
         if (movement.X == 1)
            {
                if (location.Y < 500 && location.X>400)
                {
                    if (frame <= 50)
                    {
                        Pos.Y += 3;
                    }
                    if (frame > 50 && frame <= 100)
                    {
                        Pos.Y -= 3;
                    }
                }
                if (location.Y > 500 && location.X > 400)
                {
                    if (frame <= 50)
                    {
                        Pos.Y -= 3;
                    }
                    if (frame > 50 && frame <= 100)
                    {
                        Pos.Y += 3;
                    }
                }
            }
            else if (movement.X == 0)
            {
                if (location.Y < 500 && location.X < 200)
                {
                    if (frame <= 50)
                    {
                        Pos.Y += 3;
                    }
                    if (frame > 50 && frame <= 100)
                    {
                        Pos.Y -= 3;
                    }
                }
                if (location.Y > 500 && location.X < 200)
                {
                    if (frame <= 50)
                    {
                        Pos.Y -= 3;
                    }
                    if (frame > 50 && frame <= 100)
                    {
                        Pos.Y += 3;
                    }
                }
            }
         /*
            else  if (movement.Y == 0)
            {
                if (location.Y < 500 && location.X < 200)
                {
                    if (frame <= 50)
                    {
                        Pos.X += 6;
                    }
                    if (frame > 50 && frame <= 100)
                    {
                        Pos.X -= 6;
                    }
                }
                if (location.Y < 500 && location.X > 200)
                {
                    if (frame <= 50)
                    {
                        Pos.X -= 6;
                    }
                    if (frame > 50 && frame <= 100)
                    {
                        Pos.X += 6;
                    }
                }
            }

            else if (movement.Y == 1)
            {
                if (location.Y > 500 && location.X < 200)
                {
                    if (frame <= 50)
                    {
                        Pos.X += 6;
                    }
                    if (frame > 50 && frame <= 100)
                    {
                        Pos.X -= 6;
                    }
                }
                if (location.Y > 500 && location.X > 200)
                {
                    if (frame <= 50)
                    {
                        Pos.X -= 6;
                    }
                    if (frame > 50 && frame <= 100)
                    {
                        Pos.X += 6;
                    }
                }
            }*/
         
    

            return Pos;
        }
    }
}
