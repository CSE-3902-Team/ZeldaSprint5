using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0
{
	public interface ITile
	{
        public Texture2D Texture
        {
            get;
            set;
        }

        public float Speed
        {
        get;
        set;
        }

        public Vector2 Position
        {
            get;
            set;
        }

        public Boolean Walkable
        {
            get;
            set;
        }

        public Boolean Pushable
        {
            get;
            
        }
        void draw();
	}
}