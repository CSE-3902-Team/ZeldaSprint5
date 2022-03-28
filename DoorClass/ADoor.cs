using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.DoorClass
{
    public abstract class ADoor
    {

        public const int OFFSET = 256;
        private static Vector2 topDoorLocation = new Vector2(448, 0 + OFFSET);
        private static Vector2 leftDoorLocation = new Vector2(0, 288+ OFFSET);
        private static Vector2 rightDoorLocation = new Vector2(896, 288+OFFSET);
        private static Vector2 bottomDoorLocation = new Vector2(448, 576+OFFSET);

        public Vector2 myPos;
        protected Texture2D mySheet;
        protected SpriteBatch myBatch;
        protected Rectangle sourceRect;
        protected DoorFactory.Side side;
        protected static int height = 132;
        protected static int width = 132;

        public ADoor(Texture2D tileSheet, SpriteBatch batch, int spriteColumn, DoorFactory.Side side)
        {
            this.side = side;
            mySheet = tileSheet;
            myBatch = batch;
            switch (side) {
                case DoorFactory.Side.Top:
                    myPos = topDoorLocation;
                    break;
                case DoorFactory.Side.Left:
                    myPos = leftDoorLocation;
                    break;
                case DoorFactory.Side.Right:
                    myPos = rightDoorLocation;
                    break;
                case DoorFactory.Side.Bottom:
                    myPos = bottomDoorLocation;
                    break;
                default:
                    myPos = topDoorLocation;
                    break;
            }

            sourceRect = new Rectangle(spriteColumn * width, (int)side * height, 127, 127);
        }
        public void draw()
        {
            Rectangle destinationRectangle = new Rectangle((int)myPos.X, (int)myPos.Y, 128, 128);
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