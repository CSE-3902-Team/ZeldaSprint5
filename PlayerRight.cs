using System;
using Microsoft.Xna.Framework.Input;
public class PlayerRight : IMoveState 
{
	private Player player;

	public PlayerRight(Player instance)
	{
		player = instance;	
	}

	public void ChangeDirection() {
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.W))
		{
			//player.MoveState = new PlayerUp(player);
		}
		else if (kstate.IsKeyDown(Keys.A))
		{
			//player.MoveState = new PlayerLeft(player);
		}
		else if (kstate.IsKeyDown(Keys.S)) {
			//player.MoveState = new PlayerDown(player);
		}
	}

	public void Update() { 
		//logic to change current sprite
		//Call player move methods. Make a while loop with key down?
		//This method is called in controller and assumes we already changed to correct state
		KeyboardState kstate = Keyboard.GetState();
		while (kstate.IsKeyDown(Keys.D)) {
			//positive = down or right, negative = up or left
			player.Move(1, 0);
			player.draw();
		}
	}

	public void Attack() { 
		//This is called in the controller based on a key press. This is attack with sword
		//Every state also needs an use item method. Pass in an item object.
	}

	public Player

}
