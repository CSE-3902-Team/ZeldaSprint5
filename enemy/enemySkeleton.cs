using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0.enemy
{
    public class enemySkeleton : IEnemySprite
    {

        public Texture2D Texture;

        private int currentFrame;

        private SpriteBatch batch;
        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);
        private int flipHorizontally;
        public Vector2 direction;
        private Vector2 currentPos;
        public Vector2 CurrentPos
        {
            get { return currentPos; }
            set { currentPos = value; }
        }
        private Vector2 destination;
        int x = 400;
        int y = 200;
        private int frame;
        public enemySkeleton(Texture2D texture, SpriteBatch batch, Vector2 location)
        {

            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentPos.Y = 200;
            currentPos.X = 400;
            destination.X = 400;
            destination.Y = 200;


        }

        public void Update()
        {
            FrameChaningforEnemy action = new FrameChaningforEnemy(currentPos, direction, destination, currentFrame);
            MoveEnemy move = new MoveEnemy(direction, currentPos, destination);
            NewDestination makeNextMove = new NewDestination(direction, currentPos, destination);
            CollisionHandlerEnemyBlock temp = new CollisionHandlerEnemyBlock(direction, currentPos, destination);

            if (frame == 5)
            {
                flipHorizontally++;
                currentFrame = action.frameReturn();
                frame = 0;
            }


            currentPos = move.Move();

            direction = makeNextMove.RollingDice1();
            destination = makeNextMove.RollingDice();


            frame++;

        }

        public Vector2 draw()
        {
            Vector2 temp = new Vector2();
            Vector2 origin = new Vector2(0, 0);
            Vector2 location = new Vector2((int)currentPos.X, (int)currentPos.Y);


            Rectangle sourceRectangle = new Rectangle(1, 60, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)currentPos.X, (int)currentPos.Y, 164, 164);

            batch.Begin();
            if (flipHorizontally % 2 == 0)
                batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 4f, SpriteEffects.FlipHorizontally, 1);


            else
                batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 4f, SpriteEffects.None, 1);
            batch.End();

            return temp;
        }
    }
}
