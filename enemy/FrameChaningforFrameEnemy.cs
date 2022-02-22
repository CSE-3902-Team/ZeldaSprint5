using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.enemy
{
    class FrameChaningforFrameEnemy
    {
        private Vector2 movement;
        private Vector2 Pos;
        int destinationX;
        int destinationY;
        int currentFrame;
        int total;
        public FrameChaningforFrameEnemy(Vector2 currentPos,Vector2 direction,Vector2 destination,int frame)
        {
            this.destinationX = (int)destination.X;
            this.destinationY = (int)destination.Y;
            this.movement = direction;
            this.Pos = currentPos;
            this.currentFrame = frame;
    }
        public int frameReturn()
        {
            switch (movement.X)
            {//make the enemies move in a random route.

                case 0:
                    if (Pos.Y < destinationY)
                    {


                        total = 2;
                        currentFrame++;
                        if (currentFrame >= total)
                            currentFrame = 0;

                    }
                    if (Pos.Y > destinationY)
                    {

                        total = 2;
                        currentFrame++;
                        if (currentFrame >= total)
                            currentFrame = 0;

                    }
                    break;
                case 1:
                    if (Pos.X < destinationX)
                    {
                        total = 2;
                        currentFrame++;
                        if (currentFrame >= total)
                            currentFrame = 0;

                    }
                    if (Pos.X > destinationX)
                    {
                        total = 2;
                        currentFrame++;
                        if (currentFrame >= total)
                            currentFrame = 0;

                    }
                    break;
            }
            return currentFrame;
        }
    }
}
