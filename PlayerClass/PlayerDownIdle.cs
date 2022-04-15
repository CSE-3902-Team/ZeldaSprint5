using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace Sprint0.PlayerClass
{
	public class PlayerDownIdle : IPlayerState
	{
		private Player player;

		public PlayerDownIdle(Player instance)
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
			player.SourceRectangle = new Rectangle(6, 94, 141, 152);
			player.DrawOffset = new Vector2(0, 0);
			player.CollisionOffsetX = new Vector2(0, 0);
			player.CollisionOffsetY = new Vector2(0, 0);
			player.Draw();

		}

		public void Attack()
		{
			ProjectilePlayerSword sword = new ProjectilePlayerSword(new Vector2(player.Position.X, player.BottomRight.Y), Player.Directions.Down);
			player.SwordProjectile = sword;
			player.AddProjectileCommand.LoadCommand(sword);
			player.AddProjectileCommand.Execute();
			player.State = new PlayerDownAttack(player);
		}
		public void UseItem(IProjectile proj)
		{
			proj.Direction = new Vector2(0, 1);
			proj.Position = new Vector2(player.Position.X, player.Position.Y + 40);
			player.AddProjectileCommand.LoadCommand(proj);
			player.AddProjectileCommand.Execute();
			player.State = new PlayerDownUseItem(player);
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