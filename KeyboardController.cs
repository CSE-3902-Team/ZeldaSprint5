using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.LevelClass;


namespace Sprint0 {

	public class KeyboardController : IController
	{
		Game1 myGame;
		Vector2 center;
		LevelManager levelManger;
		//int count = 0;
		//int enemyCount = 3;


	
		private KeyboardState kstate;
		private KeyboardState previousState;
		public KeyboardController(Game1 g, Vector2 center)
		{
			myGame = g;
			this.center = center;
			levelManger = LevelManager.Instance;
		}

		private bool HasBeenPressed(Keys key)
		{
			return kstate.IsKeyDown(key) && !previousState.IsKeyDown(key);
		}

		public bool AllMovementKeysUp() {
			bool rval = true;
			Keys[] moveKeys = { Keys.A, Keys.D, Keys.W, Keys.S, Keys.Up, Keys.Down, Keys.Left, Keys.Right };
			foreach (Keys k in moveKeys) {
				if (kstate.IsKeyDown(k))
				{
					rval = false;
				}
			}
			return rval;
		}

		public void handleInput() {
			previousState = kstate;
			kstate = Keyboard.GetState();
			
				/*if (HasBeenPressed(Keys.O))
				{
					enemyCount--;
					if (enemyCount == -1)
					{
						enemyCount = 6;
					}
					else if (enemyCount == 7)
						enemyCount = 2;
					myGame.currentEnemy = myGame.enemyList[enemyCount];






				}

				else if  (HasBeenPressed(Keys.P))
					{

					enemyCount++;
					if (enemyCount == 7)
					{
						enemyCount = 0;
					}
					else if (enemyCount == -1)
						enemyCount = 1;
					myGame.currentEnemy = myGame.enemyList[enemyCount];

				}*/

				//tile controls
				/*if (HasBeenPressed(Keys.T))
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
				*/
				//item keys
				if (HasBeenPressed(Keys.U)) {
				//myGame.shownItem = myGame.itemFactoryPublic.previousItem();
			}
			else if (HasBeenPressed(Keys.I))
			{
				//myGame.shownItem = myGame.itemFactoryPublic.nextItem();
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
			if (kstate.IsKeyDown(Keys.E)) {
				levelManger.Player.DamageLink();
			}

			if (kstate.IsKeyDown(Keys.W) || kstate.IsKeyDown(Keys.Up))
			{
				levelManger.Player.ChangeDirection(Player.Directions.Up);
			}
			else if (kstate.IsKeyDown(Keys.A) || kstate.IsKeyDown(Keys.Left))
			{
				levelManger.Player.ChangeDirection(Player.Directions.Left);
			}
			else if (kstate.IsKeyDown(Keys.S) || kstate.IsKeyDown(Keys.Down))
			{
				levelManger.Player.ChangeDirection(Player.Directions.Down);
			}
			else if (kstate.IsKeyDown(Keys.D) || kstate.IsKeyDown(Keys.Right))
			{
				levelManger.Player.ChangeDirection(Player.Directions.Right);
			}
			else if (AllMovementKeysUp()) {
				levelManger.Player.ChangeDirection(Player.Directions.Idle);
			}

			if (kstate.IsKeyDown(Keys.Z) || kstate.IsKeyDown(Keys.N))
			{
				levelManger.Player.Attack();
			}

			//player projectile controls
			if (HasBeenPressed(Keys.D1))
			{
				levelManger.Player.UseItem(new ProjectileFireball(levelManger.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
			}
			else if(HasBeenPressed(Keys.D2)) {
				levelManger.Player.UseItem(new ProjectileBomb(levelManger.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
			}
			else if(HasBeenPressed(Keys.D3)) {
				levelManger.Player.UseItem(new ProjectileNormalArrow(levelManger.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
			}
			else if(HasBeenPressed(Keys.D4)) {
				levelManger.Player.UseItem(new ProjectileNormalBoomerang(levelManger.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
			}
			else if(HasBeenPressed(Keys.D5)) {
				levelManger.Player.UseItem(new ProjectileSpecialArrow(levelManger.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
			}		
			else if(HasBeenPressed(Keys.D6)) {
				levelManger.Player.UseItem(new ProjectileSpecialBoomerang(levelManger.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
			}
		}

		
	}
}