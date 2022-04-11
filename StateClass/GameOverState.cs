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
    public class GameOverState : AState
    {
        private const int WIDTH = 1024;
        private const int HEIGHT = 960;
        private const int YCENTER = 960 / 2;
        private const int XCENTER = 1024 / 2;
        private const int GAMEOVERX = 468;
        private const int GAMEOVERY = 48;
        private const int REPLAYX = 416;
        private const int REPLAYY = 48;
        private const int EXITX = 283;
        private const int EXITY = 48;
        private const int SKULLX = 271;
        private const int SKULLY = 300;

        
        private Texture2D screen;
        private Texture2D gameOverText;
        private Texture2D replayText;
        private Texture2D exitText;
        private Texture2D skull;
        private Texture2D animation;

        private int currentFrame;
        private int count;

        

        //private KeyboardController kController;
        //private MouseController mController;


        public GameOverState(Game1 game, ContentManager content) : base(game, content)
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
            gameOverText = _content.Load<Texture2D>("GameOverText2");
            replayText = _content.Load<Texture2D>("ReplayText");
            exitText = _content.Load<Texture2D>("ExitText");
            skull = _content.Load <Texture2D>("Skull");
            IsGameOver = true;
            animate = true;
            count = 0;
            currentFrame = 1;
        }

        public override void update(GameTime gameTime)
        {
            _game.MouseController.handleInput();
            _game.KeyboardController.handleInput();
            

            if (animate)
            {
                if (count > 100)
                {
                    animate = false;
                }
                count++;
                currentFrame++;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Rectangle screenDestRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            Rectangle screenSrcRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            Rectangle gameOverTextDestRect = new Rectangle(XCENTER - GAMEOVERX / 2, YCENTER - 48 * 1, GAMEOVERX, GAMEOVERY);
            Rectangle gameOverTextSrcRect = new Rectangle(0, 0, GAMEOVERX, GAMEOVERY);
            Rectangle replayTextDestRect = new Rectangle(XCENTER - REPLAYX / 2, YCENTER + 48, REPLAYX, REPLAYY);
            Rectangle replayTextSrcRect = new Rectangle(0, 0, REPLAYX, REPLAYY);
            Rectangle exitTextDestRect = new Rectangle(XCENTER - EXITX / 2, YCENTER + 48 * 3, EXITX, EXITY);
            Rectangle exitTextSrcRect = new Rectangle(0, 0, EXITX, EXITY);
            Rectangle skullDestRect = new Rectangle(XCENTER - SKULLX / 2, YCENTER - 400, SKULLX, SKULLY);
            Rectangle skullSrcRect = new Rectangle(0, 0, SKULLX, SKULLY);
            
            _game.SpriteBatch.Begin();

            if (animate)
            {

                if (currentFrame %10 != 0)
                {
                    animation = _content.Load<Texture2D>("BlackBackground");
                }
                else if (currentFrame % 10 == 0)
                {
                    animation = _content.Load<Texture2D>("SkullResized");
                }

                _game.SpriteBatch.Draw(
                     animation,
                     screenDestRect,
                     screenSrcRect,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0f
                    );
            }
            else
            {
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
                     gameOverText,
                     gameOverTextDestRect,
                     gameOverTextSrcRect,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0f
                    );
                _game.SpriteBatch.Draw(
                     replayText,
                     replayTextDestRect,
                     replayTextSrcRect,
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
                _game.SpriteBatch.Draw(
                     skull,
                     skullDestRect,
                     skullSrcRect,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0f
                    );
            }

            _game.SpriteBatch.End();

        }
    }
}

