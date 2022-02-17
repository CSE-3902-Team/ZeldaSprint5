using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public interface IProjectile
    {
        public void Draw(int x, int y);
        public float GetDirection(int x, int y);
        
    }
}
