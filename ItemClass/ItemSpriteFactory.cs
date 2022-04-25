using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint0.ItemClass
{
	public class ItemSpriteFactory
	{
		private Texture2D itemSheet;
		private SpriteBatch batch;
		private Vector2 position;

		public static Dictionary<string, Item> dict = new Dictionary<string, Item>() {
			{"compass", Item.Compass},
			{"map", Item.Map},
			{"key", Item.Key},
			{"heartContainer", Item.HeartContainer},
			{"triforcePiece", Item.TriforcePiece},
			{"woodenBoomerang", Item.WoodenBoomerang},
			{"bow", Item.Bow},
			{"heart", Item.Heart},
			{"rupee", Item.Rupee},
			{"arrow", Item.SpecialArrow},
			{"bomb", Item.Bomb},
			{"fairy", Item.Fairy},
			{"clock", Item.Clock},
			{"special", Item.SpecialBoomerang },
		};

		public enum Item{
			Compass				= 0,
			Map					= 1,
			Key					= 2,
			HeartContainer		= 3,
			TriforcePiece		= 4,
			WoodenBoomerang		= 5,
			Bow					= 6,
			Heart				= 7,
			Rupee				= 8,
			Arrow				= 9,
			Bomb				= 10,
			Fairy				= 11,
			Clock				= 12,
			SpecialBoomerang	= 13,
			SpecialArrow		= 14
		}

		private static ItemSpriteFactory instance = new ItemSpriteFactory();

		public void setBatch(SpriteBatch aBatch) {
			batch = aBatch;
		}

		public static ItemSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		public ItemSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			itemSheet = content.Load<Texture2D>("sprint-5-items");

		}

		public ItemSpriteFactory.Item GetItem(string key)
		{
			Item result;
			if (dict.TryGetValue(key, out result))
			{
				return result;
			}
			throw new ArgumentException(key + " is not in dictionary");
		}

		public AItem CreateItemSprite(Item itemNum, Vector2 pos)
		{
		
			position = pos;
			switch (itemNum)
            {
				case Item.Compass:
					return new ItemCompass(itemSheet, batch, position);
				case Item.Map:
					return new ItemMap(itemSheet, batch, position);
				case Item.Key:
					return new ItemKey(itemSheet, batch, position);
				case Item.HeartContainer:
					return new ItemHeartContainer(itemSheet, batch, position);
				case Item.TriforcePiece:
					return new ItemTriforcePiece(itemSheet, batch, position);
				case Item.WoodenBoomerang:
					return new ItemWoodenBoomerang(itemSheet, batch, position);
				case Item.Bow:
					return new ItemBow(itemSheet, batch, position);
				case Item.Heart:
					return new ItemHeart(itemSheet, batch, position);
				case Item.Rupee:
					return new ItemRupee(itemSheet, batch, position);
				case Item.Arrow:
					return new ItemArrow(itemSheet, batch, position);
				case Item.Bomb:
					return new ItemBomb(itemSheet, batch, position);
				case Item.Fairy:
					return new ItemFairy(itemSheet, batch, position);
				case Item.Clock:
					return new ItemClock(itemSheet, batch, position);
				case Item.SpecialBoomerang:
					return new ItemSpecialBoomerang(itemSheet, batch, position);
				case Item.SpecialArrow:
					return new ItemSpecialArrow(itemSheet, batch, position);
				default:
					return new ItemCompass(itemSheet, batch, position);
			}
		}

	}
}
