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

	public void ChangeDirection(Player.Directions dir)
	{
		if (dir == Player.Directions.Up)
		{
			player.State = new PlayerUpMove(player);
		}
		else if (dir == Player.Directions.Left)
		{
			player.State = new PlayerLeftMove(player);
		}
		else if (dir == Player.Directions.Down)
		{
			player.State = new PlayerDownMove(player);
		}
		else if (dir == Player.Directions.Right)
		{
			player.State = new PlayerRightMove(player);
		}
	}

	public void Update() {
		player.Draw(new Rectangle(1219,1704,138,149), 0, 0, Color.White);
	}

	public void Attack() {
        player.State = new PlayerLeftAttack(player);

	}

	public void UseItem(IProjectile proj)
	{
		proj.Direction = new Vector2(-1, 0);
		proj.Position = new Vector2(player.Position.X - 40, player.Position.Y);
		player.Projectiles.Enqueue(proj);
		player.State = new PlayerLeftUseItem(player);
	}
}
