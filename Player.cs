﻿using System;
using Microsoft.Xna.Framework;
using Sprint0.PlayerClass;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Sprint0.Command;
using Sprint0.LevelClass;
using Sprint0.Projectile;

namespace Sprint0 { 

	public class Player : IBoxCollider
	{
		private IPlayerState _state;
		private Texture2D texture;
		private Vector2 position;
		private float speed;
		private int attackFrames;
		private Rectangle src;
        private Vector2 drawOffset;
		private float scale;
		private SpriteBatch _spriteBatch;
        private readonly TopLeft topLeft;
        private readonly BottomRight bottomRight;
		private ProjectilePlayerSword swordProjectile;
		public const float MOVE_SPEED = 5;
		public const float ATTACK_KNOCKBACK_SPEED = 10;
		private Vector2 collisionOffsetX;
		private Vector2 collisionOffsetY;
		private Color col;
		public const int KNOCKBACK_FRAMES = 5;
		private int maxHp = 6;
		public int HPFRAMES = 1;
		private readonly ICommand addProjectileCommand;
		private int playerHp;
		private bool isDead;
		private bool hasTriforce = false;
		private LinkInventory inventory;
		private Vector2 projectilePosition;
		private Vector2 projectileDirection;


		public Vector2 ProjectilePosition
		{ 
			get { return projectilePosition; }
			set { projectilePosition = value; }
		}
		public Vector2 ProjectileDirection
		{
			get { return projectileDirection; }
			set { projectileDirection = value; }
		}
		public ProjectilePlayerSword SwordProjectile
		{
			get { return swordProjectile; }
			set { swordProjectile = value; }
		}
		public Vector2 CollisionOffsetX { get { return collisionOffsetX; } set { collisionOffsetX = value; } }
		public Vector2 CollisionOffsetY { get { return collisionOffsetY; } set { collisionOffsetY = value; } }
		public Rectangle SourceRectangle { get { return src; } set { src = value; } }
		public float Speed { get { return speed; } set { speed = value; } }
		public Vector2 DrawOffset {get { return drawOffset; } set { drawOffset = value; } }
		public int AttackFrames { get { return attackFrames; } set { attackFrames = value; } }
		public bool IsDead { get { return isDead; } set { isDead = value; } }
		public float Scale { get { return scale; } set { scale = value; } }
		public bool HasTriforce { get { return hasTriforce; } set { hasTriforce = value; } }
		
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
	

	public IPlayerState State
		{
			get { return _state; }
			set { _state = value; }
		}

	public int MaxHp
        {
			get { return maxHp; }
			set { maxHp = value; }
		}
	public int PlayerHp
		{
			get { return playerHp; }
			set 
			{
				playerHp = value > maxHp ? maxHp : value;

				if (playerHp > 1)
				{
					SoundManager.Instance.Stop(SoundManager.Sound.LowHp);

				}
				if (playerHp == 1)
				{
					SoundManager.Instance.Play(SoundManager.Sound.LowHp);
				}
				else if (playerHp == 0)
				{
					SoundManager.Instance.Stop(SoundManager.Sound.LowHp);
					SoundManager.Instance.Stop(SoundManager.Sound.BG_MUSIC);
					SoundManager.Instance.Play(SoundManager.Sound.GameOver);
					//Change to playerDeadState: isDead will be changed within the state.
					isDead = true;
				}
			}
		}

	public LinkInventory Inventory
        {
            get { return inventory; }
        }
	public Color Col
    {
		get { return col; }
		set { col = value; }
	}
		public enum Directions
		{
			Up,
			Down,
			Left,
			Right,
			Idle,
		}

		public ICommand AddProjectileCommand
		{
			get { return addProjectileCommand; }
		}
		public Player(Texture2D texture, SpriteBatch batch, IProjectile projectile, Vector2 p,Texture2D colT, ICommand c)
		{
			_state = new PlayerUpIdle(this);
			_spriteBatch = batch;
			this.texture = texture;
			position = p;
			speed = MOVE_SPEED;
			attackFrames = 18;
			scale = 0.35f;
            topLeft = new TopLeft((int)(position.X - (src.Width * scale)/2), (int)((position.Y - (src.Height * scale)/2)), this);
            bottomRight = new BottomRight(((int)(position.X+(src.Width * scale)/2)), (int)((position.Y+(src.Height * scale)/2)), this);
			this.colT = colT;
			col = Color.White;
			addProjectileCommand = c;
			collisionOffsetX = new Vector2(0, 0);
			collisionOffsetY = new Vector2(0, 0);
			playerHp = maxHp;
			isDead = false;
			inventory = new LinkInventory(this);
		}

		public Player(Texture2D texture, SpriteBatch batch, IProjectile projectile, Vector2 p, Texture2D colT, ICommand c, LinkInventory i)
		{
			_state = new PlayerUpIdle(this);
			_spriteBatch = batch;
			this.texture = texture;
			position = p;
			speed = MOVE_SPEED;
			attackFrames = 18;
			scale = 0.35f;
			topLeft = new TopLeft((int)(position.X - (src.Width * scale) / 2), (int)((position.Y - (src.Height * scale) / 2)), this);
			bottomRight = new BottomRight(((int)(position.X + (src.Width * scale) / 2)), (int)((position.Y + (src.Height * scale) / 2)), this);
			this.colT = colT;
			col = Color.White;
			addProjectileCommand = c;
			collisionOffsetX = new Vector2(0, 0);
			collisionOffsetY = new Vector2(0, 0);
			playerHp = maxHp;
			isDead = false;
			inventory = i;
		}

