using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace Sprint0.DoorClass
{
	public class WeakWall : ADoor
	{
		private static int spriteColumn = 0;

		public WeakWall(Texture2D tileSheet, SpriteBatch batch, DoorFactory.Side side) : base(tileSheet, batch, spriteColumn, side)
		{

		}
	}
}