using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.PlayerClass
{
	public class PlayerRightAttack : IState
	{
		private Player player;
		private int currentFrame;

		public PlayerRightAttack(Player instance)
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
				player.SourceRectangle = new Rectangle(168, 689, 239, 139);
				player.DrawOffset = new Vector2( 62, 0);
			}
			else
			{
				player.State = new PlayerRightIdle(player);
			}
			currentFrame++;
		}


		public void Attack()
		{
			return;
		}
	}
}