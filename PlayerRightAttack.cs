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
			//TODO:get rid of green hilt in this texture
			if (currentFrame <= player.AttackFrames)
			{
				//Fully extended sword
				player.Draw(new Rectangle(168, 689, 239, 139),62,0,Color.White);
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