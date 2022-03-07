using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace Sprint0.PlayerClass
{
	public class PlayerRightUseItem : IState
	{
		private Player player;
		private int currentFrame;

		public PlayerRightUseItem(Player instance)
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
				player.SourceRectangle = new Rectangle(1115, 107, 138, 136);
				player.DrawOffset = new Vector2(0, 0);
			}
			else
			{
				player.State = new PlayerRightIdle(player);
			}
			currentFrame++;
		}

		public void DamageLink(Player.Directions dir)
		{
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
		public void UseItem(IProjectile proj)
		{
			return;
		}
	}
}