using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace Sprint0.PlayerClass
{
	public class PlayerUpMove : IState
	{
		private Player player;
		private int moveFrame;

		public PlayerUpMove(Player instance)
		{
			player = instance;
			moveFrame = 1;
		}

		public void ChangeDirection(Player.Directions dir)
		{
			if (dir == Player.Directions.Down)
			{
				player.State = new PlayerDownMove(player);
			}
			else if (dir == Player.Directions.Left)
			{
				player.State = new PlayerLeftMove(player);
			}
			else if (dir == Player.Directions.Right)
			{
				player.State = new PlayerRightMove(player);
			}
			else if (Player.Directions.Idle == dir)
			{
				player.State = new PlayerUpIdle(player);
			}
		}

		public void Update()
		{
			player.Move(0, -1);
			if (moveFrame <= 15)
			{
				player.Draw(new Rectangle(789, 93, 113, 150), 0, 0, Color.White);
			}
			else
			{
				player.Draw(new Rectangle(637, 93, 133, 161), 0, 0, Color.White);
			}
			moveFrame++;
			if (moveFrame > 30)
			{
				moveFrame = 1;
			}
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
