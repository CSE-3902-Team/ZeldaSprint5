using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace Sprint0.DoorClass
{
	public class DoorHole : ADoor
	{
		private static int spriteColumn = 4;

		public DoorHole(Texture2D tileSheet, SpriteBatch batch, Vector2 position, int side) : base(tileSheet, batch, position, spriteColumn, side)
		{

		}
	}
}