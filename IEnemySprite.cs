using Microsoft.Xna.Framework;


namespace Sprint0
{
    public interface IEnemySprite
    {

        Vector2 draw();
        void Update();
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
