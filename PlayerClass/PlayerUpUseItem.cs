using Microsoft.Xna.Framework;

namespace Sprint0.PlayerClass
{
    public class PlayerUpUseItem : IState
    {
        private Player player;
        private int currentFrame;

        public PlayerUpUseItem(Player instance)
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
                player.SourceRectangle = new Rectangle(1267, 97, 147, 147);
                player.DrawOffset = new Vector2(0, 0);
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

        public void UseItem(IProjectile proj)
        {
            return;
        }
    }
}