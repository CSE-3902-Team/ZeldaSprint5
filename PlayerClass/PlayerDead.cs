using Microsoft.Xna.Framework;
using System;

namespace Sprint0.PlayerClass
{
    public class PlayerDead : IState
    {
        private Player player;
        private int currentFrame;
        private int spinCount;
        private bool HasWaited;
        private bool star1IsDone;
        private const int FRAMES_PER_SPIN = 7;
        private const int FRAMES_PER_STAR = 35;
        private const int MAX_SPINS = 3;
        private const int WAIT_TIME = 20;
        private Rectangle grayStar;
        private Rectangle yellowStar;
        private Rectangle nothing;
        

        private enum SpinDirections {
            Down,
            Right,
            Up,
            Left,
        }

        public PlayerDead(Player instance)
        {
            player = instance;
            currentFrame = 1;
            HasWaited = false;
            star1IsDone = false;
            spinCount = 0;
            grayStar = new Rectangle(1861, 1523, 368, 399);
            yellowStar = new Rectangle(2326, 1500, 368, 425);
            nothing = new Rectangle(129, 281, 1, 1); 

        }

        public void ChangeDirection(Player.Directions dir)
        {
            return;
        }

        

        public void Update()
        {
            Console.WriteLine("waittime=" + currentFrame);
            //Link spins four times around, waits, and is replaced with a star and then fades to blackness.
            if (spinCount < MAX_SPINS)
            {
                currentFrame++;
                SpinLink();
            }
            else if (!HasWaited)
            {
                currentFrame++;
                if (currentFrame >= WAIT_TIME)
                {
                    HasWaited = true;
                    currentFrame = 0;
                }
            }
            else if (!star1IsDone)
            {
                NextStarFrame();
            }
            else {
                player.IsDead = true;
            }

            player.DrawOffset = new Vector2(0, 0);
            player.CollisionOffsetX = new Vector2(0, 0);
            player.CollisionOffsetY = new Vector2(0, 0);
            currentFrame++;
        }

        public void DamageLink(Player.Directions dir)
        {
            return;
        }

        public void Attack()
        {
            return;
        }

        private void SpinLink()
        {
            if (currentFrame <= FRAMES_PER_SPIN * 1)
            {
                SetSourceRectangle(SpinDirections.Down);
            }
            else if (currentFrame <= FRAMES_PER_SPIN * 2)
            {
                SetSourceRectangle(SpinDirections.Right);
            }
            else if (currentFrame <= FRAMES_PER_SPIN * 3)
            {
                SetSourceRectangle(SpinDirections.Up);
            }
            else if (currentFrame <= FRAMES_PER_SPIN * 4)
            {
                SetSourceRectangle(SpinDirections.Left);
            }
            else if (currentFrame <= FRAMES_PER_SPIN * 5) {
                SetSourceRectangle(SpinDirections.Down);
            }
            else
            {
                //One Spin Completed
                currentFrame = 1;
                spinCount++;
                Console.WriteLine("Spin count =" + spinCount);

            }
        }

        private void SetSourceRectangle(SpinDirections stage)
        {
            switch (stage)
            {
                case SpinDirections.Down:
                    //Link faces down
                    player.SourceRectangle = new Rectangle(6, 94, 141, 152);
                    break;
                case SpinDirections.Right:
                    player.SourceRectangle = new Rectangle(312, 95, 140, 152);
                    break;
                case SpinDirections.Up:
                    player.SourceRectangle = new Rectangle(637, 93, 113, 161);
                    break;
                case SpinDirections.Left:
                    player.SourceRectangle = new Rectangle(1219, 1704, 138, 149);
                    break;
            }
        }

        private void NextStarFrame()
        {
            if (currentFrame <= FRAMES_PER_STAR * 1)
            {
                player.Scale = 0.05f;
                player.SourceRectangle = grayStar;
            }
            else if (currentFrame <= FRAMES_PER_STAR * 2)
            {
                player.Scale = 0.08f;
                player.SourceRectangle = grayStar;
            }
            else if (currentFrame <= FRAMES_PER_STAR * 3)
            {
                player.Scale = 0.1f;
                player.SourceRectangle = yellowStar;
            }
            else if (currentFrame <= FRAMES_PER_STAR * 3)
            {
                player.Scale = 0.8f;
                player.SourceRectangle = yellowStar;
            }
            else if (currentFrame <= FRAMES_PER_STAR * 4)
            {
                player.SourceRectangle = nothing;
                star1IsDone = true;
            }
           
        }
    }
}