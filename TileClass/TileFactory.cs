using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0.TileClass
{
	public class TileFactory
	{

		private Texture2D bricksTexture;
		private Texture2D sandTileTexture;
		private Texture2D silverLinesTexture;
		private Texture2D solidBlackTileTexture;
		private Texture2D solidBlueTileTexture;
		private Texture2D solidNavyTileTexture;
		private Texture2D stairsTexture;
		private Texture2D statue1Texture;
		private Texture2D statue2Texture;
		private Texture2D tileWithSquareTexture;
		private Texture2D leftFireTexture;
		private Texture2D rightFireTexture;
		private Texture2D textTexture;
		private Texture2D roomWallsTexture;
		private const int BOUNDARY_THICKNESS = 128;
		private const int HORZONTAL_BOUNDARY_LENGTH = 320;
		private const int VERTICAL_BOUNDARY_LENGTH = 160;

		private SpriteBatch batch;

		private static Dictionary<string, TileFactory.Tile> dict = new Dictionary<string, TileFactory.Tile>() {
			{"bricks", Tile.BrickTile},
			{"sandtile", Tile.SandTile},
			{"silverlines", Tile.SilverLinesTile},
			{"solid black tile", Tile.SolidBlackTile},
			{"solid blue tile", Tile.SolidBlueTile},
			{"solid navy tile", Tile.SolidNavyTile},
			{"stairs", Tile.StairsTile},
			{"statue1", Tile.StatueTile1},
			{"statue2", Tile.StatueTile2},
			{"tile with square in middle", Tile.tileWithSquare},
			{"LeftFire", Tile.LeftFire},
			{"RightFire", Tile.RightFire},
			{"textsprite", Tile.Text},
			{"roomwalls", Tile.Walls},
			{"leftWallTop", Tile.LeftWallTop },
			{"leftWallBot", Tile.LeftWallBot },
			{"topWallLeft", Tile.TopWallLeft },
			{"topWallRight", Tile.TopWallRight },
			{"rightWallTop", Tile.RightWallTop },
			{"rightWallBottom", Tile.RightWallBottom },
			{"botWallLeft", Tile.BotWallLeft },
			{"botWallRight", Tile.BotWallRight },
			{"pushable square", Tile.PushableSquare },
			{"pressure plate", Tile.PressurePlate}

		};

		public enum Tile
		{
			BrickTile = 0,
			SandTile = 1,
			SilverLinesTile = 2,
			SolidBlackTile = 3,
			SolidBlueTile = 4,
			SolidNavyTile = 5,
			StairsTile = 6,
			StatueTile1 = 7,
			StatueTile2 = 8,
			tileWithSquare = 9,
			LeftFire = 10,
			RightFire = 11,
			Text = 12,
			Walls = 13,
			TopWallLeft = 14,
			TopWallRight = 15,
			RightWallTop = 16,
			RightWallBottom = 17,
			BotWallLeft = 18,
			BotWallRight = 19,
			LeftWallTop = 20,
			LeftWallBot = 21,
			PushableSquare = 22,
			PressurePlate = 23
		}

		private static TileFactory instance = new TileFactory();

		public void setBatch(SpriteBatch aBatch)
		{
			batch = aBatch;
		}

		public static TileFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private TileFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			bricksTexture = content.Load<Texture2D>("bricks");
			sandTileTexture = content.Load<Texture2D>("sandtile");
			silverLinesTexture = content.Load<Texture2D>("silverlines");
			solidBlackTileTexture = content.Load<Texture2D>("solid black tile");
			solidBlueTileTexture = content.Load<Texture2D>("solid blue tile");
			solidNavyTileTexture = content.Load<Texture2D>("solid navy tile");
			stairsTexture = content.Load<Texture2D>("stairs");
			statue1Texture = content.Load<Texture2D>("statue1");
			statue2Texture = content.Load<Texture2D>("statue2");
			tileWithSquareTexture = content.Load<Texture2D>("tile with square in middle");
			leftFireTexture = content.Load<Texture2D>("LeftFire");
			rightFireTexture = content.Load<Texture2D>("RightFire");
			textTexture = content.Load<Texture2D>("textsprite");
			roomWallsTexture = content.Load<Texture2D>("roomwalls");

		}

		public TileFactory.Tile GetTile(string key)
		{
			Tile result;
			if (dict.TryGetValue(key, out result))
			{
				return result;
			}
			throw new ArgumentException(key + " is not in dictionary");
		}

		public bool IsTile(string key) 
		{
			return dict.ContainsKey(key);
		}

		public ITile CreateTileSprite(Tile tileNum, Vector2 pos)
		{
			switch (tileNum)
			{
				case Tile.BrickTile:
					return new BrickTile(bricksTexture, batch, pos);
				case Tile.SandTile:
					return new SandTile(sandTileTexture, batch, pos);
				case Tile.SilverLinesTile:
					return new SilverLinesTile(silverLinesTexture, batch, pos);
				case Tile.SolidBlackTile:
					return new SolidBlackTile(solidBlackTileTexture, batch, pos);
				case Tile.SolidBlueTile:
					return new SolidBlueTile(solidBlueTileTexture, batch, pos);
				case Tile.SolidNavyTile:
					return new SolidNavyTile(solidNavyTileTexture, batch, pos);
				case Tile.StairsTile:
					return new StairsTile(stairsTexture, batch, pos);
				case Tile.StatueTile1:
					return new StatueTile1(statue1Texture, batch, pos);
				case Tile.StatueTile2:
					return new StatueTile2(statue2Texture, batch, pos);
				case Tile.tileWithSquare:
					return new StatueTile2(tileWithSquareTexture, batch, pos);
				case Tile.LeftFire:
					return new LeftFire(leftFireTexture, batch, pos);
				case Tile.RightFire:
					return new RightFire(rightFireTexture, batch, pos);
				case Tile.Text:
					return new Text(textTexture, batch, pos);
				case Tile.Walls:
					return new RoomWalls(roomWallsTexture, batch, pos);
				case Tile.TopWallLeft:
					return new WallCollisionBox(new Rectangle((int)pos.X,(int) pos.Y, HORZONTAL_BOUNDARY_LENGTH, BOUNDARY_THICKNESS));
				case Tile.TopWallRight:
					return new WallCollisionBox(new Rectangle((int)pos.X, (int)pos.Y, HORZONTAL_BOUNDARY_LENGTH, BOUNDARY_THICKNESS));
				case Tile.BotWallLeft:
					return new WallCollisionBox(new Rectangle((int)pos.X, (int)pos.Y, HORZONTAL_BOUNDARY_LENGTH, BOUNDARY_THICKNESS));
				case Tile.BotWallRight:
					return new WallCollisionBox(new Rectangle((int)pos.X, (int)pos.Y, HORZONTAL_BOUNDARY_LENGTH, BOUNDARY_THICKNESS));
				case Tile.RightWallTop:
					return new WallCollisionBox(new Rectangle((int)pos.X, (int)pos.Y, BOUNDARY_THICKNESS, VERTICAL_BOUNDARY_LENGTH));
				case Tile.RightWallBottom:
					return new WallCollisionBox(new Rectangle((int)pos.X, (int)pos.Y, BOUNDARY_THICKNESS, VERTICAL_BOUNDARY_LENGTH));
				case Tile.LeftWallTop:
					return new WallCollisionBox(new Rectangle((int)pos.X, (int)pos.Y, BOUNDARY_THICKNESS, VERTICAL_BOUNDARY_LENGTH));
				case Tile.LeftWallBot:
					return new WallCollisionBox(new Rectangle((int)pos.X, (int)pos.Y, BOUNDARY_THICKNESS, VERTICAL_BOUNDARY_LENGTH));
				case Tile.PushableSquare:
					return new PushableTile(tileWithSquareTexture, batch, pos);
				case Tile.PressurePlate:
					return new PressurePlate(silverLinesTexture, batch, pos);
				default:
					return new BrickTile(bricksTexture, batch, pos);
			}
		}

	}
}