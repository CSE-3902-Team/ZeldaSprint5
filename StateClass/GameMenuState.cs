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

        private const int ONEPLAYERX = 468;
        private const int ONEPLAYERY = 48;

        private const int TWOPLAYERX = 468;
        private const int TWOPLAYERY = 48;

        private const int EXITX = 283;
        private const int EXITY = 48;


        
        private Texture2D titleScreen;
        private Texture2D exitText;
        private Texture2D onePlayer;
        private Texture2D twoPlayer;





        //private KeyboardController kController;
        //private MouseController mController;


        public GameMenuState(Game1 game, ContentManager content) : base(game, content)
        {
            _game = game;
            _content = content;

        }
        public override void loadContent()
        {
            Vector2 center = new Vector2(_game.GraphicsDeviceManager.PreferredBackBufferWidth / 2, _game.GraphicsDeviceManager.PreferredBackBufferHeight / 2);
            titleScreen = _content.Load<Texture2D>("TitleScreen");
            exitText = _content.Load<Texture2D>("ExitTextBlack");
            onePlayer = _content.Load<Texture2D>("1Player");
            twoPlayer = _content.Load<Texture2D>("2Player");
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

            Rectangle onePDestRect = new Rectangle(XCENTER - ONEPLAYERX / 2, YCENTER + 48, ONEPLAYERX, ONEPLAYERY);
            Rectangle onePSrcRect = new Rectangle(0, 0, ONEPLAYERX, ONEPLAYERY);

            Rectangle twoPDestRect = new Rectangle(XCENTER - TWOPLAYERX / 2, YCENTER + 48 * 3, TWOPLAYERX, TWOPLAYERY);
            Rectangle twoPSrcRect = new Rectangle(0, 0, TWOPLAYERX, TWOPLAYERY);

            Rectangle exitTextDestRect = new Rectangle(XCENTER - EXITX / 2, YCENTER + 48 * 5, EXITX, EXITY);
            Rectangle exitTextSrcRect = new Rectangle(0, 0, EXITX, EXITY);
         
            
            _game.SpriteBatch.Begin();

           
                _game.SpriteBatch.Draw(
                     titleScreen,
                     screenDestRect,
                     screenSrcRect,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0f
                    );

            _game.SpriteBatch.Draw(
                 onePlayer,
                 onePDestRect,
                 onePSrcRect,
                Color.White,
                0f,
                new Vector2(0, 0),
                SpriteEffects.None,
                0f
                );

            _game.SpriteBatch.Draw(
                     twoPlayer,
                     twoPDestRect,
                     twoPSrcRect,
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

