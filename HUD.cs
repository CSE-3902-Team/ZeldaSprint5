using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.LevelClass;

namespace Sprint0
{
    public class HUD
    {
        private Player player;
        private Player player2;
        private LinkInventory inventory;
        private SpriteBatch spriteBatch;
        private Texture2D headsUpDisplay;
        private LevelManager levelManager;

        private Rectangle hudRectangle;
        private Rectangle heartSourceRect;
        private Rectangle halfHeartSourceRect;
        private Rectangle emptyHeartSourceRect;
        private Rectangle currentHeartNeeded;
        private Rectangle numberSourceRect;
        private Rectangle rupeeNumberDestRect;
        private Rectangle bombNumberDestRect;
        private Rectangle keyNumberDestRect;
        private Rectangle timesSymbolSourceRect;
        private Rectangle levelNumberDestRect;
        private Rectangle mapSourceRect;
        private Rectangle mapDestRect;
        private Rectangle locationSquareSourceRect;
        private Rectangle locationSquareDestRect;
        private Rectangle swordSourceRect;
        private Rectangle boomerangSourceRect;
        private Rectangle specialBoomerangSourceRect;
        private Rectangle bombSourceRect;
        private Rectangle arrowSourceRect;
        private Rectangle bowSourceRect;
        private Rectangle slotADestRect;
        private Rectangle slotBDestRect;
        private Rectangle currentB_SlotItem;

        private int healthPlayer1;
        private int heartContainerCount;
        private int rupeeCount;
        private int levelNumber;
        private int keyCount;
        private int bombCount;
        private int arrowCount;
        private int locationSquareX;
        private int locationSquareY;

        const int HUDoffsetX = 16;
        const int HUDoffsetY = 712;

        const int heartWidth = 64;
        const int heartHeight = 73;
        const int spaceBetweenHearts = 8;
        const int maxHeartCount = 5;

        const int numberWidth = 33;
        const int numberHeight = 37;
        const int spaceBetweenNumbers = 5;

        const int heartAndNumberYSourceLocation = 255;
        const int numberXSourceLocation = 208;
        const int rupeeYDestLocation = 73;
        const int keyYDestLocation = 146;
        const int bombYDestLocation = 182;
        const int numberXDestLocation = 383;
        const int levelNumberXDestLocation = 131;
        const int itemsRowYSourceLocation = 330;
        const int swordXSourceLocation = 173;
        const int boomerangXSourceLocation = 319;
        const int bombXSourceLocation = 415;
        const int arrowXSourceLocation = 475;
        const int bowXSourceLocation = 556;
        const int slotA_XDestLocation = 600;
        const int slotB_XDestLocation = 504;
        const int slotsYDestLocation = 106;
        const int heartsYSourceLocation = 255;
        const int specialBoomerangXSourceLocation = 360;


        const int mapYSourceLocation = 518;
        const int mapWidth = 295;
        const int mapHeight = 200;
        const int mapXDestLocation = 30;
        const int mapYDestLocation = 37;
        const int heartXDestLocation = 680;
        const int heartYDestLocation = 146;

        const int locationSquareSize = 20;
        const int locationSquareXSourceLocation = 120;
        const int locationSquareYSourceLocation = 750;

        const int slotWidth = 46;
        const int slotHeight = 85;

        const int swordWidth = 41;
        const int swordHeight = 85;

        const int boomerangWidth = 45;
        const int boomerangHeight = 80;

        const int bombWidth = 50;
        const int bombHeight = 75;

        const int arrowWidth = 40;
        const int arrowHeight = 85;

        const int bowWidth = 50;
        const int bowHeight = 90;

        public int MapLocationX
        {
            get { return locationSquareX; }
            set { locationSquareX = value; }
        }

        public int MapLocationY
        {
            get { return locationSquareY; }
            set { locationSquareY = value; }
        }

