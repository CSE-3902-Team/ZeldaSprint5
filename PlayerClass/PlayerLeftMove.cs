using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace Sprint0.PlayerClass
{
	public class PlayerLeftMove : IState
	{
		private Player player;
		private int moveFrame;

		public PlayerLeftMove(Player instance)
		{
			player = instance;
			moveFrame = 1;
		}

		public void ChangeDirection(Player.Directions dir)
		{
			KeyboardState kstate = Keyboard.GetState();
			if (dir == Player.Directions.Up)
			{
				player.State = new PlayerUpMove(player);
			}
			else if (dir == Player.Directions.Right)
			{
				player.State = new PlayerRightMove(player);
			}
			else if (dir == Player.Directions.Down)
			{
				player.State = new PlayerDownMove(player);
			}
			else if (dir == Player.Directions.Idle)
			{
				player.State = new PlayerLeftIdle(player);
			}
		}

		public void Update()
		{
			player.Move(-1, 0);
			if (moveFrame <= 15)
			{
				player.SourceRectangle = new Rectangle(1075, 1714, 129, 139);
				player.DrawOffset = new Vector2(0, 0);
			}
			else
			{
				player.SourceRectangle = new Rectangle(1219, 1704, 138, 149);
				player.DrawOffset = new Vector2(0, 0);
			}
			moveFrame++;
			if (moveFrame > 30)
			{
				moveFrame = 1;
			}
		}

		public void Attack()
		{
			player.State = new PlayerLeftAttack(player);
		}

		public void UseItem(IProjectile proj)
		{
			proj.Direction = new Vector2(-1, 0);
			proj.Position = new Vector2(player.Position.X - 40, player.Position.Y);
			player.Projectiles.Enqueue(proj);
			player.State = new PlayerLeftUseItem(player);
		}
	}
}
