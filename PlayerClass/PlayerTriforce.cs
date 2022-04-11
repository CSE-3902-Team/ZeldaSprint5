using Microsoft.Xna.Framework;
using System;

namespace Sprint0.PlayerClass
{
    public class PlayerTriforce : IState
    {
        private Player player;
        private int currentFrame;
        private int TOTAL_FRAMES = 120;
        private Rectangle TriforceFrame;

        public PlayerTriforce(Player instance)
        {
            player = instance;
            currentFrame = 1;
            TriforceFrame = new Rectangle(2080, 2506, 130, 242);
        }

        public void ChangeDirection(Player.Directions dir)
        {
            return;
        }

        public void Update()
        {

            //make texture the triforce, play the music, then set some boolean for the state change
            if (currentFrame > TOTAL_FRAMES)
            {
                player.HasTriforce = true;

            }
            player.SourceRectangle = TriforceFrame;
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