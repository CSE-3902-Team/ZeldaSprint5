using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.ItemClass;
using Sprint0.LevelClass;
using Sprint0.StateClass;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private IController kController;

        private ICollision colliderDector; 

        private LevelManager levelManager;

        private IController mController;

        private AState _currentState;
        private AState _nextState;

        private AItem item;
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
            _graphics.PreferredBackBufferHeight = 960; 
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            // TODO: Add your initialization logic here
            levelManager = LevelManager.Instance;
            kController = new KeyboardController(this, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            mController = new MouseController(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentState = new GameState(this, Content);
            _nextState = null;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
                _currentState.loadContent();
                
            }
            if (_nextState == null)
            {
                _currentState.loadContent();
                //_currentRoom.updateRoom();
            }
            _currentState.update(gameTime);
            base.Update(gameTime);
        }

        public void ChangeState(AState state)
        {
            _nextState = state;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _currentState.Draw(gameTime);
            //_currentRoom.drawRoom();

            base.Draw(gameTime);

        }

        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; } 
        }
        
        public AState NextState
        {
            get { return _nextState; }
        }

        public AState CurrentState
        {
            get { return _currentState; }
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

        public LevelManager LevelManager
        {
            get { return levelManager; }
        }

        public KeyboardController KeyboardController
        {
            get { return (KeyboardController)kController; }
        }

        public MouseController MouseController
        {
            get { return (MouseController)mController; }
        }

        public ICollision ColliderDetector
        {
            get { return colliderDector; }
        }

        public GraphicsDeviceManager GraphicsDeviceManager
        {
            get { return _graphics; }
        }

    }
}
