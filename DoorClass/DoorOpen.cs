using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace Sprint0.DoorClass
{
	public class DoorOpen : ADoor
	{
		private static int spriteColumn = 1;

		public DoorOpen(Texture2D tileSheet, SpriteBatch batch, DoorFactory.Side side) : base(tileSheet, batch, spriteColumn, side)
		{

		}
	}
}