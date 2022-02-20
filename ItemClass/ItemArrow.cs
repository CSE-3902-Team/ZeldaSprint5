using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace Sprint0.ItemClass
{
	public class ItemArrow : AItem
	{
		private static int spritePos = 9;

		public ItemArrow(Texture2D tileSheet, SpriteBatch batch, Vector2 position) : base(tileSheet, batch, position, spritePos)
		{

		}
	}
}