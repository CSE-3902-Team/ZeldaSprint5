using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
public class PlayerRightMove : IState 
{
	private Player player;
	private int moveFrame;

	public PlayerRightMove(Player instance)
	{
		player = instance;
		moveFrame = 1;
	}

	public void ChangeDirection() {
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.W) || kstate.IsKeyDown(Keys.Up))
		{
			player.State = new PlayerUpMove(player);
		}
		else if (kstate.IsKeyDown(Keys.A) || kstate.IsKeyDown(Keys.Left))
		{
			player.State = new PlayerLeftMove(player);
		}
		else if (kstate.IsKeyDown(Keys.S) || kstate.IsKeyDown(Keys.Down))
		{
			player.State = new PlayerDownMove(player);
		}
		else if(kstate.IsKeyUp(Keys.D) && kstate.IsKeyUp(Keys.Right)) { 
			player.State = new PlayerRightIdle(player);
		}
	}

	public void Update() {
		//update the sprite
		player.Move(1, 0);
		if (moveFrame <= 15)
		{
			player.Draw(new Rectangle(466,105,131,142));
		}
		else {
			player.Draw(new Rectangle(312,95,140,152));
		}
		moveFrame++;
		if (moveFrame > 30) {
			moveFrame = 1;
		}
	}

	public void Attack() {
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.N) || kstate.IsKeyDown(Keys.Z))
		{
			player.State = new PlayerRightAttack(player);
		}
	}
}
