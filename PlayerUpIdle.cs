using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
public class PlayerUpIdle : IState 
{
	private Player player;

	public PlayerUpIdle(Player instance)
	{
		player = instance;
	}

	public void ChangeDirection() {
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.W) || kstate.IsKeyDown(Keys.Up))
		{
			player.State = new PlayerUpMove(player);
		}
		else if (kstate.IsKeyDown(Keys.A)|| kstate.IsKeyDown(Keys.Left))
		{
			player.State = new PlayerLeftMove(player);
		}
		else if (kstate.IsKeyDown(Keys.S)|| kstate.IsKeyDown(Keys.Down))
		{
			player.State = new PlayerDownMove(player);
		}
		else if (kstate.IsKeyDown(Keys.D)|| kstate.IsKeyDown(Keys.Right)) { 
			player.State = new PlayerRightMove(player);
		}
	}

	public void Update() {
		//update the sprite
		player.Draw(new Rectangle(637,93,113,161));

	}

	public void Attack() {
		//Input checking was done in controller
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.N) || kstate.IsKeyDown(Keys.Z))
		{
			player.State = new PlayerUpAttack(player);
		}

	}
	public void UseItem(IProjectile proj)
	{
		proj.Direction = new Vector2(0, -1);
		proj.Position = new Vector2(player.Position.X, player.Position.Y - 40);
		player.Projectiles.Enqueue(proj);
		player.State = new PlayerUpUseItem(player);
	}	

}

