using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0 {

	public class KeyboardController : IController
	{
		Game1 myGame;
		Vector2 center;
		public KeyboardController(Game1 g, Vector2 center)
		{
			myGame = g;
			this.center = center;
		}

		public void handleInput() {
			KeyboardState kstate = Keyboard.GetState();

			if (kstate.IsKeyDown(Keys.D0) || kstate.IsKeyDown(Keys.NumPad0)) {
				//return val of 0, exit the game
				myGame.Exit();
			}
			if (kstate.IsKeyDown(Keys.D1) || kstate.IsKeyDown(Keys.NumPad1))
			{
				myGame.CurrentSprite = new IdleNonAnimatedSprite(myGame.SpriteTexture, myGame.SpriteBatch,center, 1.0f);
			} else if (kstate.IsKeyDown(Keys.D2) || kstate.IsKeyDown(Keys.NumPad2)){
				//animated sprite, static 
				myGame.CurrentSprite = new IdleAnimatedSprite(myGame.SpriteTexture, myGame.SpriteBatch, center, 1.0f);
			} else if (kstate.IsKeyDown(Keys.D3) || kstate.IsKeyDown(Keys.NumPad3)) {
				myGame.CurrentSprite = new movingNonAnimatedSprite(myGame.SpriteTexture, myGame.SpriteBatch,center, 1f);
			} else if (kstate.IsKeyDown(Keys.D4) || kstate.IsKeyDown(Keys.NumPad4)) {
				//animated, moving
				myGame.CurrentSprite = new movingAnimatedSprite(myGame.SpriteTexture, myGame.SpriteBatch, center, 1f);
			}


		}
	}
}