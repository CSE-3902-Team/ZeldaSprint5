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
            }

            public override void update(GameTime gameTime)
            {
            
                if (roomNum != levelManager.currentRoomNum)
                {
                    _currentRoom = levelManager.CurrentRoom;            
                }
                //_game.MouseController.handleInput();
                //_game.KeyboardController.handleInput();
                if(levelManager.Player.IsDead)
                {
                    _game.ChangeState(new GameOverState(_game, _content));
                }
                _currentRoom.updateRoom();
        }


            public override void Draw(GameTime gameTime)
            {
                _currentRoom.drawRoom();
            }
        }
    }


