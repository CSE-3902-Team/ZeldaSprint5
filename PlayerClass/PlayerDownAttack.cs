using Microsoft.Xna.Framework;

namespace Sprint0.PlayerClass
{
    public class PlayerDownAttack : IState
    {
        private Player player;
        private int currentFrame;

        public PlayerDownAttack(Player instance)
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
                player.SourceRectangle = new Rectangle(157, 420, 141, 248);
                player.DrawOffset = new Vector2(-1, 52);
                player.Draw();
            }
            else
            {
                player.State = new PlayerDownIdle(player);
            }
            currentFrame++;
        }


        public void Attack()
        {
            return;
        }
    }
}