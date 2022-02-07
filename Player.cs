using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
public class Player 
{
	private IMoveState moveState;
	private Texture2D texture;
	private Rectangle srcRect;
	private Vector2 position;
	private float speed;
	public Player(Texture2D texture)
	{
		moveState = new PlayerRight(this);
		this.texture = texture;
	}

	public void ChangeDirection() {
		moveState.ChangeDirection();
	}

	public void Update() {
		moveState.Update();
	}

	public void Attack() {
		moveState.Attack();	
	}

	public void Move(int x, int y) {
		//x and y are directional vectors and should only be 0, 1, or -1
		position.X += x * speed;
		position.Y += y * speed;
	}

	publ

	public IMoveState MoveState {
		get { return moveState; }
		set { moveState = value; }
	} 

}
