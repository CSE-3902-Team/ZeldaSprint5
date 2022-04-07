using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.TileClass

{
    class RoomWalls : ITile
    {


        private const int OFFSET = 256;
        private Vector2 myPos;
        private Texture2D myTile;
        private SpriteBatch myBatch;
        private Rectangle sourceRect;
        private Boolean isWalkable = true;
        private Boolean isPushable = false;



        public RoomWalls(Texture2D tile, SpriteBatch batch, Vector2 position)
        {
            myTile = tile;
            myBatch = batch;
            myPos = new Vector2(512,352 + OFFSET);
            sourceRect = new Rectangle(0, 0, 1024, 704);

        }

        public void draw()
        {
            draw(0, 0);
        }

        public void draw(int xOffset, int yOffset)
        {
            Rectangle destinationRectangle = new Rectangle((int)myPos.X+xOffset, (int)myPos.Y+yOffset, 1024, 704);
            myBatch.Begin();
            myBatch.Draw(
                 myTile,
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

        public Boolean Walkable
        {
            get { return isWalkable; }
            set { }
        }

        public Boolean Pushable
        {
            get { return isPushable; }

        }

    }
}

