using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.ItemClass
{
    public abstract class AItem
    {
        public Vector2 myPos;
        protected Texture2D mySheet;
        protected SpriteBatch myBatch;
        protected Rectangle sourceRect;

        public AItem(Texture2D tileSheet, SpriteBatch batch, Vector2 position, int spritePos)
        {
            mySheet = tileSheet;
            myBatch = batch;
            myPos = position;
            sourceRect = new Rectangle(16 * spritePos, 0, 16, 16);
        }
        public void draw()
        {
            Rectangle destinationRectangle = new Rectangle((int)myPos.X, (int)myPos.Y, 64, 64);
            myBatch.Begin();
            myBatch.Draw(
                 mySheet,
                 destinationRectangle,
                 sourceRect,
                Color.White
                );
            myBatch.End();
        }

        public Texture2D Texture
        {
            get { return this.mySheet; }
            set { mySheet = value; }
        }

        public Vector2 Position
        {
            get;
            set;
        }
    }

}