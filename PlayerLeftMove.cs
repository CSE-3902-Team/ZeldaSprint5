using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
public class PlayerLeftMove : IState 
{
	private Player player;
	private int moveFrame;

	public PlayerLeftMove(Player instance)
	{
		player = instance;
		moveFrame = 1;
	}

	public void ChangeDirection() {
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.W) || kstate.IsKeyDown(Keys.Up))
		{
			player.State = new PlayerUpMove(player);
		}
		else if (kstate.IsKeyDown(Keys.D) || kstate.IsKeyDown(Keys.Right))
		{
			player.State = new PlayerRightMove(player);
		}
		else if (kstate.IsKeyDown(Keys.S) || kstate.IsKeyDown(Keys.Down))
		{
			player.State = new PlayerDownMove(player);
		}
		else if(kstate.IsKeyUp(Keys.A) && kstate.IsKeyUp(Keys.Left)) { 
			player.State = new PlayerLeftIdle(player);
		}
	}

	public void Update() {
		//update the sprite
		player.Move(-1, 0);
		if (moveFrame <= 15)
		{
			player.Draw(new Rectangle(1075,1714,129,139));
		}
		else {
			player.Draw(new Rectangle(1219,1704,138,149));
		}
		moveFrame++;
		if (moveFrame > 30) {
			moveFrame = 1;
		}
	}

	public void Attack() {
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.N) || kstate.IsKeyDown(Keys.Z)) { 
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
