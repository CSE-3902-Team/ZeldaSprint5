using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace Sprint0.PlayerClass
{

	public class PlayerLeftUseItem : IState
	{
		private Player player;
		private int currentFrame;

		public PlayerLeftUseItem(Player instance)
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
				player.SourceRectangle = new Rectangle(419, 1714, 137, 138);
				player.DrawOffset = new Vector2(0, 0);
			}
			else
			{
				player.State = new PlayerLeftIdle(player);
			}
			currentFrame++;
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