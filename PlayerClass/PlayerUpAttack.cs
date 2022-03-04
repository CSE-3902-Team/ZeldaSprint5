using Microsoft.Xna.Framework;

namespace Sprint0.PlayerClass
{
    public class PlayerUpAttack : IState
    {
        private Player player;
        private int currentFrame;

        public PlayerUpAttack(Player instance)
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
            if (currentFrame <= player.AttackFrames)
            {
                player.SourceRectangle = new Rectangle(331, 879, 111, 247);
                player.DrawOffset = new Vector2(-1, -53);
            }
            else
            {
                player.State = new PlayerUpIdle(player);
            }
            currentFrame++;
        }


        public void Attack()
        {
            return;
        }
    }
}