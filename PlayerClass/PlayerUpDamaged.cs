using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.PlayerClass
{
	public class PlayerUpDamage : IState
	{
		private Player player;
		private int currentFrame;

		public PlayerUpDamage(Player instance)
		{
			player = instance;
			currentFrame = 1;
		}

		public void ChangeDirection(Player.Directions dir)
		{
			//Only should be able to move after a certain amount of frames afterwards it should blink..but what about
			//transitioning states and carrying over the blink the time. Might have to be a instance variable for damaged time
			//Only real reason to have a state is for the knockback. Kinda violates the state machine but that's all I can do
			//k
			return;
		}

		public void Update()
		{
			if (currentFrame <= player.AttackFrames)
			{
				player.SourceRectangle = new Rectangle(331, 879, 111, 247);
				player.DrawOffset = new Vector2(-1, -53);
			}
			else
			{
				player.State = new PlayerUpIdle(player);
			}
			currentFrame++;
		}


		public void Attack()
		{
			return;
		}
	}
}