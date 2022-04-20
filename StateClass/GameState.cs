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
        private Texture2D fadeEffect;
        private DoorClass.DoorFactory.Side exitSide;
        bool fadeOut;
        private static int screenWidth = 1024;
        private static int screenHeight = 960-256;

        public GameState(Game1 game, ContentManager content) : base(game, content)
        {
            _game = game;
            _content = content;
            levelManager = LevelManager.Instance;
            levelManager.gameState = this;
        }
            
        public override void loadContent()
        {
            Vector2 center = new Vector2(_game.GraphicsDeviceManager.PreferredBackBufferWidth / 2, _game.GraphicsDeviceManager.PreferredBackBufferHeight / 2);
            levelManager.initialize(_game.SpriteBatch, _content, colliderDetector, center, _game.TwoPlayer);
            levelManager.LoadRooms();
            _currentRoom = levelManager.StartRoom();
            roomNum = levelManager.currentRoomNum;
            headsUpDisplay = new HUD(levelManager.Player1, _game.SpriteBatch, _content.Load<Texture2D>("HUDandInventory"));
            fadeEffect = new Texture2D(_game.GraphicsDevice, 1, 1);
            fadeEffect.SetData<Color>(new Color[] { Color.Black });
            //headsUpDisplay = new HUD(levelManager.Player2, _game.SpriteBatch, _content.Load<Texture2D>("HUDandInventory"));
            isTransitioning = false;
            isGameState = true;
        }

        public void startTransition(DoorClass.DoorFactory.Side side, int next, Room currentRoomObj) 
        {
            exitSide = side;
            previousRoom = roomNum;
            nextRoom = next;
            isTransitioning = true;
            roomNum = next;
            _currentRoom = currentRoomObj;
            fadeOut = true;
        }

        public override void update(GameTime gameTime)
        {
            if (!isTransitioning) { 

                _game.MouseController.handleInput();
                _game.KeyboardController.handleInput();

                if (levelManager.Player1.IsDead && levelManager.Player2.IsDead)
                {
                    _game.ChangeState(2);
                }
                if (levelManager.Player1.HasTriforce || levelManager.Player2.HasTriforce)
                {
                    _game.ChangeState(3);
                }

                _currentRoom.updateRoom();
            }
        }

        public void transitionRoom()
        {
            if (exitSide == DoorClass.DoorFactory.Side.Left)//left room
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
            else if (exitSide == DoorClass.DoorFactory.Side.Right)//right room
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
            else if (exitSide == DoorClass.DoorFactory.Side.Top)//top room
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
            else if (exitSide == DoorClass.DoorFactory.Side.Bottom)
            {
                levelManager.RoomList[previousRoom].drawRoom(0, offset, isTransitioning);
                levelManager.RoomList[nextRoom].drawRoom(0, offset + screenHeight, isTransitioning);
                offset = offset - 8;
                if (offset <= -screenHeight)
                {
                    isTransitioning = false;
                    offset = 0;
                }
            }
            else if (exitSide == DoorClass.DoorFactory.Side.Floor || exitSide == DoorClass.DoorFactory.Side.Ceiling) 
            {
                if (fadeOut)
                {
                    levelManager.RoomList[previousRoom].drawRoom(0, 0, isTransitioning);
                    offset = offset + 8;
                    if (offset >= 255) {
                        offset = 255;
                        fadeOut = false;
                    }
                }
                else {
                    levelManager.RoomList[nextRoom].drawRoom(0, 0, isTransitioning);
                    offset = offset - 8;
                    if (offset <= 0)
                    {
                        offset = 0;
                    }

                }
                _game.SpriteBatch.Begin();
                _game.SpriteBatch.Draw(fadeEffect, new Vector2(0, 0), null, new Color(0, 0, 0, offset), 0f, Vector2.Zero, new Vector2(_game.GraphicsDeviceManager.PreferredBackBufferWidth, _game.GraphicsDeviceManager.PreferredBackBufferHeight), SpriteEffects.None, 0);
                _game.SpriteBatch.End();
                if (offset <= 0 && fadeOut == false)
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


