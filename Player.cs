using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
	public Player(Texture2D texture, SpriteBatch batch)
	{
		_state = new PlayerRightIdle(this);
		_spriteBatch = batch;
		this.texture = texture;
		position = new Vector2(100, 200);
		speed = 3;
		attackFrames = 30;
		damaged = false;
		scale = 0.38f;
	}

	public void ChangeDirection() {
		_state.ChangeDirection();
	}

	public void Update() {
		_state.Update();
	}

	public void Attack() {
		//TODO: make attack happen for a set amount of time after a button press
		_state.Attack();	
	}

	public void DamageLink() {
		damaged = true;
	}

	public void Move(int x, int y) {
		//x and y are directional vectors and should only be 0, 1, or -1
		position.X += x * speed;
		position.Y += y * speed;
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
	}

	public IState State {
		get { return _state; }
		set { _state = value; }
	} 
	
	public int AttackFrames { get { return attackFrames; } set { attackFrames = value; } }

}
