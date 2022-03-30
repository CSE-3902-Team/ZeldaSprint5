using Microsoft.Xna.Framework;

namespace Sprint0.PlayerClass
{
    public class PlayerDead : IState
    {
        private Player player;
        private int currentFrame;
        private int spinCount;
        private bool HasWaited;
        private bool star1IsDone;
        private const int FRAMES_PER_SPIN = 5;
        

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
            spinCount = 0;
        }

        public void ChangeDirection(Player.Directions dir)
        {
            return;
        }

        private void SpinLink(SpinDirections stage)
        {
            switch (stage) {
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

        public void Update()
        {
            //Link spins four times around, waits, and is replaced with a star and then fades to blackness.


            if (spinCount < 4)
            {
                if (currentFrame <= FRAMES_PER_SPIN * 1)
                {
                    SpinLink(SpinDirections.Down);
                }
                else if (currentFrame <= FRAMES_PER_SPIN * 2)
                {
                    SpinLink(SpinDirections.Right);
                }
                else if (currentFrame <= FRAMES_PER_SPIN * 3)
                {
                    SpinLink(SpinDirections.Up);
                }
                else if (currentFrame <= FRAMES_PER_SPIN * 4)
                {
                    SpinLink(SpinDirections.Left);
                }
                else
                {
                    currentFrame = 1;
                    spinCount++;
                }
            }
            else if (!HasWaited)
            {
                currentFrame++;
                if (currentFrame == 5)
                {
                    HasWaited = true;
                }
            }
            else if (!star1IsDone) 
            {
            
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
    }
}