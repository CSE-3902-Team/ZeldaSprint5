using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.TileClass
{
    public class Text : ITile, IBoxCollider
    {
        private readonly TopLeft tLeft;
        private readonly BottomRight bRight;
        private Vector2 myPos;
        private Texture2D myTile;
        private SpriteBatch myBatch;
        private Rectangle sourceRect;

        public Text(Texture2D tile, SpriteBatch batch, Vector2 position)
        {
            myTile = tile;
            myBatch = batch;
            myPos = position;
            sourceRect = new Rectangle(0, 0, 624, 62);
            tLeft = new TopLeft((int)position.X, (int)position.Y, this);
            bRight = new BottomRight((int)position.X + 64, (int)position.Y, this);
        }
        public void draw()
        {
            Rectangle destinationRectangle = new Rectangle((int)myPos.X, (int)myPos.Y, 624, 62);
            myBatch.Begin();
            myBatch.Draw(
                 myTile,
                 destinationRectangle,
                 sourceRect,
                Color.White,
                0f,
                new Vector2(0, 0),
                SpriteEffects.None,
                0f
                );
            myBatch.End();
        }

        public Texture2D Texture
        {
            get { return this.myTile; }
            set { myTile = value; }
        }

        public float Speed
        {
            get;
            set;
        }

        public Vector2 Position
        {
            get { return myPos; }
            set { myPos = value; }
        }

        public TopLeft TopLeft
        {
            get { return tLeft; }
            set { }
        }

        public BottomRight BottomRight
        {
            get { return bRight; }
            set { }
        }
    }

}