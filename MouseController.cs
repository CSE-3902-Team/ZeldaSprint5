using Sprint0;
using System;
using Microsoft.Xna.Framework.Input;
using Sprint0.LevelClass;

public class MouseController : IController
{
	Game1 game;
	LevelManager levelManger;
	private MouseState mState;
	private MouseState previousState;

	

	public MouseController(Game1 thisGame)
	{
		this.game = thisGame;
		levelManger = LevelManager.Instance;
	}

	private bool LeftButtonHasBeenPressed()
	{
		return mState.LeftButton == ButtonState.Pressed && previousState.LeftButton == ButtonState.Released;
	}

	public void handleInput()
	{
		previousState = mState;
		mState = Mouse.GetState();

		if (LeftButtonHasBeenPressed())
			{
				game.CurrentRoom = levelManger.SwitchRoom();
			}
	}

	void Exit()
	{
		this.game.Exit();
	}
}
