using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace Sprint0.PlayerClass
{
	public class PlayerLeftIdle : IPlayerState
	{
		private Player player;

		public PlayerLeftIdle(Player instance)
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
			player.SourceRectangle = new Rectangle(1219, 1704, 138, 149);
			player.DrawOffset = new Vector2(0, 0);
			player.CollisionOffsetX = new Vector2(0, 0);
			player.CollisionOffsetY = new Vector2(0, 0);
		}

		public void Attack()
		{
			ProjectilePlayerSword sword = new ProjectilePlayerSword(new Vector2(player.TopLeft.X, player.Position.Y), Player.Directions.Left);
			player.SwordProjectile = sword;
			player.AddProjectileCommand.LoadCommand(sword);
			player.AddProjectileCommand.Execute();
			player.State = new PlayerLeftAttack(player);

		}

		public void UseItem(IProjectile proj)
		{
			proj.Direction = new Vector2(-1, 0);
			proj.Position = new Vector2(player.Position.X - 50, player.Position.Y);
			player.AddProjectileCommand.LoadCommand(proj);
			player.AddProjectileCommand.Execute();
			player.State = new PlayerLeftUseItem(player);
		}

		public void DamageLink(Player.Directions dir)
		{
			player.PlayerHp = player.PlayerHp - 1;
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
	}
}