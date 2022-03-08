using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
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

		private SpriteBatch batch;
		private Vector2 position;
		private Player _player;

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
			LeftFire = 9,
			RightFire = 10,
			Text = 11

		}

		private static TileFactory instance = new TileFactory();

		public void initialize(SpriteBatch aBatch, Player player)
		{
			batch = aBatch;
			_player = player;
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
	}

		public ITile CreateItemSprite(Tile itemNum, Vector2 pos)
		{
			position = pos;

			switch (itemNum)
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
				case Tile.LeftFire:
					return new LeftFire(leftFireTexture, batch, pos);
				case Tile.RightFire:
					return new RightFire(rightFireTexture, batch, pos);
				case Tile.Text:
					return new Text(textTexture, batch, pos);
				default:
					return new BrickTile(bricksTexture, batch, pos);
			}
		}

	}
}