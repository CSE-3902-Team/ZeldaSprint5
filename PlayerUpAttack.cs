using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

	public class PlayerUpAttack : IState
	{
		private Player player;
        private int currentFrame;

		public PlayerUpAttack(Player instance)
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
			if (currentFrame <= player.AttackFrames)
			{
				//TODO: get rid of the extra green on link's cap
				player.Draw(new Rectangle(331,879,111,247),-1,-53,Color.White);
			}
			else {
				player.State = new PlayerUpIdle(player);
			}
				currentFrame++;
			}


		public void Attack()
		{
		//Input checking was done in controller
			return;	
		}
	}