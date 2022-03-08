using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.ItemClass
{
    public abstract class AItem : IBoxCollider
    {
        public Vector2 myPos;
        protected Texture2D mySheet;
        protected SpriteBatch myBatch;
        protected Rectangle sourceRect;
        protected const int WIDTH_HEIGHT = 64;
        protected bool isPickedUp = false;
        protected readonly TopLeft topLeft;
        protected readonly BottomRight bottomRight;

        public TopLeft TopLeft
        {
            get { return topLeft; }
        }
        public BottomRight BottomRight
        {
            get { return bottomRight; }
        }

        public bool IsPickedUp
        {
            get { return isPickedUp;}
            set { isPickedUp = value; }
        }

        public AItem(Texture2D tileSheet, SpriteBatch batch, Vector2 position, int spritePos)
        {
            mySheet = tileSheet;
            myBatch = batch;
            myPos = position;
            sourceRect = new Rectangle(16 * spritePos, 0, 16, 16);
            topLeft = new TopLeft((int)position.X, (int)position.Y, this);
            bottomRight = new BottomRight((int)position.X + WIDTH_HEIGHT, (int)position.Y + WIDTH_HEIGHT, this);
        }
        public void draw()
        {
            if (!isPickedUp)
            {
                Rectangle destinationRectangle = new Rectangle((int)myPos.X, (int)myPos.Y, WIDTH_HEIGHT, WIDTH_HEIGHT);
                myBatch.Begin();
                myBatch.Draw(
                     mySheet,
                     destinationRectangle,
                     sourceRect,
                    Color.White
                    );
                myBatch.End();
            }
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