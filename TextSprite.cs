using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    public class TextSprite : ISprite
    {
        private Vector2 position;
        private float speed;
        Texture2D texture;
        private SpriteBatch batch;
        Rectangle sourceRect;


        public TextSprite(Texture2D texture, SpriteBatch batch, Vector2 position, float speed) {
            this.texture = texture;
            this.batch = batch;
            this.position = new Vector2(position.X,position.Y+250);
            this.speed = speed;
            sourceRect = new Rectangle(0,0,0,0);
        }
       
        public void draw() {

            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 90, 90);
            batch .Begin();
            batch.Draw(
                texture,
    position,
    null,
    Color.White,
    0f,
    new Vector2(texture.Width / 2, texture.Height / 2),
    new Vector2(0.5f,0.5f),
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
