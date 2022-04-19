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
        private static int screenHeight = 960-256;

        public GameState(Game1 game, ContentManager content) : base(game, content)
        {
            _game = game;
            _content = content;
            levelManager = LevelManager.Instance;
        }
            
        public override void loadContent()
        {
            Vector2 center = new Vector2(_game.GraphicsDeviceManager.PreferredBackBufferWidth / 2, _game.GraphicsDeviceManager.PreferredBackBufferHeight / 2);
            levelManager.initialize(_game.SpriteBatch, _content, colliderDetector, center, _game.TwoPlayer);
            levelManager.LoadRooms();
            _currentRoom = levelManager.StartRoom();
            roomNum = levelManager.currentRoomNum;
            headsUpDisplay = new HUD(levelManager.Player1, _game.SpriteBatch, _content.Load<Texture2D>("HUDandInventory"));
            //headsUpDisplay = new HUD(levelManager.Player2, _game.SpriteBatch, _content.Load<Texture2D>("HUDandInventory"));
            isTransitioning = false;
            isGameState = true;
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

                if (_game.TwoPlayer == true)
                {
                    if (levelManager.Player1.IsDead && levelManager.Player2.IsDead)
                    {
                        _game.ChangeState(3);
                    }
                    if (levelManager.Player1.HasTriforce || levelManager.Player2.HasTriforce)
                    {
                        _game.ChangeState(4);
                    }
                }
                else
                {
                    if (levelManager.Player1.IsDead)
                    {
                        _game.ChangeState(3);
                    }
                    if (levelManager.Player1.HasTriforce)
                    {
                        _game.ChangeState(4);
                    }
                }

                _currentRoom.updateRoom();
            }
        }

        public void transitionRoom()
        {
            if (nextRoom == previousRoom - 1)//left room
            {
                levelManager.RoomList[previousRoom].drawRoom(offset, 0, isTransitioning);
                levelManager.RoomList[nextRoom].drawRoom(offset - screenWidth, 0, isTransitioning);
                offset = offset + 8;
                if (offset >= screenWidth)
                {
                    isTransitioning = false;
                    offset = 0;
                }
            }
            else if (nextRoom == previousRoom + 1)//right room
            {
                levelManager.RoomList[previousRoom].drawRoom(offset, 0, isTransitioning);
                levelManager.RoomList[nextRoom].drawRoom(offset + screenWidth, 0, isTransitioning);
                offset = offset - 8;
                if (offset <= -screenWidth)
                {
                    isTransitioning = false;
                    offset = 0;
                }
            }
            else if (nextRoom < previousRoom - 1)//top room
            {
                levelManager.RoomList[previousRoom].drawRoom(0, offset, isTransitioning);
                levelManager.RoomList[nextRoom].drawRoom(0, offset - screenHeight, isTransitioning);
                offset = offset + 8;
                if (offset >= screenHeight)
                {
                    isTransitioning = false;
                    offset = 0;
                }
            }
            else if (nextRoom > previousRoom + 1) {
                levelManager.RoomList[previousRoom].drawRoom(0, offset, isTransitioning);
                levelManager.RoomList[nextRoom].drawRoom(0, offset + screenHeight, isTransitioning);
                offset = offset - 8;
                if (offset <= -screenHeight)
                {
                    isTransitioning = false;
                    offset = 0;
                }
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


