using Microsoft.Xna.Framework;
using System;

namespace Sprint0
{
    public interface IProjectile
    {
        public void Draw();

        public void Draw(int xOffset, int yOffset);
        public void Update();

        public Boolean IsRunning { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 Position { get; set; }

    }
}
