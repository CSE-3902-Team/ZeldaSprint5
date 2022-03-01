using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
namespace Sprint0.Collision
{
    class BEPoint  
    {
        private Point cordinate;
        private IBoxCollider box;
        private PointT pointType;
        public Point Cordinate { get { return cordinate; } set { cordinate = value; } }
        public IBoxCollider Box { get { return box; } set { box = value; } }
        public PointT PointType { get { return pointType; } }
        public BEPoint(IBoxCollider b, Point p, PointT t)
        {
            cordinate = p;
            box = b;
            pointType = t;
        }
    }
}
