using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint0.enemy
{
    public class enemyGel: IEnemySprite
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
        public enemyGel(Texture2D texture, SpriteBatch batch, Vector2 location,Player player)
        {

            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentPos.Y = 200;
            currentPos.X = 400;
            destination.X = 400;
            destination.Y = 200;
            link = player;

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

        Rectangle sourceRectangle = new Rectangle(8 * row +2, 11, 8, 16);
        Rectangle destinationRectangle = new Rectangle((int)currentPos.X, (int)currentPos.Y, 64, 64);

        batch.Begin();
        batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
     
        batch.End();
       
            return temp;
    }


}
}
