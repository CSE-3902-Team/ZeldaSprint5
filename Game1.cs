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
        private IController mController;

        private IProjectile projectile;
        private Texture2D items;
        private Vector2 bombPos;

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

            bombPos = new Vector2(500, 300);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteTexture = Content.Load<Texture2D>("zelda");
            textTexture = Content.Load<Texture2D>("creditsEdited");
            items = Content.Load<Texture2D>("itemsAndWeapons1");
            text = new TextSprite(textTexture, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2 - 100), 0f);
            sprite = new IdleNonAnimatedSprite(spriteTexture, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), 0f);
            projectile = new BombProjectile(items, _spriteBatch, bombPos, 1f);
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
            projectile.draw(bombPos, 0, 0);

            


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
