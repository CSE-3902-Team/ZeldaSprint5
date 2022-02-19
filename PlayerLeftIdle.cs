using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
public class PlayerLeftIdle : IState 
{
	private Player player;

	public PlayerLeftIdle(Player instance)
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
		player.Draw(new Rectangle(1075,1714,129,139));

	}

	public void Attack() {
		//Input checking was done in controller
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.N) || kstate.IsKeyDown(Keys.Z))
		{
			player.State = new PlayerLeftAttack(player);
		}

	}

	public void UseItem(IProjectile proj)
	{
		proj.Direction = new Vector2(-1, 0);
		proj.Position = new Vector2(player.Position.X - 40, player.Position.Y);
		player.Projectiles.Enqueue(proj);
		player.State = new PlayerLeftUseItem(player);
	}
}
