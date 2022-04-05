using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace Sprint0.DoorClass
{
	public class DoorClosed : ADoor
	{
		private static int spriteColumn = 3;

		public DoorClosed(Texture2D tileSheet, SpriteBatch batch, DoorFactory.Side side, int roomConnection) : base(tileSheet, batch, spriteColumn, side, roomConnection)
		{

		}
	}
}