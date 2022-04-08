using Microsoft.Xna.Framework;


namespace Sprint0
{
    public interface IEnemySprite
    {

        void draw();
        void draw(int xOffset, int yOffset);
        void Update();
        int deathCount { get; set; }
        bool IsAlive { get; set; }
        public Vector2 position
        {
            get;
            set;
        }
        public Vector2 Destination
        {
            get;
            set;
        }

    }
}
