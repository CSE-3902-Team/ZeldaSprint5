using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.PlayerClass
{
	public class PlayerUpDamaged : IState
	{
		private Player player;
		private int currentFrame;

		public PlayerUpDamaged(Player instance)
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
			player.Move(0, 1);
			player.Col = Color.Red;
			player.CollisionOffsetX = new Vector2(0, 0);
			player.CollisionOffsetY = new Vector2(0, 0);
			if (currentFrame <= Player.KNOCKBACK_FRAMES/2)
			{
				player.SourceRectangle = new Rectangle(789, 93, 113, 150);
				player.DrawOffset = new Vector2(0, 0);
			}
			else if(currentFrame <= Player.KNOCKBACK_FRAMES)
			{
				player.SourceRectangle = new Rectangle(637, 93, 133, 161);
				player.DrawOffset = new Vector2(0, 0);
			}
			else
			{
				player.Speed = Player.MOVE_SPEED;
				player.Col = Color.White;
				player.State = new PlayerUpIdle(player);
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