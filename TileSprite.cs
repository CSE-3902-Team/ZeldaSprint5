using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0
{
	public class TileSprite : ITile
	{
        private Vector2 myPos;
		private Texture2D mySheet;
		private SpriteBatch myBatch;
        private Rectangle sourceRect;

		public TileSprite(Texture2D tileSheet, SpriteBatch batch, Vector2 position)
        {
			mySheet = tileSheet;
			myBatch = batch;
            myPos = position;
        }
		public void draw()
		{
            Rectangle destinationRectangle = new Rectangle((int)myPos.X, (int)myPos.Y, 90, 90);
            myBatch.Begin();
            myBatch.Draw(
                 mySheet,
                 destinationRectangle,
                 sourceRect,
                Color.White,
                0f,
                new Vector2(sourceRect.Width / 2, sourceRect.Height / 2),
                SpriteEffects.None,
                0f
                );
            myBatch.End();
        }

        public Texture2D Texture
        {
            get { return this.mySheet; }
            set { mySheet = value; }
        }

        public float Speed
        {
            get;
            set;
        }

        public Vector2 Position
        {
            get;
            set;
        }
    }

}