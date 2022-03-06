using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.DoorClass;

namespace Sprint0.LevelClass
{
    
    class WallCollisionBox : ITile,IBoxCollider
    {
        private readonly TopLeft topLeft;
        private readonly BottomRight bottomRight;

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
        public WallCollisionBox(Rectangle rect)
        {
            topLeft = new TopLeft(rect.X, rect.Y,this);
            bottomRight = new BottomRight(rect.X + rect.Width, rect.Y + rect.Height, this);
        }

        public void draw()
        {
            return;
        }
    }
}
