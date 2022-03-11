using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint0.TileClass
{
    
    class WallCollisionBox : ITile,IBoxCollider
    {
        private readonly TopLeft topLeft;
        private readonly BottomRight bottomRight;
        private Boolean isPushable = false;


        public float Speed
        {
            get { return 0; }
            set { }
        }

        public Vector2 Position
        {
            get { return new Vector2(topLeft.X,topLeft.Y); }
            set { }
        }

        public Boolean Walkable
        {
            get { return false; }
            set { }
        }

        public Texture2D Texture
        {
            get { return null; }
            set { }
        }

        public TopLeft TopLeft
        {
            get { return topLeft; }
        }
        public BottomRight BottomRight
        {
            get { return bottomRight; }
        }

        public Boolean Pushable
        {
            get { return isPushable; }

        }

        public WallCollisionBox(Rectangle rect)
        {
            topLeft = new TopLeft(rect.X, rect.Y, this);
            bottomRight = new BottomRight(rect.X + rect.Width, rect.Y + rect.Height, this);
        }

        public void draw()
        {
            return;
        }
    }
}
