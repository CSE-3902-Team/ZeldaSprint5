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
                player.CollisionOffsetX = new Vector2(0, 0);
                player.CollisionOffsetY = new Vector2(-player.DrawOffset.Y / 4, player.DrawOffset.Y / 4);
            }
            else
            {
                player.SwordProjectile.IsRunning = false;
                player.State = new PlayerUpIdle(player);
            }
            currentFrame++;
        }

		public void DamageLink(Player.Directions dir)
		{
            player.PlayerHp = player.PlayerHp - 1;
            player.SwordProjectile.IsRunning = false;
            switch (dir)
			{
				case Player.Directions.Up:
					player.State = new PlayerUpDamaged(player);
					break;
				case Player.Directions.Down:
					player.State = new PlayerDownDamaged(player);
					break;
				case Player.Directions.Left:
					player.State = new PlayerLeftDamaged(player);
					break;
				case Player.Directions.Right:
					player.State = new PlayerRightDamaged(player);
					break;
			}
		}

        public void Attack()
        {
            return;
        }
    }
}