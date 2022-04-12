using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.ItemClass;

namespace Sprint0
{
    public class LinkInventory
    {
        private Player player;

        private int rupeeCount;
        private int keyCount;
        private int bombCount;
        private int arrowCount;
        private int heartCount;
        private int heartContainerCount;
        private int levelNumber;
        private int locationSquareX;
        private int locationSquareY;

        private Boolean firstRupee;
        private Boolean firstKey;
        private Boolean firstBomb;
        private Boolean firstBoomerang;
        private Boolean firstBow;
        private Boolean firstClock;
        private Boolean firstArrow;
        private Boolean firstHeart;
        private Boolean firstHeartContainer;
        private Boolean firstCompass;
        private Boolean firstFairy;
        private Boolean firstMap;

        private Boolean bow;
        private Boolean map;
        private Boolean compass;
        private Boolean boomerang;
        private Boolean clock;

        public int LevelNumber
        {
            get { return levelNumber; }
            set { rupeeCount = value; }
        }
        public int RupeeCount
        {
            get { return rupeeCount; }
            set { rupeeCount = value; }
        }

        public int KeyCount
        {
            get { return keyCount; }
            set { keyCount = value; }
        }
        public int BombCount
        {
            get { return bombCount; }
            set { bombCount = value; }
        }

        public int ArrowCount
        {
            get { return arrowCount; }
            set { arrowCount = value; }
        }

        public int HeartCount
        {
            get { return heartCount; }
            set { heartCount = value; }
        }

        public int HeartContainerCount
        {
            get { return heartContainerCount; }
            set { heartContainerCount = value; }
        }

        public Boolean FirstArrow
        {
            get { return firstArrow; }
            set { firstArrow = value; }
        }
        public Boolean FirstBomb
        {
            get { return firstBomb; }
            set { firstBomb = value; }
        }
        public Boolean FirstBoomerang
        {
            get { return firstBoomerang; }
            set { firstBoomerang = value; }
        }
        public Boolean FirstBow
        {
            get { return firstBow; }
            set { firstBow = value; }
        }
        public Boolean FirstClock
        {
            get { return firstClock; }
            set { firstClock = value; }
        }
        public Boolean FirstCompass
        {
            get { return firstCompass; }
            set { firstCompass = value; }
        }
        public Boolean FirstFairy
        {
            get { return firstFairy; }
            set { firstFairy = value; }
        }
        public Boolean FirstHeart
        {
            get { return firstHeart; }
            set { firstHeart = value; }
        }
        public Boolean FirstHeartContainer
        {
            get { return firstHeartContainer; }
            set { firstHeartContainer = value; }
        }
        public Boolean FirstKey
        {
            get { return firstKey; }
            set { firstKey = value; }
        }
        public Boolean FirstMap
        {
            get { return firstMap; }
            set { firstMap = value; }
        }
        public Boolean FirstRupee
        {
            get { return firstRupee; }
            set { firstRupee = value; }
        }
        public Boolean Bow
        {
            get { return bow; }
            set { bow = value; }
        }

        public Boolean Map
        {
            get { return map; }
            set { map = value; }
        }

        public Boolean Compass
        {
            get { return compass; }
            set { compass = value; }
        }

        public Boolean Boomerang
        {
            get { return boomerang; }
            set { boomerang = value; }
        }
        
        public Boolean Clock
        {
            get { return clock; }
            set { clock = value; }
        }
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

        public LinkInventory(Player player)
        {
            this.player = player;

            rupeeCount = 0;
            keyCount = 0;
            bombCount = 0;
            arrowCount = 0;
            heartCount = player.PlayerHp;
            heartContainerCount = (player.MaxHp)/2;
            levelNumber = 1;
            locationSquareX = 135;
            locationSquareY = 921;

            firstRupee = true;
            firstKey = true; 
            firstBomb = true;
            firstBoomerang = true;
            firstBow = true;
            firstClock = true;
            firstArrow = true;
            firstHeart = true;
            firstHeartContainer = true;
            firstMap = true;
            firstFairy = true;

            bow = false;
            map = false;
            compass = false;
            boomerang = false;
            clock = false;

        }

        public void Update()
        {
            heartContainerCount = (player.MaxHp) / 2;
            heartCount = player.PlayerHp;
        }

    }
}
