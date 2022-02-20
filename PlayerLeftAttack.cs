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

		public void ChangeDirection(Player.Directions dir)
	{
            return;
		}

		public void Update()
		{
			if (currentFrame <= player.AttackFrames)
			{
				player.Draw(new Rectangle(1405,1979,247,142),-62,0,Color.White);
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
	}