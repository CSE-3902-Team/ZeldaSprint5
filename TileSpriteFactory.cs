using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0
{
	public class TileSpriteFactory
	{
		private Texture2D tileSheet;
		private SpriteBatch batch;
		private Vector2 position;

		private static TileSpriteFactory instance = new TileSpriteFactory();

		public static TileSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private TileSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			tileSheet = content.Load<Texture2D>("Sprint 2 Tiles");
			
		}

		public ITile CreateTileSprite()
		{ 
			return new TileSprite(tileSheet, batch, position);
		}

	}
}
