using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.PlayerClass
{
	public class PlayerDownDamaged : IState
	{
		private Player player;
		private int currentFrame;

		public PlayerDownDamaged(Player instance)
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
			player.Speed = Player.ATTACK_KNOCKBACK_SPEED;
			player.Col = Color.Red;
			player.Move(0, -1);
			if (currentFrame <= Player.KNOCKBACK_FRAMES/2)
			{
				player.SourceRectangle = new Rectangle(168, 93, 122, 152);
				player.DrawOffset = new Vector2(0, 0);
			}
			else if(currentFrame <= Player.KNOCKBACK_FRAMES)
			{
				player.SourceRectangle = new Rectangle(6, 94, 141, 152);
				player.DrawOffset = new Vector2(0, 0);
			}
			else
			{
				player.Speed = Player.MOVE_SPEED;
				player.Col = Color.White;
				player.State = new PlayerDownIdle(player);
			}
			currentFrame++;
		}


		public void Attack()
		{
			return;
		}

		public void DamageLink(Player.Directions dir) {
			return;
		}

		
	}
}