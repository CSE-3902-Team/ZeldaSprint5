using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

	public class PlayerRightUseItem : IState
	{
		private Player player;
        private int currentFrame;

		public PlayerRightUseItem(Player instance)
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
				player.Draw(new Rectangle(1115,107,138,136),0,0,Color.White);
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
        public void UseItem(IProjectile proj)
        {
            return;
        }
}