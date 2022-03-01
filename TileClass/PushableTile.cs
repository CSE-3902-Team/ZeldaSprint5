using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.TileClass
{
    public class PushableTile : ITile
    {
        private Vector2 myPos;
        private Texture2D myTile;
        private SpriteBatch myBatch;
        private Rectangle sourceRect;

        public PushableTile(Texture2D tile, SpriteBatch batch, Vector2 position)
        {
            myTile = tile;
            myBatch = batch;
            myPos = position;
            sourceRect = new Rectangle(0, 0, 64, 64);
        }
        public void draw()
        {
            Rectangle destinationRectangle = new Rectangle((int)myPos.X, (int)myPos.Y, 64, 64);
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
    }

}