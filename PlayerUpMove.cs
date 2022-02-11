using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
public class PlayerUpMove : IState 
{
	private Player player;
	private int moveFrame;

	public PlayerUpMove(Player instance)
	{
		player = instance;
		moveFrame = 1;
	}

	public void ChangeDirection() {
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.S))
		{
			player.State = new PlayerDownMove(player);
		}
		else if (kstate.IsKeyDown(Keys.A))
		{
			player.State = new PlayerLeftMove(player);
		}
		else if (kstate.IsKeyDown(Keys.D))
		{
			player.State = new PlayerRightMove(player);
		}
		else if(kstate.IsKeyUp(Keys.W)) { 
			player.State = new PlayerUpIdle(player);
		}
	}

	public void Update() {
		//update the sprite
		player.Move(0, -1);
		if (moveFrame <= 15)
		{
			player.Draw(new Rectangle(789,93,113,150));
		}
		else {
			player.Draw(new Rectangle(637,93,133,161));
		}
		moveFrame++;
		if (moveFrame > 30) {
			moveFrame = 1;
		}
	}

	public void Attack() {
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.N) || kstate.IsKeyDown(Keys.Z)) { 
			//player.State = new PlayerRightAttack(player);
		}
	}
}
