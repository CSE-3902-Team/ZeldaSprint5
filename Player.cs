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
		public const float MOVE_SPEED = 5;
		public const float ATTACK_KNOCKBACK_SPEED = 20;
	public const int KNOCKBACK_FRAMES = 10;
		public Rectangle SourceRectangle { get { return src; } set { src = value; } }
		public float Speed { get { return speed; } set { speed = value; } }
		public Vector2 DrawOffset {get { return drawOffset; } set { drawOffset = value; } }
		public int AttackFrames { get { return attackFrames; } set { attackFrames = value; } }
		public Vector2 Position { 
			get 
			{ 
				return position; 
			} 
			set 
			{ 
				position = value;
                UpdateCollisionBox();
            }
		}

		public Texture2D colT;
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
		public Player(Texture2D texture, SpriteBatch batch, IProjectile projectile, Vector2 p,Texture2D colT)
		{
			_state = new PlayerRightIdle(this);
			_spriteBatch = batch;
			this.texture = texture;
			position = p;
			speed = MOVE_SPEED;
			attackFrames = 15;
			damaged = false;
			scale = 0.35f;
			projectiles = new Queue<IProjectile>();
            topLeft = new TopLeft((int)(position.X - (src.Width * scale)/2), (int)((position.Y - (src.Height * scale)/2)), this);
            bottomRight = new BottomRight(((int)(position.X+(src.Width * scale)/2)), (int)((position.Y+(src.Height * scale)/2)), this);
			this.colT = colT;
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
			UpdateCollisionBox();
		}

		public void Attack()
		{
			_state.Attack();
		}

		public void DamageLink(Player.Directions dir)
		{
			
				_state.DamageLink(dir);
			
			damaged = true;
			
		}

		public void UseItem(IProjectile proj)
		{
			_state.UseItem(proj);

		}

		private void UpdateCollisionBox() {
            topLeft.X = (int)(position.X - (src.Width * scale) / 2);
            topLeft.Y = (int)((position.Y - (src.Height * scale) / 2));
            bottomRight.X = (int)(position.X + (src.Width * scale) / 2);
            bottomRight.Y = (int)((position.Y + (src.Height * scale) / 2));
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
		Rectangle CollisionRect = new Rectangle(TopLeft.X, topLeft.Y, BottomRight.X - TopLeft.X, bottomRight.Y - topLeft.Y);
		Rectangle CollisionRectTL = new Rectangle(TopLeft.X, topLeft.Y,20,20);
		Rectangle CollisionRectBR = new Rectangle(BottomRight.X-20, BottomRight.Y-20,20,20);
		Rectangle CollisionSrc = new Rectangle(src.X + 22, src.Y + 22, 15, 15);
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
			//_spriteBatch.Draw(texture, destRect, src, col,0f, new Vector2(0,0) , SpriteEffects.None, 0f);
			_spriteBatch.Draw(colT, CollisionRectTL, new Rectangle(0, 0, 64, 64), col,0f, new Vector2(0,0), SpriteEffects.None, 0f);
			_spriteBatch.Draw(colT, CollisionRectBR, new Rectangle(0, 0, 64, 64), col,0f, new Vector2(0,0), SpriteEffects.None, 0f);
			_spriteBatch.End();

			DrawItems();
		}





	}
