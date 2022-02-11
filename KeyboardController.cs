using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Sprint0 {

	public class KeyboardController : IController
	{
		Game1 myGame;
		Vector2 center;
		int count = 0;
		bool keyPressed = false; // TODO: remove
		bool keyPressed2 = false; // TODO: remove
		private KeyboardState kstate;
		private KeyboardState previousState;
		public KeyboardController(Game1 g, Vector2 center)
		{
			myGame = g;
			this.center = center;
		}

		private bool HasBeenPressed(Keys key)
		{
			return kstate.IsKeyDown(key) && !previousState.IsKeyDown(key);
		}

		public void handleInput() {
			previousState = kstate;
			kstate = Keyboard.GetState();

			if (kstate.IsKeyDown(Keys.D0) || kstate.IsKeyDown(Keys.NumPad0)) {
				//return val of 0, exit the game
				myGame.Exit();
			}
			if (kstate.IsKeyDown(Keys.D1) || kstate.IsKeyDown(Keys.NumPad1))
			{
				myGame.CurrentSprite = new IdleNonAnimatedSprite(myGame.SpriteTexture, myGame.SpriteBatch, center, 1.0f);
			}
			else if (kstate.IsKeyDown(Keys.D2) || kstate.IsKeyDown(Keys.NumPad2))
			{
				//animated sprite, static 
				myGame.CurrentSprite = new IdleAnimatedSprite(myGame.SpriteTexture, myGame.SpriteBatch, center, 1.0f);
			}
			else if (kstate.IsKeyDown(Keys.D3) || kstate.IsKeyDown(Keys.NumPad3))
			{
				myGame.CurrentSprite = new movingNonAnimatedSprite(myGame.SpriteTexture, myGame.SpriteBatch, center, 1f);
			}
			else if (kstate.IsKeyDown(Keys.D4) || kstate.IsKeyDown(Keys.NumPad4))
			{
				//animated, moving
				myGame.CurrentSprite = new movingAnimatedSprite(myGame.SpriteTexture, myGame.SpriteBatch, center, 1f);
			}

			//tile controls
			else if (kstate.IsKeyDown(Keys.T) || keyPressed)
			{
				keyPressed = true;
				if (keyPressed && kstate.IsKeyUp(Keys.T))
				{
					if (count == -1)
					{
						count = myGame.TileList.Length - 1;
					}
					myGame.CurrentTile = myGame.TileList[count];
					count--;
					keyPressed = false;

				}
			}
			else if (kstate.IsKeyDown(Keys.Y) || keyPressed2)
			{
				keyPressed2 = true;
				if (keyPressed2 && kstate.IsKeyUp(Keys.Y))
				{
					if (count == myGame.TileList.Length)
					{
						count = 0;
					}
					myGame.CurrentTile = myGame.TileList[count];
					count++;
					keyPressed2 = false;
				}

			}

			//item keys
			if (HasBeenPressed(Keys.U)) {
				myGame.shownItem = myGame.itemFactoryPublic.previousItem();
			}
			else if (HasBeenPressed(Keys.I))
			{
				myGame.shownItem = myGame.itemFactoryPublic.nextItem();
			}

			if (HasBeenPressed(Keys.Q))
			{
				//return val of 0, exit the game
				myGame.Exit();
			}
			else if (HasBeenPressed(Keys.R))
			{
				myGame.reset();
			}
		}
	}
}