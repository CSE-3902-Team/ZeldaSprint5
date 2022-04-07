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

        const int numberWidth = 32;
        const int numberHeight = 37;
        const int spaceBetweenNumbers = 5;

        const int heartAndNumberYLocation = 255;
        const int numberXLocation = 213;
        const int rupeeYLocation = 73;
        const int keyYLocation = 146;
        const int bombYLocation = 182;

        public HUD(Player player, SpriteBatch spritebatch, Texture2D headsUpDisplay)
        {
            this.player = player;
            this.spriteBatch = spritebatch;
            this.headsUpDisplay = headsUpDisplay;
            inventory = player.Inventory;

            health = player.PlayerHp;
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

            heartDestRect = new Rectangle(650, 146, heartWidth, heartHeight);
        }

        public void Update()
        {
            health = player.PlayerHp;
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

           // for(int i = 0; i < 3; i++)
          //  {
         //   }

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
