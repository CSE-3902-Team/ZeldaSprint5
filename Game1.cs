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
        
        private AState menuState;


        private SoundManager soundLibrary;

        private AItem item;

        private List<AState> stateList;

        private bool isTwoPlayer = false;



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

            menuState = new GameMenuState(this, Content);
            menuState.loadContent();

            stateList.Add(menuState);
            _currentState = stateList[0];

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            _currentState.update(gameTime);
            base.Update(gameTime);
        }

        public void LoadStates()
        {
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

        }
        public void ChangeState(int stateNumber)
        {
            _currentState = stateList[stateNumber];
            
        }

        protected override void Draw(GameTime gameTime)
        {
            _currentState.Draw(gameTime);

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

        public SoundManager SoundManager
        {
            get { return soundLibrary; }
        }

        public bool TwoPlayer
        {
            get { return isTwoPlayer; }
            set { isTwoPlayer = value; }
        }
    }
}
