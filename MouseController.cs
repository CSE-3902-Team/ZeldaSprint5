using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0 {

	public class MouseController // : IController
	{
		/*
		Game1 myGame;
		Vector2 center;
		public MouseController(Game1 g, Vector2 center)
		{
			myGame = g;
			this.center = center;
		}
		public void handleInput() {
			MouseState mstate = Mouse.GetState();
			//top right
			Rectangle q2 = new Rectangle((int)center.X, 0, (int)center.X, (int)center.Y);
			//top left
			Rectangle q1 = new Rectangle(0, 0, (int)center.X, (int)center.Y);
			//bottom left
			Rectangle q3 = new Rectangle(0, (int)center.Y, (int)center.X, (int)center.Y);
			//bottom right
			Rectangle q4 = new Rectangle((int)center.X, (int)center.Y, (int)center.X * 2, (int)center.Y);

			if (mstate.LeftButton == ButtonState.Pressed && q1.Contains(new Point(mstate.X, mstate.Y)))
			{
				myGame.CurrentSprite = new IdleNonAnimatedSprite(myGame.SpriteTexture, myGame.SpriteBatch,center, 1.0f);
			}
			else if (mstate.LeftButton == ButtonState.Pressed && q2.Contains(new Point(mstate.X, mstate.Y)))
			{
				myGame.CurrentSprite = new IdleAnimatedSprite(myGame.SpriteTexture, myGame.SpriteBatch, center, 1.0f);
			}
			else if (mstate.LeftButton == ButtonState.Pressed && q3.Contains(new Point(mstate.X, mstate.Y)))
			{
				myGame.CurrentSprite = new movingNonAnimatedSprite(myGame.SpriteTexture, myGame.SpriteBatch,center, 1f);
			}
			else if (mstate.LeftButton == ButtonState.Pressed && q4.Contains(new Point(mstate.X, mstate.Y)))
			{
				myGame.CurrentSprite = new movingAnimatedSprite(myGame.SpriteTexture, myGame.SpriteBatch, center, 1f);
			}
			


			}
		*/
	}
}