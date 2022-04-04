using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint0.enemy
{
    public class trap : IEnemySprite, IBoxCollider
    {

        public Texture2D Texture;

        private int currentFrame;
        private Boolean trigger;
        private SpriteBatch batch;
        Player link;
        private Vector2 location;
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
        public TopLeft TopLeft { get { return topLeft; } }
        public BottomRight BottomRight { get { return botRight; } }
        public trap(Texture2D texture, SpriteBatch batch, Vector2 location, Player player)
        {

            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentPos = location;
            destination = location;
            link = player;
            topLeft = new TopLeft((int)currentPos.X, (int)currentPos.Y, this);
            botRight = new BottomRight((int)currentPos.X + 64, (int)currentPos.Y + 64, this);
            isAlive = true;
            this.location = location;

        }

        public void Update()
        {

       
                MoveEnemy move = new MoveEnemy(direction, currentPos, destination);
            NewDestination target = new NewDestination(direction, currentPos, destination);

            if (link.Position.X < 250 || link.Position.X > 750)
            {
                trigger = true;

            }

            if (frame > 100)
            {
                trigger = false;
                frame = 0;
              
            }
           
                direction = target.trap1(link);
            
    
            if (trigger==true)
            {
                currentPos = move.trapMove(frame,location);
                frame++;
            }

       




            UpdateCollisionBox();


        }


        public Vector2 draw()
        {

            Vector2 temp = new Vector2();


            EnemyDraw draw = new EnemyDraw(Texture, batch, new Vector2(0, 0), direction, destination, 0, 0, currentFrame, currentPos, true, false);
            draw.DrawTrap();
            return temp;
        }
        private void UpdateCollisionBox()
        {
            if (isAlive)
            {
                topLeft.X = (int)currentPos.X;
                topLeft.Y = (int)currentPos.Y;
                botRight.X = (int)currentPos.X + 40;
                botRight.Y = (int)currentPos.Y + 40;
            }
            else
            {
                topLeft.X = 0;
                topLeft.Y = 0;
                botRight.X = 0;
                botRight.Y = 0;

            }
        }



    }
}
