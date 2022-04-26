using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.LevelClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.StateClass
{
    public class GameInventoryState : AState
    {
        private const int WIDTH = 1024;
        private const int HEIGHT = 960;
        private const int MAX_HEART_COUNT = 5;
        private Game1 _game;
        private ContentManager _content;
        private Texture2D screen;
        private LinkInventory _inventory;
        private LevelManager _levelManager;
        private int locationSquareX;
        private int locationSquareY;

        private Rectangle heartSourceRect;
        private Rectangle halfHeartSourceRect;
        private Rectangle emptyHeartSourceRect;
        private Rectangle timesSymbolSourceRect;
        private Rectangle mapSourceRect;
        private Rectangle mapDesignSourceRect;
        private Rectangle compassSourceRect;
        private Rectangle redBoxSourceRect;
        private Rectangle blueBoxSourceRect;
        private Rectangle swordSourceRect;
        private Rectangle boomerangSourceRect;
        private Rectangle specialBoomerangSourceRect;
        private Rectangle bombSourceRect;
        private Rectangle arrowSourceRect; 
        private Rectangle specialArrowSourceRect;
        private Rectangle bowSourceRect;

        private Rectangle currentHeartNeeded;
        private Rectangle rupeeNumberDestRect;
        private Rectangle bombNumberDestRect;
        private Rectangle keyNumberDestRect;
        private Rectangle levelNumberDestRect;
        private Rectangle slotADestRect;
        private Rectangle slotBDestRect;
        private Rectangle mapDestRect;
        private Rectangle mapDesignDestRect;
        private Rectangle compassDestRect;
        private Rectangle otherMapSourceRect;
        private Rectangle otherMapDestRect;
        private Rectangle locationSquareSourceRect;
        private Rectangle locationSquareDestRect;
        private Rectangle boxDestRect;
        private Rectangle currentB_SlotItemSourceRect;
        private Rectangle itemSelectionSlot;
        private Rectangle boomerangDestRect;
        private Rectangle specialBoomerangDestRect;
        private Rectangle bombDestRect;
        private Rectangle arrowDestRect;
        private Rectangle bowDestRect;
        private Rectangle selectedItem;
        private Rectangle triforceSquareDestLocation;
        private Rectangle triforceMiniMapSquareDestLocation;
        private Rectangle candleSourceRect;
        private Rectangle candleDestRect;
        private Vector2 boxPosition;


        const int heartWidth = 64;
        const int heartHeight = 73;
        const int spaceBetweenHearts = 8;

        const int numberWidth = 33;
        const int numberHeight = 37;
        const int spaceBetweenNumbers = 5;

        const int mapWidth = 39;
        const int mapAndCompassHeight = 83;
        const int compassWidth = 74;
        const int mapDesignHeightAndWidth = 275;
        const int otherMapWidth = 278;
        const int otherMapHeight = 200;

        const int locationSquareSize = 20;

        const int slotWidth = 46;
        const int slotHeight = 85;
        const int colorBoxesWidth = 80;
        const int colorBoxesHeight = 82;

        const int swordWidth = 41;
        const int swordHeight = 85;

        const int boomerangWidth = 40;
        const int boomerangHeight = 60;

        const int bombWidth = 45;
        const int bombHeight = 75;

        const int arrowWidth = 30;
        const int arrowHeight = 85;

        const int bowWidth = 50;
        const int bowHeight = 90;

        const int candleWidth = 44;
        const int candleHeight = 88;

        const int inventorySlotsWidth = 90;
        const int inventorySlotsHeight = 65;

        const int itemSelectionSlotSize = 70;

        const int heartAndNumberYSourceLocation = 1142;
        const int timesSymbolYSourceLocation = 1178;
        const int compassAndMapYSourceLocation = 1059;
        const int mapDesignYSourceLocation = 1215;
        const int numberXSourceLocation = 208;
        const int mapXSourceLocation = 403;
        const int compassXSourceLocation = 457;
        const int otherMapXSourceLocation = 288;
        const int locationSquareXSourceLocation = 395;
        const int locationSquareYSourceLocation = 1440;
        const int itemsRowYSourceLocation = 961;
        const int swordXSourceLocation = 173;
        const int blueSquareXSourceLocation = 82;
        const int boomerangXSourceLocation = 315;
        const int specialBoomerangXSourceLocation = 360;
        const int bombXSourceLocation = 415;
        const int arrowXSourceLocation = 475;
        const int specialArrowXSourceLocation = 520;
        const int bowXSourceLocation = 556;
        const int boomerangYSourceLocation = 972;
        const int triforceLocationX = 733;
        const int triforceLocationY = 428;
        const int triforceMiniMapLocationX = 269;
        const int triforceMiniMapLocationY = 809;
        const int candleSourceLocationX = 660;

        const int itemsInventoryXDestLocation = 505;
        const int itemsInventoryYDestLocation = 180;
        const int heartXDestLocation = 706;
        const int slotA_XDestLocation = 602;
        const int slotB_XDestLocation = 505;
        const int numberXDestLocation = 384;
        const int mapAndCompassXDestLocation = 180;
        const int mapDesignXDestLocation = 500;
        const int levelNumberXDestLocation = 135;
        const int otherMapXDestLocation = 26;
        const int itemSelectionSlotXDestLocation = 250;
        const int itemSelectionSlotYDestLocation = 180;

        const int heartYDestLocation = 854;
        const int slotsYDestLocation = 815;
        const int rupeeYDestLocation = 781;
        const int keyYDestLocation = 854;
        const int bombYDestLocation = 890;
        const int mapYDestLocation = 420;
        const int compassYDestLocation = 590;
        const int mapDesignYDestLocation = 370;
        const int levelNumberYDestLocation = 707;
        const int otherMapYDestLocation = 748;

        private int frame;
        private int currentItemIndexRow;
        private int currentItemIndexColumn;
        private readonly LinkInventory.Items[,] itemPositionIndex;
        private LinkInventory.Items currentB_slot_item;

        public Vector2 InventoryBoxPosition
        {
            get { return boxPosition; }
            set { boxPosition = value; }
        }
        public LinkInventory.Items CurrentB_Slot_Item
        {
            get { return currentB_slot_item; }
        }
        public GameInventoryState(Game1 game, ContentManager content) : base(game, content)
        {
            _game = game;
            _content = content;
            _levelManager = LevelManager.Instance;
            _inventory = _levelManager.Player1.Inventory;
            locationSquareX = _inventory.MapLocationX;
            locationSquareY = _inventory.MapLocationY;
            boxPosition = new Vector2(itemsInventoryXDestLocation, itemsInventoryYDestLocation);

            heartSourceRect = new Rectangle((heartWidth * 2) + (spaceBetweenHearts * 2), heartAndNumberYSourceLocation, heartWidth, heartHeight);
            halfHeartSourceRect = new Rectangle((heartWidth * 1) + (spaceBetweenHearts * 1), heartAndNumberYSourceLocation, heartWidth, heartHeight);
            emptyHeartSourceRect = new Rectangle((heartWidth * 0) + (spaceBetweenHearts * 0), heartAndNumberYSourceLocation, heartWidth, heartHeight);
            timesSymbolSourceRect = new Rectangle(numberXSourceLocation, timesSymbolYSourceLocation, numberWidth, numberHeight);
            mapSourceRect = new Rectangle(mapXSourceLocation, compassAndMapYSourceLocation, mapWidth, mapAndCompassHeight);
            mapDesignSourceRect = new Rectangle(0, mapDesignYSourceLocation, mapDesignHeightAndWidth, mapDesignHeightAndWidth);
            compassSourceRect = new Rectangle(compassXSourceLocation, compassAndMapYSourceLocation, compassWidth, mapAndCompassHeight);
            otherMapSourceRect = new Rectangle(otherMapXSourceLocation, mapDesignYSourceLocation, otherMapWidth, otherMapHeight);
            locationSquareSourceRect = new Rectangle(locationSquareXSourceLocation, locationSquareYSourceLocation, locationSquareSize, locationSquareSize);
            redBoxSourceRect = new Rectangle(0, itemsRowYSourceLocation, colorBoxesWidth, colorBoxesHeight);
            blueBoxSourceRect = new Rectangle(blueSquareXSourceLocation, itemsRowYSourceLocation, colorBoxesWidth, colorBoxesHeight);
            swordSourceRect = new Rectangle(swordXSourceLocation, itemsRowYSourceLocation, swordWidth, swordHeight);
            boomerangSourceRect = new Rectangle(boomerangXSourceLocation, boomerangYSourceLocation, boomerangWidth, boomerangHeight);
            bombSourceRect = new Rectangle(bombXSourceLocation, itemsRowYSourceLocation, bombWidth, bombHeight);
            arrowSourceRect = new Rectangle(arrowXSourceLocation, itemsRowYSourceLocation, arrowWidth, arrowHeight);
            specialArrowSourceRect = new Rectangle(specialArrowXSourceLocation, itemsRowYSourceLocation, arrowWidth, arrowHeight);
            bowSourceRect = new Rectangle(bowXSourceLocation, itemsRowYSourceLocation, bowWidth, bowHeight);
            specialBoomerangSourceRect = new Rectangle(specialBoomerangXSourceLocation, boomerangYSourceLocation, boomerangWidth, boomerangHeight);
            candleSourceRect = new Rectangle(candleSourceLocationX, itemsRowYSourceLocation, candleWidth, candleHeight);

            rupeeNumberDestRect = new Rectangle(numberXDestLocation, rupeeYDestLocation, numberWidth, numberHeight);
            bombNumberDestRect = new Rectangle(numberXDestLocation, bombYDestLocation, numberWidth, numberHeight);
            keyNumberDestRect = new Rectangle(numberXDestLocation, keyYDestLocation, numberWidth, numberHeight);
            levelNumberDestRect = new Rectangle(levelNumberXDestLocation, levelNumberYDestLocation, numberWidth, numberHeight);
            slotADestRect = new Rectangle(slotA_XDestLocation, slotsYDestLocation, slotWidth, slotHeight);
            slotBDestRect = new Rectangle(slotB_XDestLocation, slotsYDestLocation, slotWidth, slotHeight);
            mapDestRect = new Rectangle(mapAndCompassXDestLocation, mapYDestLocation, mapWidth, mapAndCompassHeight);
            mapDesignDestRect = new Rectangle(mapDesignXDestLocation, mapDesignYDestLocation, mapDesignHeightAndWidth, mapDesignHeightAndWidth);
            compassDestRect = new Rectangle(mapAndCompassXDestLocation - 8, compassYDestLocation, compassWidth, mapAndCompassHeight);
            otherMapDestRect = new Rectangle(otherMapXDestLocation, otherMapYDestLocation, otherMapWidth, otherMapHeight);
            locationSquareDestRect = new Rectangle(locationSquareX, locationSquareY, locationSquareSize, locationSquareSize);
            triforceSquareDestLocation = new Rectangle(triforceLocationX, triforceLocationY, locationSquareSize, locationSquareSize);
            triforceMiniMapSquareDestLocation = new Rectangle(triforceMiniMapLocationX, triforceMiniMapLocationY, locationSquareSize, locationSquareSize);
            boxDestRect = new Rectangle((int)InventoryBoxPosition.X, (int)InventoryBoxPosition.Y, inventorySlotsWidth, inventorySlotsHeight);

            boomerangDestRect = new Rectangle(itemsInventoryXDestLocation + 20, itemsInventoryYDestLocation, boomerangWidth, boomerangHeight);
            bombDestRect = new Rectangle((itemsInventoryXDestLocation + (inventorySlotsWidth * 1)) + 20, itemsInventoryYDestLocation, bombWidth, inventorySlotsHeight);
            arrowDestRect = new Rectangle((itemsInventoryXDestLocation + (inventorySlotsWidth * 2)), itemsInventoryYDestLocation, arrowWidth, inventorySlotsHeight);
            bowDestRect = new Rectangle((itemsInventoryXDestLocation + (inventorySlotsWidth * 2) + arrowWidth), itemsInventoryYDestLocation, (inventorySlotsWidth - arrowWidth), inventorySlotsHeight);
            specialBoomerangDestRect = new Rectangle((itemsInventoryXDestLocation + (inventorySlotsWidth * 3) + 20), itemsInventoryYDestLocation, boomerangWidth, boomerangHeight);
            candleDestRect = new Rectangle(itemsInventoryXDestLocation + 20, itemsInventoryYDestLocation + inventorySlotsHeight, candleWidth, inventorySlotsHeight);

            currentB_SlotItemSourceRect = new Rectangle(10, 10, 0, 0);
            itemSelectionSlot = new Rectangle(itemSelectionSlotXDestLocation, itemSelectionSlotYDestLocation, itemSelectionSlotSize, itemSelectionSlotSize);
            selectedItem = new Rectangle(10, 10, 0, 0);

            currentItemIndexRow = (int)((InventoryBoxPosition.X - itemsInventoryXDestLocation) / inventorySlotsWidth);
            currentItemIndexColumn = (int)((InventoryBoxPosition.Y - itemsInventoryYDestLocation) / inventorySlotsHeight);

            itemPositionIndex = _inventory.ItemPositionIndex;
            currentB_slot_item = _inventory.ItemPositionIndex[currentItemIndexRow, currentItemIndexColumn];
            frame = 0;

        }

        public void MoveBox(int x, int y, Keys key)
        {
            int topOfInventory = 180;
            int bottomOfInventory = 245;
            int leftMostOfInventory = 505;
            int rightMostOfInventory = 775;

            if (key.Equals(Keys.Up))
            {
                if (InventoryBoxPosition.Y - inventorySlotsHeight >= topOfInventory)
                {

                    boxPosition.Y += y * inventorySlotsHeight;

                }
            }
            if (key.Equals(Keys.Left))
            {
                if (InventoryBoxPosition.X - inventorySlotsWidth >= leftMostOfInventory)
                {

                    boxPosition.X += x * inventorySlotsWidth;

                }
            }
            if (key.Equals(Keys.Down))
            {
                if (InventoryBoxPosition.Y + inventorySlotsHeight <= bottomOfInventory)
                {

                    boxPosition.Y += y * inventorySlotsHeight;

                }
            }
            if (key.Equals(Keys.Right))
            {
                if (InventoryBoxPosition.X + inventorySlotsWidth <= rightMostOfInventory)
                {

                    boxPosition.X += x * inventorySlotsWidth;
                }
            }
        }

        public void DrawInventoryItems()
        {
            if (frame % 50 > 20)
            {
                _game.SpriteBatch.Draw(screen, boxDestRect, redBoxSourceRect, Color.White);
            }
            if (_inventory.Boomerang)
            {
                _game.SpriteBatch.Draw(screen, boomerangDestRect, boomerangSourceRect, Color.White);
            }
            if (_inventory.BombCount > 0)
            {
                _game.SpriteBatch.Draw(screen, bombDestRect, bombSourceRect, Color.White);
            }
            if (_inventory.SpecialBoomerang)
            {
                _game.SpriteBatch.Draw(screen, specialBoomerangDestRect, specialBoomerangSourceRect, Color.White);
            }
            if (_inventory.Candle)
            {
                _game.SpriteBatch.Draw(screen, candleDestRect, candleSourceRect, Color.White);
            }
            if (_inventory.Bow)
            {
                _game.SpriteBatch.Draw(screen, bowDestRect, bowSourceRect, Color.White);
                if (_inventory.RupeeCount > 0 && _inventory.SpecialArrow)
                {
                    _game.SpriteBatch.Draw(screen, arrowDestRect, specialArrowSourceRect, Color.White);
                }
                else if (_inventory.RupeeCount > 0)
                {
                    _game.SpriteBatch.Draw(screen, arrowDestRect, arrowSourceRect, Color.White);
                }
            }
        }
        public void DrawCurrentSlotItem()
        {
            if ((CurrentB_Slot_Item is LinkInventory.Items.Bomb) && _inventory.BombCount > 0)
            {
                currentB_SlotItemSourceRect = bombSourceRect;
            }
            else if ((CurrentB_Slot_Item is LinkInventory.Items.BowAndArrow) && _inventory.Bow)
            {
                currentB_SlotItemSourceRect = bowSourceRect;
            }
            else if ((CurrentB_Slot_Item is LinkInventory.Items.Boomerang) && _inventory.Boomerang)
            {
                currentB_SlotItemSourceRect = boomerangSourceRect;
            }
            else if ((CurrentB_Slot_Item is LinkInventory.Items.SpecialBoomerang) && _inventory.SpecialBoomerang)
            {
                currentB_SlotItemSourceRect = specialBoomerangSourceRect;
            }
            else if ((CurrentB_Slot_Item is LinkInventory.Items.Candle) && _inventory.Candle)
            {
                currentB_SlotItemSourceRect = candleSourceRect;
            }
            else
            {
                currentB_SlotItemSourceRect = new Rectangle(10, 10, 0, 0);
            }
            _game.SpriteBatch.Draw(screen, slotBDestRect, selectedItem, Color.White);
            _game.SpriteBatch.Draw(screen, itemSelectionSlot, currentB_SlotItemSourceRect, Color.White);
        }
        public void DrawItemCounts()
        {
            if (_inventory.RupeeCount >= 100)
            {
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + numberWidth, rupeeYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + (10 * numberWidth) + (10 * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }
            else
            {
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + numberWidth, rupeeYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.RupeeCount / 10) * numberWidth) + ((_inventory.RupeeCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + (numberWidth * 2), rupeeYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.RupeeCount % 10) * numberWidth) + ((_inventory.RupeeCount % 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            if (_inventory.KeyCount >= 100)
            {
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + numberWidth, keyYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + (10 * numberWidth) + (10 * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }
            else
            {
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + numberWidth, keyYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.KeyCount / 10) * numberWidth) + ((_inventory.KeyCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + (numberWidth * 2), keyYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.KeyCount % 10) * numberWidth) + ((_inventory.KeyCount % 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            if (_inventory.BombCount >= 100)
            {
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + numberWidth, bombYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + (10 * numberWidth) + (10 * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }
            else
            {
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + numberWidth, bombYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.BombCount / 10) * numberWidth) + ((_inventory.BombCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + (numberWidth * 2), bombYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.BombCount % 10) * numberWidth) + ((_inventory.BombCount % 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }
        }
        public void DrawHearts()
        {
            int remainingHalfHearts = _inventory.HeartCountPlayer1;
            int heartContainerCountPlayer1 = _levelManager.Player1.MaxHp / 2;
            if (_levelManager.TwoPlayer)
            {
                int remainingHalfHeartsPlayer2 = _levelManager.Player2.PlayerHp;
                int heartContainerCountPlayer2 = _levelManager.Player2.MaxHp / 2;
                for (int i = 0; i < MAX_HEART_COUNT; i++)
                {
                    if (i < heartContainerCountPlayer2)
                    {
                        if (remainingHalfHeartsPlayer2 >= 2)
                        {
                            currentHeartNeeded = heartSourceRect;
                            remainingHalfHeartsPlayer2 -= 2;
                        }
                        else if (remainingHalfHeartsPlayer2 == 1)
                        {
                            currentHeartNeeded = halfHeartSourceRect;
                            remainingHalfHeartsPlayer2 -= 1;
                        }
                        else
                        {
                            currentHeartNeeded = emptyHeartSourceRect;
                        }
                        _game.SpriteBatch.Draw(screen, new Rectangle(heartXDestLocation + (heartWidth/2 * i), heartYDestLocation+(heartHeight/2), heartWidth/2, heartHeight/2), currentHeartNeeded, Color.White);
                    }
                    else
                    {
                        _game.SpriteBatch.Draw(screen, new Rectangle(heartXDestLocation + (heartWidth/2 * i), heartYDestLocation, heartWidth/2, heartHeight/2), new Rectangle(heartWidth, 0, heartWidth/2, heartHeight/2), Color.Black);
                    }
                }

                for (int i = 0; i < MAX_HEART_COUNT; i++)
                {
                    if (i < heartContainerCountPlayer1)
                    {
                        if (remainingHalfHearts >= 2)
                        {
                            currentHeartNeeded = heartSourceRect;
                            remainingHalfHearts -= 2;
                        }
                        else if (remainingHalfHearts == 1)
                        {
                            currentHeartNeeded = halfHeartSourceRect;
                            remainingHalfHearts -= 1;
                        }
                        else
                        {
                            currentHeartNeeded = emptyHeartSourceRect;
                        }
                        _game.SpriteBatch.Draw(screen, new Rectangle(heartXDestLocation + (heartWidth/2 * i), heartYDestLocation, heartWidth / 2, heartHeight / 2), currentHeartNeeded, Color.White);
                    }
                    else
                    {
                        _game.SpriteBatch.Draw(screen, new Rectangle(heartXDestLocation + (heartWidth/2 * i), heartYDestLocation, heartWidth / 2, heartHeight / 2), new Rectangle(heartWidth, 0, heartWidth / 2, heartHeight / 2), Color.Black);
                    }
                }
            }
            else
            {
                for (int i = 0; i < MAX_HEART_COUNT; i++)
                {
                    if (i < heartContainerCountPlayer1)
                    {
                        if (remainingHalfHearts >= 2)
                        {
                            currentHeartNeeded = heartSourceRect;
                            remainingHalfHearts -= 2;
                        }
                        else if (remainingHalfHearts == 1)
                        {
                            currentHeartNeeded = halfHeartSourceRect;
                            remainingHalfHearts -= 1;
                        }
                        else
                        {
                            currentHeartNeeded = emptyHeartSourceRect;
                        }
                        _game.SpriteBatch.Draw(screen, new Rectangle(heartXDestLocation + (heartWidth * i), heartYDestLocation, heartWidth, heartHeight), currentHeartNeeded, Color.White);
                    }
                    else
                    {
                        _game.SpriteBatch.Draw(screen, new Rectangle(heartXDestLocation + (heartWidth * i), heartYDestLocation, heartWidth, heartHeight), new Rectangle(heartWidth, 0, heartWidth, heartHeight), Color.Black);
                    }
                }
            }
        }
        public void Select(LinkInventory.Items item)
        {
            if (item is LinkInventory.Items.Boomerang && _inventory.Boomerang)
            {
                selectedItem = boomerangSourceRect;
                _inventory.Selected_Item = item;
            }
            else if (item is LinkInventory.Items.Bomb && _inventory.BombCount > 0)
            {
                selectedItem = bombSourceRect;
                _inventory.Selected_Item = item;
            }
            else if (item is LinkInventory.Items.BowAndArrow && _inventory.Bow)
            {
                selectedItem = bowSourceRect;
                _inventory.Selected_Item = item;
            }
            else if (item is LinkInventory.Items.SpecialBoomerang && _inventory.SpecialBoomerang)
            {
                selectedItem = specialBoomerangSourceRect;
                _inventory.Selected_Item = item;
            }
            else if (item is LinkInventory.Items.Candle)
            {
                selectedItem = candleSourceRect;
                _inventory.Selected_Item = item;

            }
            else if (item is LinkInventory.Items.None)
            {
                selectedItem = new Rectangle(10, 10, 0, 0);
                _inventory.Selected_Item = item;

            }
            else
            {
                selectedItem = new Rectangle(10, 10, 0, 0);
                _inventory.Selected_Item = LinkInventory.Items.None;
            }
        }
        public override void loadContent()
        {
            screen = _content.Load<Texture2D>("Inventory");
            isInventory = true;
        }

        public override void update(GameTime gameTime)
        {
            _game.MouseController.handleInput();
            _game.KeyboardController.handleInput();
            currentItemIndexColumn = ((int)(InventoryBoxPosition.X - itemsInventoryXDestLocation) / inventorySlotsWidth);
            currentItemIndexRow = ((int)(InventoryBoxPosition.Y - itemsInventoryYDestLocation) / inventorySlotsHeight);
            boxDestRect = new Rectangle((int)InventoryBoxPosition.X, (int)InventoryBoxPosition.Y, inventorySlotsWidth, inventorySlotsHeight);
            currentB_slot_item = _inventory.ItemPositionIndex[currentItemIndexRow, currentItemIndexColumn];

        }

        public override void Draw(GameTime gameTime)
        {
            frame++;
            _inventory.Update();
            Rectangle screenDestRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            Rectangle screenSrcRect = new Rectangle(0, 0, WIDTH, HEIGHT);

            _game.SpriteBatch.Begin();

            _game.SpriteBatch.Draw(
                     screen,
                     screenDestRect,
                     screenSrcRect,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0f
                    );
            _game.SpriteBatch.Draw(screen, rupeeNumberDestRect, timesSymbolSourceRect, Color.White);
            _game.SpriteBatch.Draw(screen, bombNumberDestRect, timesSymbolSourceRect, Color.White);
            _game.SpriteBatch.Draw(screen, keyNumberDestRect, timesSymbolSourceRect, Color.White);
            _game.SpriteBatch.Draw(screen, levelNumberDestRect, new Rectangle(numberXSourceLocation + (_inventory.LevelNumber * numberWidth) + (_inventory.LevelNumber * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            _game.SpriteBatch.Draw(screen, slotADestRect, swordSourceRect, Color.White);

            DrawItemCounts();
            DrawHearts();
            DrawInventoryItems();
            DrawCurrentSlotItem(); 

            if (_inventory.Map == true)
            {
                _game.SpriteBatch.Draw(screen, mapDestRect, mapSourceRect, Color.White);
                _game.SpriteBatch.Draw(screen, mapDesignDestRect, mapDesignSourceRect, Color.White);
                _game.SpriteBatch.Draw(screen, otherMapDestRect, otherMapSourceRect, Color.White);
                
            }

            if (_inventory.Compass == true)
            {
                _game.SpriteBatch.Draw(screen, compassDestRect, compassSourceRect, Color.White);
                _game.SpriteBatch.Draw(screen, new Rectangle(_inventory.MapLocationX, _inventory.MapLocationY, locationSquareSize, locationSquareSize), locationSquareSourceRect, Color.LimeGreen);
                _game.SpriteBatch.Draw(screen, new Rectangle(_inventory.MapSquareLocationX, _inventory.MapSquareLocationY, locationSquareSize, locationSquareSize), locationSquareSourceRect, Color.LimeGreen);
                if (frame % 50 > 20)
                {
                    _game.SpriteBatch.Draw(screen, triforceSquareDestLocation, locationSquareSourceRect, Color.Red);
                    _game.SpriteBatch.Draw(screen, triforceMiniMapSquareDestLocation, locationSquareSourceRect, Color.Red);
                }
            }

            _game.SpriteBatch.End();
        }
    }
}
