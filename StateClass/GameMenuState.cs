using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.LevelClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.StateClass
{
    public class GameMenuState : AState
    {
        private const int WIDTH = 1024;
        private const int HEIGHT = 960;
        private const int YCENTER = 960 / 2;
        private const int XCENTER = 1024 / 2;

        private const int EXITX = 283;
        private const int EXITY = 48;


        
        private Texture2D screen;
        private Texture2D exitText;





        

        //private KeyboardController kController;
        //private MouseController mController;


        public GameMenuState(Game1 game, ContentManager content) : base(game, content)
        {
            _game = game;
            _content = content;
            //kController = new KeyboardController(_game, new Vector2(_game.GraphicsDeviceManager.PreferredBackBufferWidth / 2, _game.GraphicsDeviceManager.PreferredBackBufferHeight / 2));
            //mController = new MouseController(_game);
        }
        public override void loadContent()
        {
            Vector2 center = new Vector2(_game.GraphicsDeviceManager.PreferredBackBufferWidth / 2, _game.GraphicsDeviceManager.PreferredBackBufferHeight / 2);
            screen = _content.Load<Texture2D>("BlackBackground");
            exitText = _content.Load<Texture2D>("ExitText");
            isMenu = true;
        }

        public override void update(GameTime gameTime)
        {
            _game.MouseController.handleInput();
            _game.KeyboardController.handleInput();
        }

        public override void Draw(GameTime gameTime)
        {
            Rectangle screenDestRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            Rectangle screenSrcRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            
            Rectangle exitTextDestRect = new Rectangle(XCENTER - EXITX / 2, YCENTER + 48 * 3, EXITX, EXITY);
            Rectangle exitTextSrcRect = new Rectangle(0, 0, EXITX, EXITY);
         
            
            _game.SpriteBatch.Begin();

           
                _game.SpriteBatch.Draw(
                     screen,
                     screenDestRect,
                     screenSrcRect,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0f
                    );
             
              
                _game.SpriteBatch.Draw(
                     exitText,
                     exitTextDestRect,
                     exitTextSrcRect,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0f
                    );
               

            _game.SpriteBatch.End();

        }
    }
}

