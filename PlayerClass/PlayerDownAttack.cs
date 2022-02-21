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
				player.Draw(new Rectangle(157, 420, 141, 248), -1, 52, Color.White);
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
	}
}