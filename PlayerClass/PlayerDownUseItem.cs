using Microsoft.Xna.Framework;

namespace Sprint0.PlayerClass
{
    public class PlayerDownUseItem : IState
    {
        private Player player;
        private int currentFrame;

        public PlayerDownUseItem(Player instance)
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
                player.SourceRectangle = new Rectangle(960, 97, 140, 139);
                player.DrawOffset = new Vector2(0, 0);
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

        public void UseItem(IProjectile proj)
        {
            return;
        }
    }
}