using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    public class IdleNonAnimatedSprite : ISprite
    {
        private Vector2 position;
        private float speed;
        Texture2D texture;
        private SpriteBatch batch;
        Rectangle sourceRect;


        public IdleNonAnimatedSprite(Texture2D texture, SpriteBatch batch, Vector2 position, float speed) {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.speed = speed;
            sourceRect = new Rectangle(7, 0, 12, 16);
        }
       
        public void draw() {

            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 90, 90);
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
