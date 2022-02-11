using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

public class ItemRupee : AItem
{
	private static int spritePos = 8;

	public ItemRupee(Texture2D tileSheet, SpriteBatch batch, Vector2 position) : base(tileSheet, batch, position, spritePos)
	{

	}
}
