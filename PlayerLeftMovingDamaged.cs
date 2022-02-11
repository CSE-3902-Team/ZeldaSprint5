
	/*
using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class PlayerRightAttack : IState 
{
	private Player player;

	public PlayerRightAttack(Player instance)
	{
		this.player = instance;
	}

	public void ChangeDirection() {
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.W))
		{
			//player.State = new PlayerUpMove(player);
		}
		else if (kstate.IsKeyDown(Keys.A))
		{
			//player.State = new PlayerLeftMove(player);
		}
		else if (kstate.IsKeyDown(Keys.S))
		{
			//player.State = new PlayerDownMove(player);
		}
		else if(kstate.IsKeyUp(Keys.D)) { 
			//player.State = new PlayerRightDamagedIdle(player);
		}
	}

	public void Update() {
		//update the sprite
		player.Draw(new Rectangle(56, 0, 24, 16));

	}

	public void Attack() {
		//Input checking was done in controller
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.N) || kstate.IsKeyDown(Keys.Z)) { 
			//player.State = new PlayerRightAttackDamaged(player);
		}
	}
}

	*/
