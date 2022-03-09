using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint0.enemy
{
    public class enemySkeleton : IEnemySprite, IBoxCollider
    {

        public Texture2D Texture;

        private int currentFrame;

        private SpriteBatch batch;
        Random getDistance = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForAxis = new Random((int)DateTime.Now.Ticks);
        Random coinFlipForDirection = new Random((int)DateTime.Now.Ticks);
        private int flipHorizontally;
        public  Vector2 direction;

        private Vector2 currentPos;

        public Game1 game;
        Player link;

        private readonly TopLeft topLeft;
        private readonly BottomRight bottomRight;
        private bool isAlive;

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }




        private Vector2 destination;
        int x = 400;
        int y = 200;
        private int frame;

        public TopLeft TopLeft
        {
            get { return topLeft; }
        }
        public BottomRight BottomRight
        {
            get { return bottomRight; }
        }
        public enemySkeleton(Texture2D texture, SpriteBatch batch, Vector2 location,Player player)
        {

            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentPos.Y = 200;
            currentPos.X = 400;
            destination.X = 400;
            destination.Y = 200;
            link = player;
            topLeft = new TopLeft((int)currentPos.X, (int)currentPos.Y, this);
            bottomRight = new BottomRight((int)currentPos.X+40, (int)currentPos.Y+40, this);
            isAlive = true;

        }

        public void Update()
        {
        
            FrameChaningforEnemy action = new FrameChaningforEnemy(currentPos, direction, destination, currentFrame);
            MoveEnemy move = new MoveEnemy(direction, currentPos, destination);
            NewDestination makeNextMove = new NewDestination(direction, currentPos, destination);
            CollisionHandlerEnemyProjectile temp = new CollisionHandlerEnemyProjectile(direction, currentPos, destination,link);

            if (frame == 5)
            {
                flipHorizontally++;
                currentFrame = action.frameReturn();
                frame = 0;
            }

            temp.HandleCollision();
            currentPos = move.Move();
            
                direction = makeNextMove.RollingDice1();
       
            destination = makeNextMove.RollingDice();
       
   
         
            frame++;
            UpdateCollisionBox();


        }
    
        public Vector2 draw()
        {
            Vector2 temp = new Vector2();
            Vector2 origin = new Vector2(0, 0);
            Vector2 location = new Vector2((int)currentPos.X, (int)currentPos.Y);
   

            Rectangle sourceRectangle = new Rectangle(1, 60, 16, 16);



            batch.Begin();

            if (flipHorizontally%2==0)
                batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 4f, SpriteEffects.FlipHorizontally, 1);
                



            else
                batch.Draw(Texture, location, sourceRectangle, Color.White, 0.01f, origin, 4f, SpriteEffects.None, 1);
            batch.End();
     
            return temp;
        }

        private void UpdateCollisionBox() {
            topLeft.X = (int)currentPos.X;
            topLeft.Y = (int)currentPos.Y;
            bottomRight.X = (int)currentPos.X + 40;
            bottomRight.Y = (int)currentPos.Y + 40;
        }
    }
}
