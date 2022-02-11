using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
public class PlayerDownMove : IState 
{
	private Player player;
	private int moveFrame;

	public PlayerDownMove(Player instance)
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
		else if (kstate.IsKeyDown(Keys.D) || kstate.IsKeyDown(Keys.Right))
		{
			player.State = new PlayerRightMove(player);
		}
		else if(kstate.IsKeyUp(Keys.S) && kstate.IsKeyUp(Keys.Down)) { 
			player.State = new PlayerDownIdle(player);
		}
	}

	public void Update() {
		//update the sprite
		player.Move(0, 1);
		if (moveFrame <= 15)
		{
			player.Draw(new Rectangle(168,93,122,152));
		}
		else {
			player.Draw(new Rectangle(6,94,141,152));
		}
		moveFrame++;
		if (moveFrame > 30) {
			moveFrame = 1;
		}
	}

	public void Attack() {
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.N) || kstate.IsKeyDown(Keys.Z)) { 
			player.State = new PlayerDownAttack(player);
		}
	}
}
