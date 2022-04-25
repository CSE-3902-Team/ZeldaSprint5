using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.ItemClass
{
    public class ItemSpecialArrow : AItem
    {
        private static int spritePos = 9;

        public ItemSpecialArrow(Texture2D tileSheet, SpriteBatch batch, Vector2 position) : base(tileSheet, batch, position, spritePos)
        {

        }
    }
}