        public HUD(SpriteBatch spritebatch, Texture2D headsUpDisplay)
        {
            levelManager = LevelManager.Instance;
            player = levelManager.Player1;
            this.spriteBatch = spritebatch;
            this.headsUpDisplay = headsUpDisplay;
            inventory = player.Inventory;

            healthPlayer1 = player.PlayerHp;
            heartContainerCount = player.Inventory.HeartContainerCount;
            rupeeCount = player.Inventory.RupeeCount;
            keyCount = player.Inventory.KeyCount;
            bombCount = player.Inventory.BombCount;
            arrowCount = player.Inventory.ArrowCount;

            levelNumber = player.Inventory.LevelNumber;
            locationSquareX = player.Inventory.MapLocationX + HUDoffsetX;
            locationSquareY = player.Inventory.MapLocationY - HUDoffsetY;

            hudRectangle = new Rectangle(0, 0, 1024, 255);
            emptyHeartSourceRect = new Rectangle((heartWidth * 0) + (spaceBetweenHearts * 0), heartsYSourceLocation, heartWidth, heartHeight);
            halfHeartSourceRect = new Rectangle((heartWidth * 1) + (spaceBetweenHearts * 1), heartsYSourceLocation, heartWidth, heartHeight);
            heartSourceRect = new Rectangle((heartWidth * 2) + (spaceBetweenHearts * 2), heartsYSourceLocation, heartWidth, heartHeight);
            numberSourceRect = new Rectangle(numberXSourceLocation, heartAndNumberYSourceLocation, numberWidth, numberHeight);
            timesSymbolSourceRect = new Rectangle(numberXSourceLocation, (heartAndNumberYSourceLocation + numberHeight), numberWidth, numberHeight);
            mapSourceRect = new Rectangle(0, mapYSourceLocation, mapWidth, mapHeight);
            swordSourceRect = new Rectangle(swordXSourceLocation, itemsRowYSourceLocation, swordWidth, swordHeight);
            boomerangSourceRect = new Rectangle(boomerangXSourceLocation, itemsRowYSourceLocation, boomerangWidth, boomerangHeight);
            bombSourceRect = new Rectangle(bombXSourceLocation, itemsRowYSourceLocation, bombWidth, bombHeight);
            arrowSourceRect = new Rectangle(arrowXSourceLocation, itemsRowYSourceLocation, arrowWidth, arrowHeight);
            bowSourceRect = new Rectangle(bowXSourceLocation, itemsRowYSourceLocation, bowWidth, bowHeight);
            specialBoomerangSourceRect = new Rectangle(specialBoomerangXSourceLocation, itemsRowYSourceLocation, boomerangWidth, boomerangHeight);


            levelNumberDestRect = new Rectangle(levelNumberXDestLocation, 0, numberWidth, numberHeight);
            rupeeNumberDestRect = new Rectangle(numberXDestLocation, rupeeYDestLocation, numberWidth, numberHeight);
            bombNumberDestRect = new Rectangle(numberXDestLocation, bombYDestLocation, numberWidth, numberHeight);
            keyNumberDestRect = new Rectangle(numberXDestLocation, keyYDestLocation, numberWidth, numberHeight);
            mapDestRect = new Rectangle(mapXDestLocation, mapYDestLocation, mapWidth, mapHeight);
            locationSquareSourceRect = new Rectangle(locationSquareXSourceLocation, locationSquareYSourceLocation, locationSquareSize, locationSquareSize);
            locationSquareDestRect = new Rectangle(locationSquareX, locationSquareY, locationSquareSize, locationSquareSize);
            slotADestRect = new Rectangle(slotA_XDestLocation, slotsYDestLocation, slotWidth, slotHeight);
            slotBDestRect = new Rectangle(slotB_XDestLocation, slotsYDestLocation, slotWidth, slotHeight);
            currentB_SlotItem = new Rectangle(0, 0, 0, 0);

        }

