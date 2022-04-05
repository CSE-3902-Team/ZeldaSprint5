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
        private Texture2D hearts;
        private Rectangle hudRectangle;
        private Rectangle heartSourceRect;
        private Rectangle halfHeartSourceRect;
        private Rectangle emptyHeartSourceRect;
        private Rectangle heartDestRect;
        private Rectangle currentHeartNeeded;

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
        const int maxHeartCount = 4;

        public HUD(Player player, SpriteBatch spritebatch, Texture2D headsUpDisplay, Texture2D hearts)
        {
            this.player = player;
            this.spriteBatch = spritebatch;
            this.headsUpDisplay = headsUpDisplay;
            this.hearts = hearts;

            health = player.Inventory.HeartCount;
            heartContainerCount = player.Inventory.HeartContainerCount;
            rupeeCount = player.Inventory.RupeeCount;
            keyCount = player.Inventory.KeyCount;
            bombCount = player.Inventory.BombCount;
            arrowCount = player.Inventory.ArrowCount;

            levelNumber = 1;


            hudRectangle = new Rectangle(0, 0, 1024, 256);
            emptyHeartSourceRect = new Rectangle((heartWidth * 0) + (spaceBetweenHearts*0), 0, heartWidth, heartHeight);
            halfHeartSourceRect = new Rectangle((heartWidth * 1) + (spaceBetweenHearts * 1), 0, heartWidth, heartHeight);
            heartSourceRect = new Rectangle((heartWidth * 2) + (spaceBetweenHearts * 2), 0, heartWidth, heartHeight);
            heartDestRect = new Rectangle(705, 146, heartWidth, heartHeight);
        }

        public void Update()
        {
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
            for(int i = 0; i < maxHeartCount; i++)
            {
                if(i < heartContainerCount)
                {
                    spriteBatch.Draw(hearts, new Rectangle(705 + (heartWidth * i), 146, heartWidth, heartHeight), heartSourceRect, Color.White);
                }
                else
                {
                    spriteBatch.Draw(hearts, new Rectangle(705 + (heartWidth * i), 146, heartWidth, heartHeight), new Rectangle((heartWidth*3),0,heartWidth,heartHeight), Color.Black);
                }
            }
            spriteBatch.End();
        }
    }
}
