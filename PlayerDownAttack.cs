using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

	public class PlayerDownAttack : IState
	{
		private Player player;
        private int currentFrame;

		public PlayerDownAttack(Player instance)
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
				player.Draw(new Rectangle(157,420,141,248),-1,52,Color.White);
			}
			else {
				player.State = new PlayerDownIdle(player);
			}
				currentFrame++;
			}


		public void Attack()
		{
		//Input checking was done in controller
			return;	
		}
	}