using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Sprint0.LevelClass;

namespace Sprint0.DoorClass
{
    public abstract class ADoor : IBoxCollider
    {

        public const int OFFSET = 256;
        private static Vector2 topDoorLocation = new Vector2(448, 0 + OFFSET);
        private static Vector2 leftDoorLocation = new Vector2(0, 288+ OFFSET);
        private static Vector2 rightDoorLocation = new Vector2(896, 288+OFFSET);
        private static Vector2 bottomDoorLocation = new Vector2(448, 576+OFFSET);
        private static Vector2 ladderDoorLocation = new Vector2(192, 0 + OFFSET);
        private static int shrink = 30; //constant to shrink the collision box of the door to make walking into it less abrupt

        public Vector2 myPos;
        internal static LevelManager levelManager = LevelManager.Instance;
        internal Texture2D mySheet;
        internal SpriteBatch myBatch;
        internal Rectangle sourceRect;
        internal DoorFactory.Side side;
        internal TopLeft topLeft;
        internal BottomRight bottomRight;
        internal static int height = 132;
        internal static int width = 132;
        internal bool isRunning;
        internal int roomConnection;

        public TopLeft TopLeft
        {
            get { return topLeft; }
        }

        public BottomRight BottomRight
        {
            get { return bottomRight; }
        }

        public DoorFactory.Side DoorSide
        {
            get { return side; }
        }

        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }

        public ADoor(Texture2D tileSheet, SpriteBatch batch, int spriteColumn, DoorFactory.Side side, int roomConnection)
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
                case DoorFactory.Side.Ceiling:
                    myPos = ladderDoorLocation;
                    break;
                default:
                    myPos = topDoorLocation;
                    break;
            }

            if (this.GetType() == typeof(DoorOpen))
            {
                topLeft = new TopLeft((int)myPos.X + shrink, (int)myPos.Y + shrink, this);
                bottomRight = new BottomRight((int)myPos.X + width - shrink, (int)myPos.Y + height - shrink, this);
            }
            else if (this.GetType() == typeof(DoorInvisible))
            {
                topLeft = new TopLeft((int)myPos.X, (int)myPos.Y, this);
                bottomRight = new BottomRight((int)myPos.X + 64, (int)myPos.Y + 10, this);
            }
            else {
                topLeft = new TopLeft((int)myPos.X, (int)myPos.Y, this);
                bottomRight = new BottomRight((int)myPos.X + width, (int)myPos.Y + height, this);
            }
            
            sourceRect = new Rectangle(spriteColumn * width, (int)side * height, 127, 127);
            isRunning = true;
            this.roomConnection = roomConnection;
        }
        public void draw()
        {
            draw(0, 0);
        }

        public void draw(int xOffset, int yOffset)
        {
            if (this.GetType() != typeof(DoorInvisible))
            {
                Rectangle destinationRectangle = new Rectangle((int)myPos.X + xOffset, (int)myPos.Y + yOffset, 128, 128);
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

        public void ChangeRoom() {
            levelManager.RoomTransition(roomConnection, side);
        }

        public int connection {
        get { return this.roomConnection; }
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