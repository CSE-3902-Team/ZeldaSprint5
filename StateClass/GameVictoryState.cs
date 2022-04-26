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
        private const int YCENTER = 960 / 2;
        private const int XCENTER = 1024 / 2;
        private const int REPLAYX = 416;
        private const int REPLAYY = 48;
        private const int EXITX = 283;
        private const int EXITY = 48;
        private const int VICTORYX = 468;
        private const int VICTORYY = 48;
        private const int ANIMATIONX = 64;
        private const int CREDITSX = 616;
        private const int CREDITSY = 329;

        private Texture2D screen;
        private Texture2D victoryText;
        private Texture2D replayText;
        private Texture2D exitText;
        private Texture2D lAnimation;
        private Texture2D rAnimation;
        private Texture2D credits;

        private int currentFrame;
        private int count;
        private int rightStart;
        private int leftStart;
        private int musicStart = 0;
        private bool startCredits = false;

        

        


        public GameVictoryState(Game1 game, ContentManager content) : base(game, content)
        {
            _game = game;
            _content = content;
            
        }
        public override void loadContent()
        {
            Vector2 center = new Vector2(_game.GraphicsDeviceManager.PreferredBackBufferWidth / 2, _game.GraphicsDeviceManager.PreferredBackBufferHeight / 2);
            screen = _content.Load<Texture2D>("BlackBackground");
            victoryText = _content.Load<Texture2D>("VictoryText");
            replayText = _content.Load<Texture2D>("ReplayText");
            exitText = _content.Load<Texture2D>("ExitText");
            lAnimation = _content.Load<Texture2D>("blackColumn");
            rAnimation = _content.Load<Texture2D>("blackColumn");
            credits = _content.Load<Texture2D>("Creditsv2");
            isVictory = true;

            animate = true;
            currentFrame = 1;
            count = 0;
            rightStart = WIDTH - 64;
            leftStart = 0;
    }

        public override void update(GameTime gameTime)
        {
            _game.MouseController.handleInput();
            _game.KeyboardController.handleInput();

            if (animate)
            {

                if (count > 80)
                {
                    animate = false;
                }
                
                currentFrame++;
            }
            count++;
            
        }

        public override void Draw(GameTime gameTime)
        {
            
            Rectangle screenDestRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            Rectangle screenSrcRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            Rectangle victoryTextDestRect = new Rectangle(XCENTER - VICTORYX / 2, YCENTER - 48 * 5, VICTORYX, VICTORYY);
            Rectangle victoryTextSrcRect = new Rectangle(0, 0, VICTORYX, VICTORYY);
            Rectangle replayTextDestRect = new Rectangle(XCENTER - REPLAYX / 2, YCENTER -48 * 3, REPLAYX, REPLAYY);
            Rectangle replayTextSrcRect = new Rectangle(0, 0, REPLAYX, REPLAYY);
            Rectangle exitTextDestRect = new Rectangle(XCENTER - EXITX / 2, YCENTER - 48, EXITX, EXITY);
            Rectangle exitTextSrcRect = new Rectangle(0, 0, EXITX, EXITY);
            Rectangle creditsSrcRect = new Rectangle(0, 0, CREDITSX, CREDITSY);
            Rectangle creditsDestRect = new Rectangle(XCENTER - CREDITSX / 2, YCENTER + 48, CREDITSX, CREDITSY);
            
            Rectangle lAnimationDestRect = new Rectangle(leftStart, 0, ANIMATIONX, HEIGHT);
            Rectangle rAnimationDestRect = new Rectangle(rightStart, 0, ANIMATIONX, HEIGHT);
            Rectangle AimationSrcRect = new Rectangle(0, 0, ANIMATIONX, HEIGHT);

            _game.SpriteBatch.Begin();

            if (animate)
            {
                if (currentFrame % 10 == 0)
                {

                    lAnimationDestRect = new Rectangle(leftStart, 0, ANIMATIONX, HEIGHT);
                    rAnimationDestRect = new Rectangle(rightStart, 0, ANIMATIONX, HEIGHT);
                    
                    leftStart += 64;
                    rightStart -= 64;

                }
            
                
                    _game.SpriteBatch.Draw(
                         lAnimation,
                         lAnimationDestRect,
                         AimationSrcRect,
                        Color.White,
                        0f,
                        new Vector2(0, 0),
                        SpriteEffects.None,
                        0f
                        );

                    _game.SpriteBatch.Draw(
                         rAnimation,
                         rAnimationDestRect,
                         AimationSrcRect,
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
                     victoryText,
                     victoryTextDestRect,
                     victoryTextSrcRect,
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
                         credits,
                         creditsDestRect,
                         creditsSrcRect,
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
