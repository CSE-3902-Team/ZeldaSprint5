using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.PlayerClass
{
	public class PlayerLeftAttack : IState
	{
		private Player player;
		private int currentFrame;

		public PlayerLeftAttack(Player instance)
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
				player.SourceRectangle = new Rectangle(1405, 1979, 247, 142);
				player.DrawOffset = new Vector2(-62, 0);
				player.CollisionOffsetX = new Vector2(-player.DrawOffset.X / 4, player.DrawOffset.X / 4);
				player.CollisionOffsetY = new Vector2(0, 0);
			}
			else
			{
				player.SwordProjectile.IsRunning = false;
				player.State = new PlayerLeftIdle(player);
			}
			currentFrame++;
		}


		public void Attack()
		{
			return;
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
	}
}