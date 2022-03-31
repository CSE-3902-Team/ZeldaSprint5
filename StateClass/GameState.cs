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
            private Game1 _game;
            private ContentManager _content;
            private Room _currentRoom;
            public GameState(Game1 game, ContentManager content) : base(game, content)
            {
                _game = game;
                _content = content;

            }
            public override void loadContent()
            {
                Vector2 center = new Vector2(_game.GraphicsDeviceManager.PreferredBackBufferWidth / 2, _game.GraphicsDeviceManager.PreferredBackBufferHeight / 2);
                _game.LevelManager.initialize(_game.SpriteBatch, _content, _game.ColliderDetector, center);
                _game.LevelManager.LoadRooms();
                _currentRoom = _game.LevelManager.StartRoom();

            }

            public override void update(GameTime gameTime)
            {
                _game.MouseController.handleInput();
                _game.KeyboardController.handleInput();
                _currentRoom.updateRoom();
        }


            public override void Draw(GameTime gameTime)
            {
                _currentRoom.drawRoom();
            }
        }
    }


