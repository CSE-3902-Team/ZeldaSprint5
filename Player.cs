using System;
using Microsoft.Xna.Framework;
using Sprint0;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
public class Player 
{
	private IState _state;
	private Texture2D texture;
	private Vector2 position;
	private float speed;
	private int attackFrames;
	private float scale;
	private SpriteBatch _spriteBatch;
	bool damaged;
	Queue<IProjectile> projectiles;
	public int AttackFrames { get { return attackFrames; } set { attackFrames = value; } }
	public Vector2 Position { get { return position; } }
	public Queue<IProjectile> Projectiles { get { return projectiles; } }
	public Player(Texture2D texture, SpriteBatch batch, IProjectile projectile)
	{
		_state = new PlayerRightIdle(this);
		_spriteBatch = batch;
		this.texture = texture;
		position = new Vector2(100, 200);
		speed = 5;
		attackFrames = 15;
		damaged = false;
		scale = 0.38f;
		projectiles = new Queue<IProjectile>();
	}

	public void ChangeDirection() {
		//Checks movement state transitions
		_state.ChangeDirection();
	}

	public void Update() {
		//Calls the draw method in player class, moves if neccessary
		_state.Update();
	}

	public void Attack() {
		//Makes player attack
		_state.Attack();	
	}

	public void DamageLink() {
		damaged = true;
	}

	public void UseItem(IProjectile proj) {
		_state.UseItem(proj);
				
	}

	public void Move(int x, int y) {
		//x and y are directional vectors and should only be 0, 1, or -1
		position.X += x * speed;
		position.Y += y * speed;
	}

	public void DrawItems() {
		Console.WriteLine(projectiles.ToString());
		int size = projectiles.Count;
		for (int x = 0; x < size; x++)
		{
			IProjectile projectile = projectiles.Dequeue();
			if (projectile.IsRunning) {
				Console.WriteLine("If entered");
				projectile.Update();
				projectile.Draw();
				projectiles.Enqueue(projectile);
			}
		}
	}

	public void Draw(Rectangle src) {
		//generic draw method
		Color col = Color.White;
		if (damaged) {
			col = Color.MediumVioletRed;	
		}
        Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, (int)(src.Width*scale), (int)(src.Height*scale));
		_spriteBatch.Begin();
		_spriteBatch.Draw(texture, destRect, src, col, 0f, new Vector2(src.Width / 2, src.Height / 2), SpriteEffects.None, 0f);
		_spriteBatch.End();
		DrawItems();
	}
	public void Draw(Rectangle src, int xOffset, int yOffset, Color col) {
		//When link attacks with his sword his width is twice as big, we need to change center
		if (damaged) {
			col = Color.MediumVioletRed;	
		}
        Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, (int)(src.Width*scale), (int)(src.Height*scale));
		_spriteBatch.Begin();
		_spriteBatch.Draw(texture, destRect, src, col, 0f, new Vector2(src.Width / 2 -xOffset, src.Height / 2 -yOffset), SpriteEffects.None, 0f);
		_spriteBatch.End();
		DrawItems();
	}

	public IState State {
		get { return _state; }
		set { _state = value; }
	} 
	
	
	
}