        public void DrawHearts()
        {
            int remainingHalfHearts = inventory.HeartCountPlayer1;
            if (levelManager.TwoPlayer)
            {
                int remainingHalfHeartsPlayer2 = levelManager.Player2.PlayerHp;
                for (int i = 0; i < maxHeartCount; i++)
                {
                    if (i < inventory.HeartContainerCount)
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
                        spriteBatch.Draw(headsUpDisplay, new Rectangle(heartXDestLocation + (heartWidth * i/2), heartYDestLocation+(heartHeight/2), heartWidth/2, heartHeight/2), currentHeartNeeded, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(headsUpDisplay, new Rectangle(heartXDestLocation + (heartWidth * i/2), heartYDestLocation+(heartHeight/2), heartWidth/2, heartHeight/2), new Rectangle(heartWidth, 0, heartWidth, heartHeight), Color.Black);
                    }
                }

                for (int i = 0; i < maxHeartCount; i++)
                {
                    if (i < inventory.HeartContainerCount)
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
                        spriteBatch.Draw(headsUpDisplay, new Rectangle(heartXDestLocation + (heartWidth / 2 * i), heartYDestLocation, heartWidth / 2, heartHeight / 2), currentHeartNeeded, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(headsUpDisplay, new Rectangle(heartXDestLocation + (heartWidth / 2 * i), heartYDestLocation, heartWidth / 2, heartHeight / 2), new Rectangle(heartWidth, 0, heartWidth / 2, heartHeight / 2), Color.Black);
                    }
                }
            }
            else
            {
                for (int i = 0; i < maxHeartCount; i++)
                {
                    if (i < inventory.HeartContainerCount)
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
                        spriteBatch.Draw(headsUpDisplay, new Rectangle(heartXDestLocation + (heartWidth * i), heartYDestLocation, heartWidth, heartHeight), currentHeartNeeded, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(headsUpDisplay, new Rectangle(heartXDestLocation + (heartWidth * i), heartYDestLocation, heartWidth, heartHeight), new Rectangle(heartWidth, 0, heartWidth, heartHeight), Color.Black);
                    }
                }

            }
        }
        public void Update()
        {
            inventory.Update();
            healthPlayer1 = player.PlayerHp;
            heartContainerCount = player.Inventory.HeartContainerCount;
            rupeeCount = player.Inventory.RupeeCount;
            keyCount = player.Inventory.KeyCount;
            bombCount = player.Inventory.BombCount;
            arrowCount = player.Inventory.ArrowCount;
            levelNumber = player.Inventory.LevelNumber;
            locationSquareX = player.Inventory.MapLocationX + 16;
            locationSquareY = player.Inventory.MapLocationY - 712;
        }
        public void Draw()
        {
            Update();
            spriteBatch.Begin();
            spriteBatch.Draw(headsUpDisplay, hudRectangle, hudRectangle, Color.White);
            spriteBatch.Draw(headsUpDisplay, rupeeNumberDestRect, timesSymbolSourceRect, Color.White);
            spriteBatch.Draw(headsUpDisplay, bombNumberDestRect, timesSymbolSourceRect, Color.White);
            spriteBatch.Draw(headsUpDisplay, keyNumberDestRect, timesSymbolSourceRect, Color.White);
            spriteBatch.Draw(headsUpDisplay, levelNumberDestRect, new Rectangle(numberXSourceLocation + (levelNumber * numberWidth) + (levelNumber * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            spriteBatch.Draw(headsUpDisplay, slotADestRect, swordSourceRect, Color.White);

            if (inventory.Selected_Item is LinkInventory.Items.Bomb)
            {
                currentB_SlotItem = bombSourceRect;

            }
            else if (inventory.Selected_Item is LinkInventory.Items.Boomerang)
            {
                currentB_SlotItem = boomerangSourceRect;
            }
            else if (inventory.Selected_Item is LinkInventory.Items.BowAndArrow)
            {
                currentB_SlotItem = bowSourceRect;
            }
            else if (inventory.Selected_Item is LinkInventory.Items.SpecialBoomerang)
            {
                currentB_SlotItem = specialBoomerangSourceRect;
            }
            else if (inventory.Selected_Item is LinkInventory.Items.None)
            {
                currentB_SlotItem = new Rectangle(0, 0, 0, 0);
            }
            spriteBatch.Draw(headsUpDisplay, slotBDestRect, currentB_SlotItem, Color.White);

            if (inventory.RupeeCount >= 100)
            {
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + numberWidth, rupeeYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + (10 * numberWidth) + (10 * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }
            else
            {
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + numberWidth, rupeeYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((inventory.RupeeCount / 10) * numberWidth) + ((inventory.RupeeCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + (numberWidth * 2), rupeeYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((inventory.RupeeCount % 10) * numberWidth) + ((inventory.RupeeCount % 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            if (inventory.KeyCount >= 100)
            {
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + numberWidth, keyYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + (10 * numberWidth) + (10 * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }
            else
            {
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + numberWidth, keyYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((inventory.KeyCount / 10) * numberWidth) + ((inventory.KeyCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + (numberWidth * 2), keyYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((inventory.KeyCount % 10) * numberWidth) + ((inventory.KeyCount % 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            if (inventory.BombCount >= 100)
            {
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + numberWidth, bombYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + (10 * numberWidth) + (10 * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }
            else
            {
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + numberWidth, bombYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((inventory.BombCount / 10) * numberWidth) + ((inventory.BombCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + (numberWidth * 2), bombYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((inventory.BombCount % 10) * numberWidth) + ((inventory.BombCount % 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            DrawHearts();

            if (player.Inventory.Map == true)
            {
                spriteBatch.Draw(headsUpDisplay, mapDestRect, mapSourceRect, Color.White);
            }

            spriteBatch.Draw(headsUpDisplay, new Rectangle(MapLocationX, MapLocationY, locationSquareSize, locationSquareSize), locationSquareSourceRect, Color.White);
            spriteBatch.End();
        }
    }
}