using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
public class Player 
{
	private IState _state;
	private Texture2D texture;
	private Vector2 position;
	private float speed;
	private SpriteBatch _spriteBatch;
	public Player(Texture2D texture, SpriteBatch batch)
	{
		_state = new PlayerRightIdle(this);
		_spriteBatch = batch;
		this.texture = texture;
		position = new Vector2(100, 100);
		speed = 3;
	}

	public void ChangeDirection() {
		_state.ChangeDirection();
	}

	public void Update() {
		_state.Update();
	}

	public void Attack() {
		_state.Attack();	
	}

	public void Move(int x, int y) {
		//x and y are directional vectors and should only be 0, 1, or -1
		position.X += x * speed;
		position.Y += y * speed;
		Console.WriteLine("Position = " + position.X);
	}

	public void Draw(Rectangle src) {
		//TODO: implement draw in every state instead. This allows animations and deal situations where the width of src is huge
        Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, src.Width*6, src.Height*6);
		_spriteBatch.Begin();
		_spriteBatch.Draw(texture, destRect, src, Color.White, 0f, new Vector2(src.Width / 2, src.Height / 2), SpriteEffects.None, 0f);
		_spriteBatch.End();
	}

	public IState State {
		get { return _state; }
		set { _state = value; }
	} 

}
