using Microsoft.Xna.Framework;

namespace Sprint0.PlayerClass
{
    public class PlayerDownMove : IState
    {
        private Player player;
        private int moveFrame;

        public PlayerDownMove(Player instance)
        {
            player = instance;
            moveFrame = 1;
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
            else if (dir == Player.Directions.Right)
            {
                player.State = new PlayerRightMove(player);
            }
            else if (dir == Player.Directions.Idle)
            {
                player.State = new PlayerDownIdle(player);
            }
        }

        public void Update()
        {
            player.Move(0, 1);
            if (moveFrame <= 15)
            {
                player.SourceRectangle = new Rectangle(168, 93, 122, 152);
                player.DrawOffset = new Vector2(0, 0);
                player.Draw();
            }
            else
            {
                player.SourceRectangle = new Rectangle(6, 94, 141, 152);
                player.DrawOffset = new Vector2(0, 0);
                player.Draw();
            }
            moveFrame++;
            if (moveFrame > 30)
            {
                moveFrame = 1;
            }
        }

        public void Attack()
        {
            player.State = new PlayerDownAttack(player);
        }

        public void UseItem(IProjectile proj)
        {
            proj.Direction = new Vector2(0, 1);
            proj.Position = new Vector2(player.Position.X, player.Position.Y + 40);
            player.Projectiles.Enqueue(proj);
            player.State = new PlayerDownUseItem(player);
        }
    }
}