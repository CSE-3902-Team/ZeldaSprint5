using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public interface IProjectile
    {
        public void Draw();
        public void Update();

        // Used by the Player class to know if the projectile is still in animation
        public Boolean IsRunning { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 Position { get; set; }
        
    }
}
