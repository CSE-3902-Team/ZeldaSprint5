using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

	public class PlayerLeftAttack : IState
	{
		private Player player;
        private int currentFrame;

		public PlayerLeftAttack(Player instance)
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
			//TODO:get rid of green hilt in this texture
			if (currentFrame <= player.AttackFrames)
			{
				//Fully extended sword
				player.Draw(new Rectangle(1405,1979,247,142),-62,0,Color.White);
			}
			else {
				player.State = new PlayerLeftIdle(player);
			}
				currentFrame++;
			}


		public void Attack()
		{
		//Input checking was done in controller
			return;	
		}
	}