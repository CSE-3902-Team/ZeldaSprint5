using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.ItemClass
{
    public class ItemClock : AItem
    {
        private static int spritePos = 12;

        public ItemClock(Texture2D tileSheet, SpriteBatch batch, Vector2 position) : base(tileSheet, batch, position, spritePos)
        {

        }
    }
}