﻿using Microsoft.Xna.Framework;

namespace Sprint0.enemy
{
    class FrameChaningforEnemy
    {
        private Vector2 movement;
        private Vector2 Pos;
        int destinationX;
        int destinationY;
        int currentFrame;
        int total;
        public FrameChaningforEnemy(Vector2 currentPos, Vector2 direction, Vector2 destination, int frame)
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
            {

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
        public int goriya()
        {
            switch (movement.X)
            {

                case 0:
                    if (Pos.Y< destinationY)
                    {



                        currentFrame = 0;

                    }
                    if (Pos.Y >destinationY)
                    {

                        currentFrame = 1;

                    }
                    break;
                
                case 1:
                    if (Pos.X< destinationX)
                    {
                        total = 4;
                        currentFrame++;
                        if (currentFrame >= total)
                            currentFrame = 2;

                    }
                    if (Pos.X> destinationX)
                    {
                        total = 4;
                        currentFrame++;
                        if (currentFrame >= total)
                            currentFrame = 2;

                    }
                    break;
            }
            return currentFrame;
        }
        public int dragon()
        {
            if (Pos.X < destinationX)
            {

                total = 4;
                currentFrame++;

                if (currentFrame >= total)
                    currentFrame = 0;

            }
            if (Pos.X >= destinationX)
            {

                total = 4;
                currentFrame++;

                if (currentFrame >= 4)
                    currentFrame = 0;

            }
            return currentFrame;
        }
        public int fireBall()
        {
            total = 5;
            currentFrame++;

            if (currentFrame >= 5)
                currentFrame = 0;
            return currentFrame;
        }

    }
}
