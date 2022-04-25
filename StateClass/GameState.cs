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
        bool linkMoved;
        bool darkEffect;
        private static int screenWidth = 1024;
        private static int heightOffset = 256;
        private static int screenHeight = 960-heightOffset;

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
            headsUpDisplay = new HUD(_game.SpriteBatch, _content.Load<Texture2D>("HUDandInventory"));
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
                if (exitSide == DoorClass.DoorFactory.Side.Floor)
                {
                    fadeTransition(new Vector2(227, 300));                    
                } else {
                    fadeTransition(new Vector2(474, 609));
                }
            }
        }

        private void fadeTransition(Vector2 linkSpawnLocation) {
            if (fadeOut)
            {
                linkMoved = false;
                levelManager.RoomList[previousRoom].drawRoom(0, 0, isTransitioning);
                offset = offset + 8;
                if (offset >= 255)
                {
                    offset = 255;
                    fadeOut = false;
                }
            }
            else
            {
                if (linkMoved == false) {
                    LevelManager.Instance.Player1.Position = linkSpawnLocation;
                    if (LevelManager.Instance.TwoPlayer)
                    {
                        LevelManager.Instance.Player2.Position = linkSpawnLocation;
                    }
                    if (roomNum == 1)
                    {
                        darkEffect = true;
                    }
                    else {
                        darkEffect = false;
                    }
                }
                linkMoved = true;
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


        public override void Draw(GameTime gameTime)
        {
            if (isTransitioning)
            {
                transitionRoom();
            }
            else {
                _currentRoom.drawRoom();
            }
            _game.SpriteBatch.Begin();
            if(darkEffect) {
                _game.SpriteBatch.Draw(generateDarkRoom(), new Vector2(0, heightOffset), Color.White);
            }
            _game.SpriteBatch.End();
            headsUpDisplay.Draw();
        }

        public Texture2D generateDarkRoom() {
            //initialize a texture
            Texture2D texture = new Texture2D(_game.GraphicsDevice, screenWidth, screenHeight);
            int radius = 128;
            //the array holds the color for each pixel in the texture
            Color[] data = new Color[screenWidth * screenHeight];
            Array.Fill(data, Color.Black);
            Vector2 pixelVector = new Vector2(0,0);
            Vector2 linkPosition1 = LevelManager.Instance.Player1.Position;
            Vector2 linkPosition2 = new Vector2(5000, 5000);
            
            linkPosition1.Y = linkPosition1.Y - heightOffset;
            float distance1 = 0;
            int pixelSequence = 0;
            if (!LevelManager.Instance.Player1.IsDead)
            {
                for (int x = (int)linkPosition1.X - radius; x < (int)linkPosition1.X + radius; x++)
                {
                    for (int y = (int)linkPosition1.Y - radius; y < (int)linkPosition1.Y + radius; y++)
                    {
                        pixelSequence = y * screenWidth + x;
                        distance1 = Vector2.Distance(new Vector2(x, y), linkPosition1);
                        if (distance1 < radius)
                        {
                            if (pixelSequence < data.Length - 1 && pixelSequence >= 0) {
                                data[pixelSequence] = new Color((byte)0, (byte)0, (byte)0, (byte)(distance1) * 2);
                            }
                        }
                    }
                }
            }

            if (_game.TwoPlayer == true && !LevelManager.Instance.Player2.IsDead)
            {
                linkPosition2 = LevelManager.Instance.Player2.Position;
                linkPosition2.Y = linkPosition2.Y - heightOffset;
                float distance2 = 500;
                for (int x = (int)linkPosition2.X - radius; x < (int)linkPosition2.X + radius; x++)
                {
                    for (int y = (int)linkPosition2.Y - radius; y < (int)linkPosition2.Y + radius; y++)
                    {
                        pixelSequence = y * screenWidth + x;
                        distance2 = Vector2.Distance(new Vector2(x, y), linkPosition2);
                        if (distance2 < radius)
                        {
                            if (pixelSequence < data.Length - 1 && pixelSequence >= 0)
                            {
                                if (data[pixelSequence].A > distance2 * 2) {
                                    data[pixelSequence] = new Color((byte)0, (byte)0, (byte)0, (byte)(distance2) * 2);
                                }
                            }
                        }
                    }
                }
            }

            /*for (int pixel = 0; pixel < data.Length; pixel++)
            {
                pixelVector = new Vector2(pixel % screenWidth, (int)(pixel/screenWidth));
                //the function applies the color according to the specified pixel
                distance1 = Vector2.Distance(pixelVector, linkPosition1);
                if (_game.TwoPlayer == true)
                {
                    distance2 = Vector2.Distance(pixelVector, linkPosition2);
                }
                if ( distance1 < 128 || distance2 < 128) {

                    data[pixel] = new Color((byte)0, (byte)0, (byte)0, (byte)((Math.Min(distance1, distance2)) * 2));
                }
            }*/

            //set the color
            texture.SetData(data);

            return texture;
        }
    }
}


