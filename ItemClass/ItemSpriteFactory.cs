using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace Sprint0.ItemClass
{
	public class ItemSpriteFactory
	{
		private Texture2D itemSheet;
		private SpriteBatch batch;
		private Vector2 position;
		private int currentItem;

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
			Clock				= 12
		}

		private static ItemSpriteFactory instance = new ItemSpriteFactory();

		public void setBatchPosition(SpriteBatch aBatch, Vector2 aPosition) {
			batch = aBatch;
			position = aPosition;
		}

		public static ItemSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private ItemSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			itemSheet = content.Load<Texture2D>("sprint-2-items");

		}

		public AItem nextItem() {
			if (currentItem < Enum.GetValues(typeof(Item)).Cast<int>().Max())
			{
				currentItem++;
			}
			else 
			{
				currentItem = 0;
			}
			return CreateItemSprite((Item)currentItem);
		}

		public AItem previousItem()
		{
			if (currentItem > 0)
			{
				currentItem--;
			}
			else
			{
				currentItem = Enum.GetValues(typeof(Item)).Cast<int>().Max();
			}
			return CreateItemSprite((Item)currentItem);
		}

		public AItem CreateItemSprite(Item itemNum)
		{
			currentItem = (int)itemNum;
			switch ((Item)currentItem)
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
				default:
					return new ItemCompass(itemSheet, batch, position);
			}
		}

	}
}
