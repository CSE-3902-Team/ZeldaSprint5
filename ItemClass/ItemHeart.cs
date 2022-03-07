using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.ItemClass
{
    public class ItemHeart : AItem
    {
        private static int spritePos = 7;

        public ItemHeart(Texture2D tileSheet, SpriteBatch batch, Vector2 position) : base(tileSheet, batch, position, spritePos)
        {

        }
    }
}