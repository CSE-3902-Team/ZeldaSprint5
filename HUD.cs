using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint0
{
    public class HUD
    {
        private Player player;
        private LinkInventory inventory;
        private SpriteBatch spriteBatch;
        private Texture2D headsUpDisplay;

        private Rectangle hudRectangle;
        private Rectangle heartSourceRect;
        private Rectangle halfHeartSourceRect;
        private Rectangle emptyHeartSourceRect;
        private Rectangle heartDestRect;
        private Rectangle currentHeartNeeded;
        private Rectangle numberSourceRect;
        private Rectangle rupeeNumberDestRect;
        private Rectangle bombNumberDestRect;
        private Rectangle keyNumberDestRect;
        private Rectangle timesSymbolSourceRect;
        private Rectangle levelNumberDestRect;

        private int health;
        private int heartContainerCount;
        private int rupeeCount;
        private int levelNumber;
        private int keyCount;
        private int bombCount;
        private int arrowCount;

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

        public HUD(Player player, SpriteBatch spritebatch, Texture2D headsUpDisplay)
        {
            this.player = player;
            this.spriteBatch = spritebatch;
            this.headsUpDisplay = headsUpDisplay;
            inventory = player.Inventory;

            health = player.Inventory.HeartCount;
            heartContainerCount = player.Inventory.HeartContainerCount;
            rupeeCount = player.Inventory.RupeeCount;
            keyCount = player.Inventory.KeyCount;
            bombCount = player.Inventory.BombCount;
            arrowCount = player.Inventory.ArrowCount;

            levelNumber = 1;

            hudRectangle = new Rectangle(0, 0, 1024, 256);
            emptyHeartSourceRect = new Rectangle((heartWidth * 0) + (spaceBetweenHearts*0), 255, heartWidth, heartHeight);
            halfHeartSourceRect = new Rectangle((heartWidth * 1) + (spaceBetweenHearts * 1), 255, heartWidth, heartHeight);
            heartSourceRect = new Rectangle((heartWidth * 2) + (spaceBetweenHearts * 2), 255, heartWidth, heartHeight);
            numberSourceRect = new Rectangle(numberXSourceLocation, heartAndNumberYSourceLocation, numberWidth, numberHeight);
            timesSymbolSourceRect = new Rectangle(numberXSourceLocation, (heartAndNumberYSourceLocation + numberHeight), numberWidth, numberHeight);

            levelNumberDestRect = new Rectangle(levelNumberXDestLocation, 0, numberWidth, numberHeight);
            heartDestRect = new Rectangle(650, 146, heartWidth, heartHeight);
            rupeeNumberDestRect = new Rectangle(numberXDestLocation, rupeeYDestLocation, numberWidth + 1, numberHeight);
            bombNumberDestRect = new Rectangle(numberXDestLocation, bombYDestLocation, numberWidth + 1, numberHeight);
            keyNumberDestRect = new Rectangle(numberXDestLocation, keyYDestLocation, numberWidth + 1, numberHeight);

        }

        public void Update()
        {
            inventory.Update();
            health = player.Inventory.HeartCount;
            heartContainerCount = player.Inventory.HeartContainerCount;
            rupeeCount = player.Inventory.RupeeCount;
            keyCount = player.Inventory.KeyCount;
            bombCount = player.Inventory.BombCount;
            arrowCount = player.Inventory.ArrowCount;
        }
        public void Draw()
        {
            Update();
            spriteBatch.Begin();
            spriteBatch.Draw(headsUpDisplay, hudRectangle, hudRectangle, Color.White);
            spriteBatch.Draw(headsUpDisplay, rupeeNumberDestRect, timesSymbolSourceRect, Color.White);
            spriteBatch.Draw(headsUpDisplay, bombNumberDestRect, timesSymbolSourceRect, Color.White);
            spriteBatch.Draw(headsUpDisplay, keyNumberDestRect, timesSymbolSourceRect, Color.White);
            spriteBatch.Draw(headsUpDisplay, levelNumberDestRect, new Rectangle(numberXSourceLocation + (levelNumber*numberWidth) + (levelNumber*spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);


            int remainingNumberSpaces = 2;
            for(int i = 1; i <= remainingNumberSpaces; i++)
            {
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + numberWidth, rupeeYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((rupeeCount / 10) * numberWidth) + ((rupeeCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + (numberWidth * remainingNumberSpaces), rupeeYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((rupeeCount % 10) * numberWidth) + (rupeeCount * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            for (int i = 1; i <= remainingNumberSpaces; i++)
            {
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + numberWidth, keyYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((keyCount / 10) * numberWidth) + ((keyCount / 10)* spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + (numberWidth * remainingNumberSpaces), keyYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((keyCount % 10) * numberWidth) + (keyCount * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);  
            }

            for (int i = 1; i <= remainingNumberSpaces; i++)
            {
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + numberWidth, bombYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((bombCount / 10) * numberWidth) + ((bombCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                spriteBatch.Draw(headsUpDisplay, new Rectangle(numberXDestLocation + (numberWidth * remainingNumberSpaces), bombYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((bombCount % 10) * numberWidth) + (bombCount * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            int remainingHalfHearts = health;
            for (int i = 0; i < maxHeartCount; i++)
            {
                if (i < heartContainerCount)
                {
                    if(remainingHalfHearts>=2)
                    {
                        currentHeartNeeded = heartSourceRect;
                        remainingHalfHearts -= 2;
                    }
                    else if(remainingHalfHearts == 1)
                    {
                        currentHeartNeeded = halfHeartSourceRect;
                        remainingHalfHearts -= 1;
                    }
                    else
                    {
                        currentHeartNeeded = emptyHeartSourceRect;
                    }
                    spriteBatch.Draw(headsUpDisplay, new Rectangle(680 + (heartWidth * i), 146, heartWidth, heartHeight), currentHeartNeeded, Color.White);
                }
                else
                {
                    spriteBatch.Draw(headsUpDisplay, new Rectangle(680 + (heartWidth * i), 146, heartWidth, heartHeight), new Rectangle(heartWidth,0,heartWidth,heartHeight), Color.Black);
                }
            }
            spriteBatch.End();
        }
    }
}
