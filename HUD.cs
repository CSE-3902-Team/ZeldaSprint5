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

        private int health;
        private int rupeeCount;
        private int levelNumber;
        private int keyCount;
        private int bombCount;

        private int MAX_HEALTH_COUNT;
        public HUD(Player player, SpriteBatch spritebatch)
        {
            this.player = player;
            this.spriteBatch = spritebatch;

            health = player.PlayerHp;
            rupeeCount = player.Inventory.RupeeCount;
            keyCount = player.Inventory.KeyCount;
            bombCount = player.Inventory.BombCount;

            levelNumber = 1;
            MAX_HEALTH_COUNT = 6;

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
