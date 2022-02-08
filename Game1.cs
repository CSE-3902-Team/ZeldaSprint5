using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ISprite sprite;
        private ISprite text;
        private Texture2D spriteTexture;
        private Texture2D textTexture;
        private IController kController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            kController = new KeyboardController(this) ;
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteTexture = Content.Load<Texture2D>("zelda");
            textTexture = Content.Load<Texture2D>("creditsEdited");
            text = new TextSprite(textTexture, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2 - 100), 0f);
            sprite = new IdleNonAnimatedSprite(spriteTexture, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), 0f);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            kController.handleInput();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            sprite.draw();
            text.draw();
            


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

    }
}
