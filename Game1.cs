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

        private IController kController;

        private ITile tile;
        private Texture2D tileTexture;
        private ITile[] tileList;

        private Texture2D playerTexture;
        private Texture2D projectileTexture;
        
        private Texture2D enemyTexture;
        private IEnemySprite enemySprite;
        private IEnemySprite[] EnemyList;

        private ItemSpriteFactory itemFactory;
        private AItem item;
        private Player _player;

        private Vector2 temp;
        private Texture2D items;


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
            itemFactory = ItemSpriteFactory.Instance;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            temp.X = 400;
            temp.Y = 200;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tileTexture = Content.Load<Texture2D>("bricks");
            playerTexture = Content.Load<Texture2D>("playerSheet");
            projectileTexture = Content.Load<Texture2D>("ItemsAndWeapons1");
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

            _player = new Player(playerTexture, _spriteBatch, new ProjectileBomb(projectileTexture, _spriteBatch, new Vector2(140, 200), new Vector2(1, 0)));

            //load everything with the items shown on screen
            itemFactory.LoadAllTextures(Content);
            itemFactory.setBatchPosition(_spriteBatch, new Vector2(300, 100));
            item = itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Compass);
            enemyTexture = Content.Load<Texture2D>("DungeonEnemy");
            enemyTexture = Content.Load<Texture2D>("DungeonEnemy");
            enemySprite = new EnemyDarkLord(enemyTexture, _spriteBatch, temp);
            EnemyList = new IEnemySprite[] {
            new EnemyDarkLord(enemyTexture, _spriteBatch, temp),
            new enemyGel(enemyTexture, _spriteBatch, temp),
            new enemyGoriya(enemyTexture, _spriteBatch,temp),
            new enemyBat(enemyTexture, _spriteBatch,temp)
            };
            items = Content.Load<Texture2D>("itemsAndWeapons1");
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
            _player.Update();
            shownItem.draw();
            //enemySprite.draw();
            tile.draw();
            EnemyList = new IEnemySprite[]
            {
          new EnemyDarkLord(enemyTexture, _spriteBatch,temp),
          new enemyGel(enemyTexture, _spriteBatch,temp),
          new enemyGoriya(enemyTexture, _spriteBatch,temp),
          new enemyBat(enemyTexture, _spriteBatch,temp)
            };
            base.Draw(gameTime);
        }

        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; } 
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
        public AItem shownItem
        {
            get { return item; }
            set { item = value; }
        }
        public IEnemySprite currentEnemy
        {
            get { return enemySprite; }
            set { enemySprite = value; }
        }
        public IEnemySprite[] enemyList
        {
            get { return EnemyList; }
            set { EnemyList = value; }
        }
        public ItemSpriteFactory itemFactoryPublic
        {
            get { return itemFactory; }
            set { itemFactory = value; }
        }

        public Player Player
        {
            get { return _player; }
        }

        public Texture2D ProjectileTexture { get {return projectileTexture; } }

        public void reset() {
            LoadContent();
        }

    }
}
