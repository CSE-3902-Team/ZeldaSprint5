﻿using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace Sprint0.PlayerClass
{
	public class PlayerUpMove : IPlayerState
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
			player.CollisionOffsetX = new Vector2(0, 0);
			player.CollisionOffsetY = new Vector2(0, 0);
			if (moveFrame <= 15)
			{
				player.SourceRectangle = new Rectangle(789, 93, 113, 150);
				player.DrawOffset = new Vector2(0, 0);
			}
			else
			{
				player.SourceRectangle = new Rectangle(637, 93, 133, 161);
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
			ProjectilePlayerSword sword = new ProjectilePlayerSword(new Vector2(player.Position.X, player.TopLeft.Y),Player.Directions.Up);
			player.SwordProjectile = sword;
			player.AddProjectileCommand.LoadCommand(sword);
			player.AddProjectileCommand.Execute();
			player.State = new PlayerUpAttack(player);
		}

		public void UseItem(IProjectile proj)
		{

			proj.Direction = new Vector2(0, -1);
			proj.Position = new Vector2(player.Position.X, player.Position.Y - 40);
			player.AddProjectileCommand.LoadCommand(proj);
			player.AddProjectileCommand.Execute();
			player.State = new PlayerUpUseItem(player);
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
