using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.TileClass;
using Sprint0.ItemClass;
using Sprint0.Collision;
using Sprint0.PlayerClass;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Sprint0.enemy;
using Sprint0.DoorClass;
using Sprint0.LevelClass;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private ITile roomWalls;

        private IController kController;

        private ICollision colliderDector;

        private LevelManager levelManager;

        
        private AItem item;
        private ITile tile1; 
        private ITile tile2;
        private Room _currentRoom;



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
            levelManager = LevelManager.Instance;
            kController = new KeyboardController(this, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            

            base.Initialize();
        }

        protected override void LoadContent()
        { 
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            Vector2 center = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            levelManager.initialize(_spriteBatch, Content, colliderDector, center);
            _currentRoom = levelManager.StartRoom();





        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            kController.handleInput();
            _currentRoom.updateRoom();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _currentRoom.drawRoom();
            
            base.Draw(gameTime);

        }

        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; } 
        }
        

        
        public AItem shownItem
        {
            get { return item; }
            set { item = value; }
        }
    
        public void reset() {
            LoadContent();
        }

        public Room CurrentRoom {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }

    }
}
