using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace Sprint0.PlayerClass
{
	public class PlayerDownAttack : IState
	{
		private Player player;
		private int currentFrame;

		public PlayerDownAttack(Player instance)
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
				player.SourceRectangle = new Rectangle(157, 420, 141, 248);
				player.DrawOffset = new Vector2(-1, 52);
				player.Draw();
			}
			else
			{
				player.State = new PlayerDownIdle(player);
			}
			currentFrame++;
		}


		public void Attack()
		{
			return;
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
	}
}