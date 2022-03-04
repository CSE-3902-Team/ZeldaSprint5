using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.DoorClass
{
    public abstract class ADoor
    {
        public Vector2 myPos;
        protected Texture2D mySheet;
        protected SpriteBatch myBatch;
        protected Rectangle sourceRect;
        protected static int height = 132;
        protected static int width = 132;

        public ADoor(Texture2D tileSheet, SpriteBatch batch, Vector2 position, int spriteColumn, int side)
        {
            mySheet = tileSheet;
            myBatch = batch;
            myPos = position;
            sourceRect = new Rectangle(spriteColumn * width, side * height, 127, 127);
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