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
		int enemyCount = 3;
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
			if (kstate.IsKeyDown(Keys.O))
			{
				if (enemyCount == -1)
				{
					enemyCount = 3;
				}
				myGame.currentEnemy = myGame.enemyList[enemyCount];


				enemyCount--;



			}
			else if (kstate.IsKeyDown(Keys.P))
			{


				if (enemyCount == 4)
				{
					enemyCount = 0;
				}
				myGame.currentEnemy = myGame.enemyList[enemyCount];


				enemyCount++;



			}
			myGame.currentEnemy.Update();
			if (kstate.IsKeyDown(Keys.D0) || kstate.IsKeyDown(Keys.NumPad0)) {
				//return val of 0, exit the game
				myGame.Exit();
			}

			//tile controls
			if (HasBeenPressed(Keys.T))
			{
				count--;
				if (count == -1)
				{
					count = myGame.TileList.Length - 1;
				}
				myGame.CurrentTile = myGame.TileList[count];

			}
			if (HasBeenPressed(Keys.Y))
			{
				count++;
				if (count == myGame.TileList.Length || count == -1)
				{
					count = 0;
				}
				myGame.CurrentTile = myGame.TileList[count];
	

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
			myGame.Player.ChangeDirection();
			myGame.Player.Attack();
			if(kstate.IsKeyDown(Keys.E)){
				myGame.Player.DamageLink();		
			}

			//player projectile controls
			if (HasBeenPressed(Keys.D1))
			{
				myGame.Player.UseItem(new ProjectileFireball(myGame.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
			}
			else if(HasBeenPressed(Keys.D2)) {
				myGame.Player.UseItem(new ProjectileBomb(myGame.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
			}
			else if(HasBeenPressed(Keys.D3)) {
				myGame.Player.UseItem(new ProjectileNormalArrow(myGame.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
			}
			else if(HasBeenPressed(Keys.D4)) {
				myGame.Player.UseItem(new ProjectileNormalBoomerang(myGame.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
			}
			else if(HasBeenPressed(Keys.D5)) {
				myGame.Player.UseItem(new ProjectileSpecialArrow(myGame.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
			}		
			else if(HasBeenPressed(Keys.D6)) {
				myGame.Player.UseItem(new ProjectileSpecialBoomerang(myGame.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
			}
		}

		
	}
}