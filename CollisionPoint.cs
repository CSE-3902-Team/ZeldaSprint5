using System;

namespace Sprint0
{
    public class CollisionPoint
    {
        private int x;
        private int y;
        private Object parent;
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public Object Parent { get { return parent; } }

        public CollisionPoint(int x, int y, Object p)
        {
            this.x = x;
            this.y = y;
            parent = p;
        }
    }
}
