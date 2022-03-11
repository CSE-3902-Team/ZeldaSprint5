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
        public Vector2 position
        {
            get { return currentPos; }
            set
            {
                currentPos = value;
                UpdateCollisionBox();

            }
        }
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public Vector2 Destination
        {
            get { return destination; }
            set
            {
                destination = value;


            }
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
            currentPos = location;
            destination = location;
            link = player;
            topLeft = new TopLeft((int)currentPos.X, (int)currentPos.Y, this);
            bottomRight = new BottomRight((int)currentPos.X+40, (int)currentPos.Y+40, this);
            isAlive = true;

        }

        public void Update()
        {
            if (isAlive) { 

            FrameChaningforEnemy action = new FrameChaningforEnemy(currentPos, direction, destination, currentFrame);
            MoveEnemy move = new MoveEnemy(direction, currentPos, destination);
            NewDestination makeNextMove = new NewDestination(direction, currentPos, destination);


            if (frame == 5)
            {
       
                currentFrame = action.frameReturn();
                frame = 0;
            }


            currentPos = move.Move();

            direction = makeNextMove.RollingDice1();

            destination = makeNextMove.RollingDice();



            frame++;
        }
            else
            {
                currentPos.X = 0;
                currentPos.Y = 0;
            }
            UpdateCollisionBox();


        }
    
        public Vector2 draw()
        {
            Vector2 temp = new Vector2();
            EnemyDraw draw = new EnemyDraw(Texture, batch, new Vector2(0, 0), direction, destination, 0, 0, currentFrame, currentPos, isAlive,false);
            draw.DrawSkeleton();
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
