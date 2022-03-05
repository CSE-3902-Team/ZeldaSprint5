using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.PlayerClass
{
	public class PlayerLeftDamaged : IState
	{
		private Player player;
		private int currentFrame;

		public PlayerLeftDamaged(Player instance)
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
			player.Move(1, 0);
			player.Col = Color.Red;
			if (currentFrame <= Player.KNOCKBACK_FRAMES/2)
			{
				player.SourceRectangle = new Rectangle(1075, 1714, 129, 139);
				player.DrawOffset = new Vector2(0, 0);
			}
			else if(currentFrame <= Player.KNOCKBACK_FRAMES)
			{
				player.SourceRectangle = new Rectangle(1219, 1704, 138, 149);
				player.DrawOffset = new Vector2(0, 0);
			}
			else
			{
				player.Speed = Player.MOVE_SPEED;
				player.Col = Color.White;
				player.State = new PlayerLeftIdle(player);
			}
			currentFrame++;
		}


		public void Attack()
		{
			return;
		}

		public void DamageLink(Player.Directions dir)
		{
			return;
		}
	}
}