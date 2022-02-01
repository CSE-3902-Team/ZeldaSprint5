using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    //sprite position, sprite speed, sprite texture,sprite batch? 
    public class movingNonAnimatedSprite : ISprite
    {
        private Vector2 position;
        private Vector2 startPosition; 
        private float speed;
        Texture2D texture;
        private SpriteBatch batch;
        private int frame;
        private Rectangle sourceRect;


        public movingNonAnimatedSprite(Texture2D texture, SpriteBatch batch, Vector2 position, float speed) {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            startPosition = new Vector2(position.X, position.Y); 
            this.speed = speed;
            frame = 1;
            sourceRect = new Rectangle(7, 0, 15, 16);
        }
      
        //Fix weird glitch where it looks like the spirite ends up starting at the bottom position
        public void draw() {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 90, 90);
            frame++;
            if (frame > 30) {
                frame = 1;
            }

            if (frame <= 15)
            {
                position.Y += 1*speed;
            }
            else if (frame > 15)
            {
                position.Y -= 1*speed; 
            }
            batch .Begin();
            
            batch.Draw(
                 texture,
                 destinationRectangle,
                 sourceRect,
                Color.White,
                0f,
                new Vector2(sourceRect.Width / 2, sourceRect.Height / 2),
                SpriteEffects.None,
                0f
                );
           
            batch.End();
        }

        public Texture2D Texture
        {
            get { return this.texture; }
            set { texture = value; }
        }

        public float Speed {
            get;
            set;
        }

        public Vector2 Position {
            get;
            set;
        }


    }
}
