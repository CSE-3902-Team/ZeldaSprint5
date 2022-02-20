using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

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
				player.Draw(new Rectangle(419,1714,137,138),0,0,Color.White);
			}
			else {
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