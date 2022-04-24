using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace Sprint0.DoorClass
{
	public class DoorInvisible : ADoor
	{
		private static int spriteColumn = 1;

		public DoorInvisible(Texture2D tileSheet, SpriteBatch batch, DoorFactory.Side side, int roomConnection) : base(tileSheet, batch, spriteColumn, side, roomConnection)
		{

		}

		public new void draw() {
		
		}

		public new void draw(int xOffset, int yOffset) {
		
		}
	}
}