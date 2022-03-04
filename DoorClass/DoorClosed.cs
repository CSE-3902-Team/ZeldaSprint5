using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace Sprint0.DoorClass
{
	public class DoorClosed : ADoor
	{
		private static int spriteColumn = 3;

		public DoorClosed(Texture2D tileSheet, SpriteBatch batch, Vector2 position, int side) : base(tileSheet, batch, position, spriteColumn, side)
		{

		}
	}
}