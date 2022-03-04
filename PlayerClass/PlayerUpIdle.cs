using Microsoft.Xna.Framework;

namespace Sprint0.PlayerClass
{
    public class PlayerUpIdle : IState
    {
        private Player player;

        public PlayerUpIdle(Player instance)
        {
            player = instance;
        }

        public void ChangeDirection(Player.Directions dir)
        {
            if (dir == Player.Directions.Up)
            {
                player.State = new PlayerUpMove(player);
            }
            else if (dir == Player.Directions.Left)
            {
                player.State = new PlayerLeftMove(player);
            }
            else if (dir == Player.Directions.Down)
            {
                player.State = new PlayerDownMove(player);
            }
            else if (dir == Player.Directions.Right)
            {
                player.State = new PlayerRightMove(player);
            }
        }

        public void Update()
        {
            player.SourceRectangle = new Rectangle(637, 93, 113, 161);
            player.DrawOffset = new Vector2(0, 0);
        }

        public void Attack()
        {
            player.State = new PlayerUpAttack(player);

        }
        public void UseItem(IProjectile proj)
        {
            proj.Direction = new Vector2(0, -1);
            proj.Position = new Vector2(player.Position.X, player.Position.Y - 40);
            player.Projectiles.Enqueue(proj);
            player.State = new PlayerUpUseItem(player);
        }

    }
}
