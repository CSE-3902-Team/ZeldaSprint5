using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace Sprint0.ItemClass
{
	public class ItemCompass : AItem
	{
		private static int spritePos = 0;

		public ItemCompass(Texture2D tileSheet, SpriteBatch batch, Vector2 position) : base(tileSheet, batch, position, spritePos)
		{

		}
	}
}