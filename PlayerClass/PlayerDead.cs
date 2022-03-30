using Microsoft.Xna.Framework;

namespace Sprint0.PlayerClass
{
    public class PlayerDead : IState
    {
        private Player player;
        private int currentFrame;
        private const int DEATH_FRAMES = 20;

        public PlayerDead(Player instance)
        {
            player = instance;
            currentFrame = 1;
        }

        public void ChangeDirection(Player.Directions dir)
        {
            return;
        }

        public void Update()
        {
            //Link spins around, is replaced with a star and then fades to blackness.
            if (currentFrame <= DEATH_FRAMES / 8)
            {
                //Link faces down
                player.SourceRectangle = new Rectangle(6, 94, 141, 152);
                player.DrawOffset = new Vector2(0, 0);
                player.CollisionOffsetX = new Vector2(0, 0);
                player.CollisionOffsetY = new Vector2(0, 0);
            }
            else if (currentFrame <= 2 * DEATH_FRAMES / 8)
            {
                //Link faces right
                player.SourceRectangle = new Rectangle(312, 95, 140, 152);
                player.DrawOffset = new Vector2(0, 0);
                player.CollisionOffsetX = new Vector2(0, 0);
                player.CollisionOffsetY = new Vector2(0, 0);
            }
            else if (currentFrame <= 3 * DEATH_FRAMES / 8)
            {
                player.SourceRectangle = new Rectangle(637, 93, 113, 161);
                player.DrawOffset = new Vector2(0, 0);
                player.CollisionOffsetX = new Vector2(0, 0);
                player.CollisionOffsetY = new Vector2(0, 0);
            }
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