using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public interface IProjectile
    {
        public void Draw();
        public float GetDirection(int x, int y);

        public Boolean IsRunning { get; set; }
        
    }
}
