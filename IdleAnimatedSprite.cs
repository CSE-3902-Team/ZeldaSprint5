using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    public class IdleAnimatedSprite : ISprite
    {
        private Vector2 position;
        private float speed;
        Texture2D texture;
        private SpriteBatch batch;
        private int frame;
        private Rectangle sourceRect;


        public IdleAnimatedSprite(Texture2D texture, SpriteBatch batch, Vector2 position, float speed) {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.speed = speed;
            this.frame = 19;
            sourceRect = new Rectangle(7, 0, 12, 16);
        }
       
        public void draw() {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 90, 90);
            frame++;
            if (frame > 80) {
                frame = 1; 
            }
            switch (frame) {
                case 20:
                    sourceRect = new Rectangle(6, 0, 14, 16);
                    break;
                case 40: 
                    sourceRect = new Rectangle(27, 0, 26, 16);
                    break;
                case 60: 
                    sourceRect = new Rectangle(56, 0, 22, 16);
                    break;
                case 80:
                    sourceRect = new Rectangle(85, 0, 14, 16);
                    break;
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
