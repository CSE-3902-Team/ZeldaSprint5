using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

public class ItemFairy : AItem
{
	private static int spritePos = 11;

	public ItemFairy(Texture2D tileSheet, SpriteBatch batch, Vector2 position) : base(tileSheet, batch, position, spritePos)
	{

	}
}
