using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.ItemClass;
using Sprint0.LevelClass;
using System;

namespace Sprint0.StateClass
{
    public class GameState: AState
    {
        private LevelManager levelManager;
        private ICollision colliderDetector;
        private int roomNum;
        private HUD headsUpDisplay;
        private bool isTransitioning;
        private int previousRoom;
        private int nextRoom;
        private int offset;
        private static int screenWidth = 1024;

        public GameState(Game1 game, ContentManager content) : base(game, content)
        {
            _game = game;
            _content = content;
            levelManager = LevelManager.Instance;
        }
            
        public override void loadContent()
        {
            Vector2 center = new Vector2(_game.GraphicsDeviceManager.PreferredBackBufferWidth / 2, _game.GraphicsDeviceManager.PreferredBackBufferHeight / 2);
            levelManager.initialize(_game.SpriteBatch, _content, colliderDetector, center);
            levelManager.LoadRooms();
            _currentRoom = levelManager.StartRoom();
            roomNum = levelManager.currentRoomNum;
            headsUpDisplay = new HUD(levelManager.Player, _game.SpriteBatch, _content.Load<Texture2D>("HUD"), _content.Load<Texture2D>("Hearts"));
            isTransitioning = false;
        }

        public override void update(GameTime gameTime)
        {
            if (!isTransitioning) { 
                if (roomNum != levelManager.currentRoomNum)
                {
                    previousRoom = roomNum;
                    nextRoom = levelManager.currentRoomNum;
                    isTransitioning = true;
                    roomNum = levelManager.currentRoomNum;
                    _currentRoom = levelManager.CurrentRoom;
                }
                _game.MouseController.handleInput();
                _game.KeyboardController.handleInput();
                if (levelManager.Player.IsDead)
                {
                    _game.ChangeState(new GameOverState(_game, _content));
                }
                _currentRoom.updateRoom();
            }
        }

        public void transitionRoom() {
            levelManager.RoomList[previousRoom].drawRoom(offset, 0);
            levelManager.RoomList[nextRoom].drawRoom(offset-screenWidth, 0);
            offset = offset + 8;
            if (offset >= screenWidth) 
            {
                isTransitioning = false;
                offset = 0;
            }
        }


        public override void Draw(GameTime gameTime)
        {

            if (isTransitioning)
            {
                transitionRoom();
            }
            else {
                _currentRoom.drawRoom();
            }
            headsUpDisplay.Draw();
        }
    }
}


