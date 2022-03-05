using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace Sprint0.DoorClass
{
	public class DoorWall : ADoor
	{
		private static int spriteColumn = 0;

		public DoorWall(Texture2D tileSheet, SpriteBatch batch, Vector2 position, int side) : base(tileSheet, batch, position, spriteColumn, side)
		{

		}
	}
}