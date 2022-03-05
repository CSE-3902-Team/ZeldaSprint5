using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint0.enemy
{
    public class enemyHand : IEnemySprite,IBoxCollider
    {

        public Texture2D Texture;

        private int currentFrame;

        private SpriteBatch batch;
        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);
        Player link;
        private Vector2 direction;
        private Vector2 currentPos;
        private Vector2 destination;
        int x = 400;
        int y = 200;
        private int frame;
        private TopLeft topLeft;
        private BottomRight botRight;

        public TopLeft TopLeft
        {
            get { return topLeft; }
        }

        public BottomRight BottomRight
        {
            get { return botRight; }
        }

        public enemyHand(Texture2D texture, SpriteBatch batch, Vector2 location,Player player)
        {

            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentPos.Y = 200;
            currentPos.X = 400;
            destination.X = 400;
            destination.Y = 200;
            link = player;
            topLeft = new TopLeft(400, 200, this);
            botRight = new BottomRight(440, 240, this);

        }

        public void Update()
        {

            FrameChaningforEnemy action = new FrameChaningforEnemy(currentPos, direction, destination, currentFrame);
            MoveEnemy move = new MoveEnemy(direction, currentPos, destination);
            NewDestination makeNextMove = new NewDestination(direction, currentPos, destination);
            CollisionHandlerEnemyProjectile temp = new CollisionHandlerEnemyProjectile(direction, currentPos, destination, link);

            if (frame == 5)
            {
             
                currentFrame = action.frameReturn();
                frame = 0;
            }

            temp.HandleCollision();
            currentPos = move.Move();

            direction = makeNextMove.RollingDice1();

            destination = makeNextMove.RollingDice();



            frame++;
            //UpdateCollisionBox();

        }

        public Vector2 draw()
        {

            Vector2 temp = new Vector2();
            int row = currentFrame;

            Rectangle sourceRectangle = new Rectangle(16 * row + 393, 11, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)currentPos.X, (int)currentPos.Y, 40, 40);

            batch.Begin();
            batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            batch.End();
        
            return temp;
        }

        private void UpdateCollisionBox()
        {
            topLeft.X = (int)currentPos.X;
            topLeft.Y = (int)currentPos.Y;
            botRight.X = (int)currentPos.X + 40;
            botRight.Y = (int)currentPos.Y + 40;

        }


    }
}
