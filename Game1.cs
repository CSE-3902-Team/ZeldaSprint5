using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Collision;
using Sprint0.enemy;
using Sprint0.ItemClass;
using Sprint0.TileClass;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private ITile roomWalls;

        private IController kController;

        private ITile tile;
        private Texture2D tileTexture;
        private ITile[] tileList;

        private Texture2D playerTexture;
        private Texture2D projectileTexture;

        private Texture2D enemyTexture;
        private Texture2D dragonTexture;
        private Texture2D npcTexture;
        private Texture2D whiteRectangle;

        private ICollision colliderDector;
        private IEnemySprite enemySprite;
        private IEnemySprite[] EnemyList;

        private ItemSpriteFactory itemFactory;
        private AItem item;
        private Player _player;
        private ITile tile1;
        private ITile tile2;

        private Vector2 temp;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 704;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            // TODO: Add your initialization logic here
            kController = new KeyboardController(this, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            itemFactory = ItemSpriteFactory.Instance;
            colliderDector = new SortSweep(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            temp.X = 400;
            temp.Y = 200;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tileTexture = Content.Load<Texture2D>("bricks");
            playerTexture = Content.Load<Texture2D>("playerSheet");
            projectileTexture = Content.Load<Texture2D>("itemsAndWeapons1");
            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.Black });
            tile = new BrickTile(tileTexture, _spriteBatch, new Vector2(128, 128));
            tileList = new ITile[]
            {
                new BrickTile(Content.Load<Texture2D>("bricks"), _spriteBatch, new Vector2(128, 128)),
                new SandTile(Content.Load<Texture2D>("sandtile"), _spriteBatch, new Vector2(128, 128)),
                new SilverLinesTile(Content.Load<Texture2D>("silverlines"), _spriteBatch, new Vector2(128, 128)),
                new SolidBlackTile(Content.Load<Texture2D>("solid black tile"), _spriteBatch, new Vector2(128, 128)),
                new SolidBlueTile(Content.Load<Texture2D>("solid blue tile"), _spriteBatch, new Vector2(128, 128)),
                new SolidNavyTile(Content.Load<Texture2D>("solid navy tile"), _spriteBatch, new Vector2(128, 128)),
                new StairsTile(Content.Load<Texture2D>("stairs"), _spriteBatch, new Vector2(128, 128)),
                new StatueTile1(Content.Load<Texture2D>("statue1"), _spriteBatch, new Vector2(128, 128)),
                new StatueTile2(Content.Load<Texture2D>("statue2"), _spriteBatch, new Vector2(128, 128)),
                new StatueTile2(Content.Load<Texture2D>("tile with square in middle"), _spriteBatch, new Vector2(128, 128)),
                new LeftFire(Content.Load<Texture2D>("LeftFire"), _spriteBatch, new Vector2(128, 128)),
                new RightFire(Content.Load<Texture2D>("RightFire"), _spriteBatch, new Vector2(128, 128)),
                new Text(Content.Load<Texture2D>("textsprite"), _spriteBatch, new Vector2(128, 128))
            };
            roomWalls = new RoomWalls(Content.Load<Texture2D>("roomwalls"), _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));


            _player = new Player(playerTexture, _spriteBatch, new ProjectileBomb(projectileTexture, _spriteBatch, new Vector2(140, 200), new Vector2(1, 0)), new Vector2(100, 200), Content.Load<Texture2D>("solid navy tile"));



            //load everything with the items shown on screen
            itemFactory.LoadAllTextures(Content);
            itemFactory.setBatchPosition(_spriteBatch, new Vector2(300, 100));
            item = itemFactory.CreateItemSprite(ItemSpriteFactory.Item.Compass);

            enemyTexture = Content.Load<Texture2D>("Enemy");
            npcTexture = Content.Load<Texture2D>("oldman1");
            dragonTexture = Content.Load<Texture2D>("dragon");
            enemySprite = new enemySkeleton(enemyTexture, _spriteBatch, temp);
            EnemyList = new IEnemySprite[] {

            new enemyGel(enemyTexture, _spriteBatch, temp),
            new enemyGoriya(enemyTexture, _spriteBatch,temp),
            new enemyBat(enemyTexture, _spriteBatch,temp),
            new enemyHand(enemyTexture, _spriteBatch,temp),
            new enemySkeleton(enemyTexture, _spriteBatch,temp),
             new oldMan(npcTexture, _spriteBatch,temp),
             new bossDragon(dragonTexture, _spriteBatch,temp)
            };
            tile1 = new SolidNavyTile(Content.Load<Texture2D>("solid navy tile"), _spriteBatch, new Vector2(440, 400));

            tile2 = new SolidNavyTile(Content.Load<Texture2D>("solid navy tile"), _spriteBatch, new Vector2(300, 400));
            colliderDector.AddToList(tile1 as IBoxCollider);
            colliderDector.AddToList(tile2 as IBoxCollider);

            colliderDector.AddToList(_player);




        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            kController.handleInput();
            _player.Update();
            currentEnemy.Update();
            colliderDector.HandleCollisions();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            roomWalls.draw();
            tile.draw();
            Player.Draw();
            // TODO: Add your drawing code here
            shownItem.draw();
            //enemySprite.draw();


            tile1.draw();

            tile2.draw();
            enemySprite.draw();
            EnemyList = new IEnemySprite[] {
            new enemyGel(enemyTexture, _spriteBatch, temp),
            new enemyGoriya(enemyTexture, _spriteBatch,temp),
            new enemyBat(enemyTexture, _spriteBatch,temp),
            new enemyHand(enemyTexture, _spriteBatch,temp),
            new enemySkeleton(enemyTexture, _spriteBatch,temp),
            new oldMan(npcTexture, _spriteBatch,temp),
               new bossDragon(dragonTexture, _spriteBatch,temp)
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

        public Texture2D ProjectileTexture { get { return projectileTexture; } }

        public void reset()
        {
            LoadContent();
        }

    }
}
