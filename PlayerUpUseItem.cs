using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

	public class PlayerUpUseItem : IState
	{
		private Player player;
        private int currentFrame;

		public PlayerUpUseItem(Player instance)
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
				player.Draw(new Rectangle(1267,97,147,147),0,0,Color.White);
			}
			else {
				player.State = new PlayerUpIdle(player);
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