using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.ItemClass;
using Sprint0.LevelClass;
using Sprint0.StateClass;
using System;
using System.Collections.Generic;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private IController kController;
        private IController mController;

        private AState _currentState;
       
        private AState gameOver;
        private AState gameVictory;
        private AState gameInventory;
        private AState gameState;
        
        //private AState _nextState;
        //private AState _previousState;

        private SoundManager soundLibrary;

        private AItem item;

        private List<AState> stateList;

        private bool isTwoPlayer = true;



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
            kController = new KeyboardController(this, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            mController = new MouseController(this);
            soundLibrary = new SoundManager();

            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            stateList = new List<AState>();
            soundLibrary.LoadAllSounds(Content);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            gameState = new GameState(this, Content);
            gameState.loadContent();
            gameOver = new GameOverState(this, Content);
            gameOver.loadContent();
            gameVictory = new GameVictoryState(this, Content);
            gameVictory.loadContent();
            gameInventory = new GameInventoryState(this, Content);
            gameInventory.loadContent();

            stateList.Add(gameState);
            stateList.Add(gameInventory);
            stateList.Add(gameOver);
            stateList.Add(gameVictory);

            _currentState = stateList[0];
            //add main menu state to choose 1 or 2 player

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            /*
            if(_nextState != null && !_nextState.IsGameState)
            {
                Console.WriteLine("loading again");
                _currentState = _nextState;
                _nextState = null;
                _currentState.loadContent();
            }
            else if(_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            //kController.handleInput();
            //mController.handleInput();
            */

            _currentState.update(gameTime);
            base.Update(gameTime);
        }

        public void ChangeState(int stateNumber)
        {
           
            _currentState = stateList[stateNumber];
            
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            _currentState.Draw(gameTime);
            //_currentRoom.drawRoom();

            base.Draw(gameTime);

        }

        public void reset()
        {
            _currentState = null;
            soundLibrary.Dispose();
            LoadContent();
        }

        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; } 
        }
        
        /*
        public AState NextState
        {
            get { return _nextState; }
        }
        */

        public AState CurrentState
        {
            get { return _currentState; }
        }
        
        public AItem shownItem
        {
            get { return item; }
            set { item = value; }
        }

        
        public KeyboardController KeyboardController
        {
            get { return (KeyboardController)kController; }
        }

        public MouseController MouseController
        {
            get { return (MouseController)mController; }
        }

        public GraphicsDeviceManager GraphicsDeviceManager
        {
            get { return _graphics; }
        }

        public bool TwoPlayer
        {
            get { return isTwoPlayer; }
        }
    }
}
