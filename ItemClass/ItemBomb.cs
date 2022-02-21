using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace Sprint0.ItemClass
{
	public class ItemBomb : AItem
	{
		private static int spritePos = 10;

		public ItemBomb(Texture2D tileSheet, SpriteBatch batch, Vector2 position) : base(tileSheet, batch, position, spritePos)
		{

		}
	}
}