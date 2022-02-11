using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ISprite sprite;
        private ISprite text;
        private ITile tile;
        private Texture2D spriteTexture;
        private Texture2D textTexture;
        private Texture2D tileTexture;
        private IController kController;
        private IController mController;
        private ITile[] tileList;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            kController = new KeyboardController(this, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            mController = new MouseController(this, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteTexture = Content.Load<Texture2D>("zelda");
            textTexture = Content.Load<Texture2D>("creditsEdited");
            tileTexture = Content.Load<Texture2D>("bricks");
            text = new TextSprite(textTexture, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2 - 100), 0f);
            sprite = new IdleNonAnimatedSprite(spriteTexture, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), 0f);
            tile = new BrickTile(tileTexture, _spriteBatch, new Vector2(100, 100));
            tileList = new ITile[]
            {
                new BrickTile(Content.Load<Texture2D>("bricks"), _spriteBatch, new Vector2(100, 100)),
                new SandTile(Content.Load<Texture2D>("sandtile"), _spriteBatch, new Vector2(100, 100)),
                new SilverLinesTile(Content.Load<Texture2D>("silver lines"), _spriteBatch, new Vector2(100, 100)),
                new SolidBlackTile(Content.Load<Texture2D>("solid black tile"), _spriteBatch, new Vector2(100, 100)),
                new SolidBlueTile(Content.Load<Texture2D>("solid blue tile"), _spriteBatch, new Vector2(100, 100)),
                new SolidNavyTile(Content.Load<Texture2D>("solid navy tile"), _spriteBatch, new Vector2(100, 100)),
                new StairsTile(Content.Load<Texture2D>("stairs"), _spriteBatch, new Vector2(100, 100)),
                new StatueTile1(Content.Load<Texture2D>("statue1"), _spriteBatch, new Vector2(100, 100)),
                new StatueTile2(Content.Load<Texture2D>("statue2"), _spriteBatch, new Vector2(100, 100)),
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            kController.handleInput();
            mController.handleInput();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            sprite.draw();
            text.draw();
            tile.draw();
            

            base.Draw(gameTime);
        }

        public Texture2D SpriteTexture
        {
            get { return spriteTexture; } 
        }

        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; } 
        }
        
        public ISprite CurrentSprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        public ITile CurrentTile
        {
            get { return tile; }
            set { tile = value; }
        }

        public ITile[] TileList
        {
            get { return tileList; }
            set { tileList = value; }
        }
    }
}
