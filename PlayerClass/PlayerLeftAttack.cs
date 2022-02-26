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
	}
}