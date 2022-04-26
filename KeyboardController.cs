using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.LevelClass;
using Sprint0.StateClass;

namespace Sprint0 {

	public class KeyboardController : IController
	{
		Game1 myGame;
		Vector2 center;
		LevelManager levelManager;


	
		private KeyboardState kstate;
		private KeyboardState previousState;
		private Boolean inventoryOpen = false;

		
		public KeyboardController(Game1 g, Vector2 center)
		{
			myGame = g;
			this.center = center;
			levelManager = LevelManager.Instance;
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

			if (myGame.CurrentState.IsMenuState)
			{

				if (HasBeenPressed(Keys.H))
				{
					myGame.TwoPlayer = false;
					myGame.LoadStates();
					myGame.ChangeState(1);
					myGame.SoundManager.PauseAllSounds();
					myGame.SoundManager.Play(SoundManager.Sound.BG_MUSIC);
				}
				else if (HasBeenPressed(Keys.J))
				{
					myGame.TwoPlayer = true;
					myGame.LoadStates();
					myGame.ChangeState(1);
					myGame.SoundManager.PauseAllSounds();
					myGame.SoundManager.Play(SoundManager.Sound.BG_MUSIC);
				}
				else if (HasBeenPressed(Keys.E))
				{
					myGame.Exit();
				}

			}else if (myGame.CurrentState.IsInventory)
            {

				if (HasBeenPressed(Keys.W) || HasBeenPressed(Keys.Up))
				{

					(myGame.CurrentState as GameInventoryState).MoveBox(0, -1, Keys.Up);

				}

				if (HasBeenPressed(Keys.A) || HasBeenPressed(Keys.Left))
				{

					(myGame.CurrentState as GameInventoryState).MoveBox(-1, 0, Keys.Left);

				}

				if (HasBeenPressed(Keys.S) || HasBeenPressed(Keys.Down))
				{

					(myGame.CurrentState as GameInventoryState).MoveBox(0, 1, Keys.Down);

				}

				if (HasBeenPressed(Keys.D) || HasBeenPressed(Keys.Right))
				{

					(myGame.CurrentState as GameInventoryState).MoveBox(1, 0, Keys.Right);

				}
				if (HasBeenPressed(Keys.Enter))
				{
					(myGame.CurrentState as GameInventoryState).Select((myGame.CurrentState as GameInventoryState).CurrentB_Slot_Item);
				}


				if (HasBeenPressed(Keys.I))
				{

					myGame.ChangeState(1);
					inventoryOpen = false;
				}
									
			}
			else if (myGame.CurrentState.IsGameState)
			{
				if (HasBeenPressed(Keys.I))
				{
						myGame.ChangeState(2);
						inventoryOpen = true;
				}
				if (HasBeenPressed(Keys.P))
				{
					levelManager.Player1.Inventory.RupeeCount += 10;
					levelManager.Player1.Inventory.BombCount += 10;
					levelManager.Player1.Inventory.Boomerang = true;
					levelManager.Player1.Inventory.KeyCount += 10;
					levelManager.Player1.Inventory.Bow = true;

				}
				if (HasBeenPressed(Keys.O)) 
				{
					Console.WriteLine(levelManager.currentRoomNum);
				}
				if (kstate.IsKeyDown(Keys.W))
				{
					levelManager.Player1.ChangeDirection(Player.Directions.Up);
				}
				else if (kstate.IsKeyDown(Keys.A))
				{
					levelManager.Player1.ChangeDirection(Player.Directions.Left);
				}
				else if (kstate.IsKeyDown(Keys.S))
				{
					levelManager.Player1.ChangeDirection(Player.Directions.Down);
				}
				else if (kstate.IsKeyDown(Keys.D))
				{
					levelManager.Player1.ChangeDirection(Player.Directions.Right);
				}
				else if (AllMovementKeysUp())
				{
					levelManager.Player1.ChangeDirection(Player.Directions.Idle);
				}
				if (HasBeenPressed(Keys.Z))
				{
					SoundManager.Instance.Play(SoundManager.Sound.SwordSlash);
					levelManager.Player1.Attack();

				}

				if (myGame.TwoPlayer == true)
				{
					if (kstate.IsKeyDown(Keys.Up))
					{
						levelManager.Player2.ChangeDirection(Player.Directions.Up);
					}
					else if (kstate.IsKeyDown(Keys.Left))
					{
						levelManager.Player2.ChangeDirection(Player.Directions.Left);
					}
					else if (kstate.IsKeyDown(Keys.Down))
					{
						levelManager.Player2.ChangeDirection(Player.Directions.Down);
					}
					else if (kstate.IsKeyDown(Keys.Right))
					{
						levelManager.Player2.ChangeDirection(Player.Directions.Right);
					}
					else if (AllMovementKeysUp())
					{
						levelManager.Player2.ChangeDirection(Player.Directions.Idle);
					}

					if (HasBeenPressed(Keys.N))
					{
						SoundManager.Instance.Play(SoundManager.Sound.SwordSlash);
						levelManager.Player2.Attack();

					}
				}



				if (HasBeenPressed(Keys.V))
				{
					levelManager.Player1.UseItem();
				}
				
				if (myGame.TwoPlayer == true)
				{
					if (HasBeenPressed(Keys.M))
					{
						levelManager.Player2.UseItem();
					}
				}
			}
			else if (myGame.CurrentState.IsGameOver)
			{
				if (HasBeenPressed(Keys.E))
				{
					myGame.Exit();
				}
				else if (HasBeenPressed(Keys.R))
				{
					myGame.reset();
				}
			}
			else if (myGame.CurrentState.IsVictory)
			{
				if (HasBeenPressed(Keys.E))
				{
					myGame.Exit();
				}
				else if (HasBeenPressed(Keys.R))
				{
					myGame.reset();
				}
			}

		}

		
	}
}