		public void ChangeDirection(Directions dir)
		{
			//Checks movement state transitions
			_state.ChangeDirection(dir);
		}

		public void Update()
		{
			//Updates relevant variables in player class, calls draw in player
			if (playerHp == 0 && _state.GetType() != typeof(PlayerDead))
            {
				_state = new PlayerDead(this);
            }
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
		}

		public void UseItem()
		{
			ProjectileFactory.PNames projectile = MapItemToProjectile(inventory.Selected_Item);
			if (projectile == ProjectileFactory.PNames.None) { return; }
			if (projectile == ProjectileFactory.PNames.PBoomerang || projectile == ProjectileFactory.PNames.PSpecialBoomerang) 
			{
				_state.UseItem();
				LevelManager.Instance.ProjectileFactory.LauchPlayerBoomerang(projectile,this, projectilePosition, projectileDirection);
			}
			else
			{
				_state.UseItem();
				LevelManager.Instance.ProjectileFactory.LauchProjectile(projectile, projectilePosition, projectileDirection);
			}
		}

		private void UpdateCollisionBox() {

            topLeft.X = (int)(position.X - (src.Width * scale) / 2 + collisionOffsetX.X );
            topLeft.Y = (int)((position.Y - (src.Height * scale) / 2) + CollisionOffsetY.X);
            bottomRight.X = (int)(position.X  + (src.Width * scale) / 2 + collisionOffsetX.Y);
            bottomRight.Y = (int)((position.Y + (src.Height * scale) / 2) + CollisionOffsetY.Y);
		}
		public void Move(int x, int y)
		{
			//x and y are directional vectors and should only be 0, 1, or -1
			position.X += x * speed;
			position.Y += y * speed;
		}

		public void LinkLowHpColor() {
			if (State.GetType() == typeof(PlayerDead)) {
				col = Color.White;
			}
			if (playerHp == 1 && HPFRAMES <= 12)
			{
				col = Color.Red;
				HPFRAMES++;
			}
			else if (playerHp == 1 && HPFRAMES <= 24)
			{
				col = Color.White;
				HPFRAMES++;
			}
			else if (playerHp == 1 && HPFRAMES > 24)
			{
				HPFRAMES = 1;
				col = Color.White;
			}
			else if (playerHp > 1)
			{
				col = Color.White;
				HPFRAMES = 1;
			}
		}


		public void Draw() 
		{
			Draw(0, 0);
		}

		public void Draw(int xScrollOffset, int yScrollOffset)
		{
		Rectangle CollisionRect = new Rectangle(TopLeft.X, topLeft.Y, BottomRight.X - TopLeft.X, bottomRight.Y - topLeft.Y);
		Rectangle CollisionRectTL = new Rectangle(TopLeft.X, topLeft.Y,20,20);
		Rectangle CollisionRectBR = new Rectangle(BottomRight.X-20, BottomRight.Y-20,20,20);
		Rectangle CollisionSrc = new Rectangle(src.X + 22, src.Y + 22, 15, 15);
            float xOffset = drawOffset.X;
            float yOffset = drawOffset.Y;
			//Console.WriteLine(playerHp);



			LinkLowHpColor();
			Rectangle destRect = new Rectangle((int)position.X+xScrollOffset, (int)position.Y+yScrollOffset, (int)(src.Width * scale), (int)(src.Height * scale));
			_spriteBatch.Begin();
			_spriteBatch.Draw(texture, destRect, src, col, 0f, new Vector2(src.Width / 2 - xOffset +xScrollOffset, src.Height / 2 - yOffset + yScrollOffset), SpriteEffects.None, 0f);
			//_spriteBatch.Draw(colT, CollisionRectTL, new Rectangle(0, 0, 64, 64), col,0f, new Vector2(0,0), SpriteEffects.None, 0f);
			//_spriteBatch.Draw(colT, CollisionRectBR, new Rectangle(0, 0, 64, 64), col,0f, new Vector2(0,0), SpriteEffects.None, 0f);
			_spriteBatch.End();

		
		}

		public ProjectileFactory.PNames MapItemToProjectile(LinkInventory.Items item)
		{
			if (item == LinkInventory.Items.Boomerang && inventory.Boomerang) { return ProjectileFactory.PNames.PBoomerang; }
			if (item == LinkInventory.Items.Bomb && inventory.BombCount > 0) {
				inventory.BombCount--;
				return ProjectileFactory.PNames.PBomb; 
			}
			if (item == LinkInventory.Items.SpecialBoomerang && inventory.SpecialBoomerang) { return ProjectileFactory.PNames.PSpecialBoomerang; }
			if (item == LinkInventory.Items.BowAndArrow && inventory.RupeeCount > 0) 
			{
				inventory.RupeeCount--;
				if (inventory.SpecialArrowCount > 0) { return ProjectileFactory.PNames.PSpecialArrow; }
				else { return ProjectileFactory.PNames.PNormalArrow; }
			}
			else 
			{
				return ProjectileFactory.PNames.None;
			}
		}


	}
}
