using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace Sprint0.ItemClass
{
	public class ItemMap : AItem
	{
		private static int spritePos = 1;

		public ItemMap(Texture2D tileSheet, SpriteBatch batch, Vector2 position) : base(tileSheet, batch, position, spritePos)
		{

		}
	}
}