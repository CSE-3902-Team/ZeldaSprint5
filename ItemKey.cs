using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

public class ItemKey : AItem
{
	private static int spritePos = 2;

	public ItemKey(Texture2D tileSheet, SpriteBatch batch, Vector2 position) : base(tileSheet, batch, position, spritePos)
	{

	}
}
