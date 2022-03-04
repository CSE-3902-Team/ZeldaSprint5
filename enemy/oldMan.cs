using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public class oldMan : IEnemySprite
    {

        public Texture2D Texture;

        private int currentFrame;

        private SpriteBatch batch;

        private int currentX = 400;
        private int currentY = 200;

        int x = 400;
        int y = 200;

        public oldMan(Texture2D texture, SpriteBatch batch, Vector2 location)
        {
            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentX = (int)location.X;
            currentY = (int)location.Y;


        }

        public void Update()
        {

        }


        public Vector2 draw()
        {

            Vector2 temp = new Vector2();
            int row = currentFrame;

            Rectangle sourceRectangle = new Rectangle(444, 266, 26, 40);
            Rectangle destinationRectangle = new Rectangle(400, 200, 80, 100);

            batch.Begin();
            batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            batch.End();
            temp.X = currentX;
            temp.Y = currentY;
            return temp;
        }


    }
}
