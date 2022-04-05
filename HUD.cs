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

        private int health;
        private int heartContainerCount;
        private int rupeeCount;
        private int levelNumber;
        private int keyCount;
        private int bombCount;

        public HUD(Player player, SpriteBatch spritebatch, Texture2D headsUpDisplay)
        {
            this.player = player;
            this.spriteBatch = spritebatch;
            this.headsUpDisplay = headsUpDisplay;

            health = player.Inventory.HeartCount;
            heartContainerCount = player.Inventory.HeartContainerCount;
            rupeeCount = player.Inventory.RupeeCount;
            keyCount = player.Inventory.KeyCount;
            bombCount = player.Inventory.BombCount;

            levelNumber = 1;

            hudRectangle = new Rectangle(0, 0, 1024, 256);
        }

        public void Draw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(headsUpDisplay, hudRectangle, hudRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
