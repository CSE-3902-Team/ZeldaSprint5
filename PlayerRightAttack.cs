using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

	public class PlayerRightAttack : IState
	{
		private Player player;
        private int currentFrame;

		public PlayerRightAttack(Player instance)
		{
			player = instance;
			currentFrame = 1;
		}

		public void ChangeDirection()
		{
            return;
		}

		public void Update()
		{
			int maxFrames = 20;
			if (currentFrame <= 5)
			{
				//Fully extended sword
				player.Draw(new Rectangle(168, 689, 239, 139));
			}
			else if (currentFrame <= 10)
			{
				player.Draw(new Rectangle(411, 699, 213, 139));
			}
			else if (currentFrame <= 15)
			{
				player.Draw(new Rectangle(618, 689, 175, 147));
			}
			else if (currentFrame <= maxFrames)
			{
				player.Draw(new Rectangle(6, 703, 140, 138));
			}
			else {
				player.State = new PlayerRightIdle(player);
			}
				currentFrame++;
			}


		public void Attack()
		{
		//Input checking was done in controller
			return;	
		}
	}