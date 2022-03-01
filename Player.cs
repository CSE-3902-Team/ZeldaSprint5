using System;
using Microsoft.Xna.Framework;
using Sprint0.PlayerClass;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Sprint0;

	public class Player : IBoxCollider
	{
		private IState _state;
		private Texture2D texture;
		private Vector2 position;
		private float speed;
		private int attackFrames;
		private Rectangle src;
        private Vector2 drawOffset;
		private float scale;
		private SpriteBatch _spriteBatch;
		private bool damaged;
		private Queue<IProjectile> projectiles;
        private readonly TopLeft topLeft;
        private readonly BottomRight bottomRight;
		public Rectangle SourceRectangle { get { return src; } set { src = value; } }
		public Vector2 DrawOffset {get { return drawOffset; } set { drawOffset = value; } }
		public int AttackFrames { get { return attackFrames; } set { attackFrames = value; } }
		public Vector2 Position { get { return position; } }
		public TopLeft TopLeft 
		{ 
			get { return topLeft; }
		}
        public BottomRight BottomRight 
        {
            get { return bottomRight; }
        }
	public Queue<IProjectile> Projectiles { get { return projectiles; } }
		public IState State
		{
			get { return _state; }
			set { _state = value; }
		}
		public enum Directions
		{
			Up,
			Down,
			Left,
			Right,
			Idle,
		}
		public Player(Texture2D texture, SpriteBatch batch, IProjectile projectile, Vector2 p)
		{
			_state = new PlayerRightIdle(this);
			_spriteBatch = batch;
			this.texture = texture;
			position = p;
			speed = 5;
			attackFrames = 15;
			damaged = false;
			scale = 0.41f;
			projectiles = new Queue<IProjectile>();
            topLeft = new TopLeft((int)position.X, (int)position.Y);
            bottomRight = new BottomRight((int)(position.X+(src.Width * scale)), (int)(position.Y+(src.Height * scale)));
		}

		public void ChangeDirection(Directions dir)
		{
			//Checks movement state transitions
			_state.ChangeDirection(dir);
		}

		public void Update()
		{
			//Updates relevant variables in player class, calls draw in player
			_state.Update();
		topLeft.X = (int)position.X;
		topLeft.Y = (int)position.Y;
		bottomRight.X = (int)(position.X + (src.Width * scale)); 
		bottomRight.Y = (int)(position.Y + (src.Height * scale));
	}

		public void Attack()
		{
			_state.Attack();
		}

		public void DamageLink()
		{
			damaged = true;
		}

		public void UseItem(IProjectile proj)
		{
			_state.UseItem(proj);

		}

		private void updateCollisionBox() {
			//collisionBox = new Rectangle(position.X,position.Y,)
		}
		public void Move(int x, int y)
		{
			//x and y are directional vectors and should only be 0, 1, or -1
			position.X += x * speed;
			position.Y += y * speed;
		}

		public void DrawItems()
		{
			int size = projectiles.Count;
			for (int x = 0; x < size; x++)
			{
				IProjectile projectile = projectiles.Dequeue();
				if (projectile.IsRunning)
				{
					projectile.Update();
					projectile.Draw();
					projectiles.Enqueue(projectile);
				}
			}
		}


		public void Draw()
		{
            float xOffset = drawOffset.X;
            float yOffset = drawOffset.Y;
            Color col = Color.White;
			if (damaged)
			{
				col = Color.MediumVioletRed;
			}
			Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, (int)(src.Width * scale), (int)(src.Height * scale));
			_spriteBatch.Begin();
			_spriteBatch.Draw(texture, destRect, src, col, 0f, new Vector2(src.Width / 2 - xOffset, src.Height / 2 - yOffset), SpriteEffects.None, 0f);
			_spriteBatch.End();
			DrawItems();
		}





	}
