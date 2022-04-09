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
    public class GameVictoryState : AState
    {
        private const int WIDTH = 1024;
        private const int HEIGHT = 960;
        private Game1 _game;
        private ContentManager _content;
        private Texture2D screen;
        private Texture2D text;
        //private KeyboardController kController;
        //private MouseController mController;


        public GameVictoryState(Game1 game, ContentManager content) : base(game, content)
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
            text = _content.Load<Texture2D>("VictoryText");
            isVictory = true;
        }

        public override void update(GameTime gameTime)
        {
            _game.MouseController.handleInput();
            _game.KeyboardController.handleInput();
            //if(player presses "play again")
            //reset the game
            //if(player presses "exit game")
            //quit the game
        }

        public override void Draw(GameTime gameTime)
        {
            Rectangle screenDestRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            Rectangle screenSrcRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            Rectangle textDestRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            Rectangle textSrcRect = new Rectangle(0, 0, WIDTH, HEIGHT);

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
                 text,
                 textDestRect,
                 textSrcRect,
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
