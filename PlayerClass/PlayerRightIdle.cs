using Microsoft.Xna.Framework;

namespace Sprint0.PlayerClass
{
    public class PlayerRightIdle : IState
    {
        private Player player;

        public PlayerRightIdle(Player instance)
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
            player.SourceRectangle = new Rectangle(312, 95, 140, 152);
            player.DrawOffset = new Vector2(0, 0);
        }

        public void Attack()
        {
            player.State = new PlayerRightAttack(player);
        }

        public void UseItem(IProjectile proj)
        {
            proj.Direction = new Vector2(1, 0);
            proj.Position = new Vector2(player.Position.X + 40, player.Position.Y);
            player.Projectiles.Enqueue(proj);
            player.State = new PlayerRightUseItem(player);
        }
    }

}