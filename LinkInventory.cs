using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.ItemClass;

namespace Sprint0
{
    public class LinkInventory
    {
        private Player player;

        private List<int> itemAndCounts;

        private int rupeeCount;
        private int keyCount;
        private int bombCount;
        private int arrowCount;
        private int heartCount;
        private int heartContainerCount;

        private Boolean firstRupee;
        private Boolean firstMap;
        private Boolean firstCompass;
        private Boolean firstBoomerang;
        private Boolean firstArrow;
        private Boolean firstBomb;
        private Boolean firstBow;
        private Boolean firstHeart;
        private Boolean firstHeartContainer;
        private Boolean firstFairy;
        private Boolean firstClock;
        private Boolean firstKey;

        private Boolean bow;
        private Boolean map;
        private Boolean compass;
        private Boolean boomerang;
        private Boolean clock;
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
        public Boolean FirstBomb
        {
            get { return firstBomb; }
            set { firstBomb = value; }
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

        public LinkInventory(Player player)
        {
            this.player = player;

            arrowCount = 0;
            bombCount = 0;
            heartCount = player.PlayerHp;
            heartContainerCount = 3;
            keyCount = 0;
            rupeeCount = 0;


            firstArrow = true;
            firstBomb = true;
            firstBoomerang = true;
            firstBow = true;
            firstClock = true;
            firstCompass = true;
            firstFairy = true;
            firstHeart = true;
            firstHeartContainer = true;
            firstKey = true;
            firstMap = true;
            firstRupee = true;

            bow = false;
            map = false;
            compass = false;
            boomerang = false;
            clock = false;

            itemAndCounts = new List<int>();
            itemAndCounts.Add(ArrowCount);
            itemAndCounts.Add(KeyCount);
            itemAndCounts.Add(BombCount);
            itemAndCounts.Add(ArrowCount);
            itemAndCounts.Add(HeartCount);
            itemAndCounts.Add(RupeeCount);

        }
        public void Draw()
        {

        }
    }
}
