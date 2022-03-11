using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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
        private bool isAlive;

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public TopLeft TopLeft
        {
            get { return topLeft; }
        }

        public BottomRight BottomRight
        {
            get { return botRight; }
        }
        public Vector2 position
        {
            get { return currentPos; }
            set
            {
                currentPos = value;
                UpdateCollisionBox();

            }
        }
        public Vector2 Destination
        {
            get { return destination; }
            set
            {
                destination = value;


            }
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
            isAlive = true;

        }

        public void Update()
        {
            if (isAlive)
            {
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
            }
            else
            {
                currentPos.X = 0;
                currentPos.Y = 0;
            }

            frame++;
            UpdateCollisionBox();

        }

        public Vector2 draw()
        {

            Vector2 temp = new Vector2(0, 0);

            EnemyDraw draw = new EnemyDraw(Texture, batch, new Vector2(0, 0), direction, destination, 0, 0, currentFrame, currentPos, isAlive,false);
            draw.DrawHand();

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
