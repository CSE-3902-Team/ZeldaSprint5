using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.ItemClass;

namespace Sprint0
{
    public class LinkInventory
    {
        private List<int> itemCounts;

        private int rupeeCount;
        private int keyCount;
        private int bombCount;
        private int arrowCount;
        private int heartCount;
        private int heartContainerCount;

        private Boolean sword;
        private Boolean bow;
        private Boolean map;
        private Boolean compass;
        private Boolean boomerang;
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
        public Boolean Sword
        {
            get { return sword; }
            set { sword = value; }
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

        public LinkInventory()
        {
            rupeeCount = 0;
            keyCount = 0;
            bombCount = 0;
            arrowCount = 0;
            heartCount = 6;
            heartContainerCount = 3;

            sword = false;
            bow = false;
            map = false;
            compass = false;
            boomerang = false;

            itemCounts = new List<int>();
            itemCounts.Add(RupeeCount);
            itemCounts.Add(KeyCount);
            itemCounts.Add(BombCount);
            itemCounts.Add(ArrowCount);
            itemCounts.Add(HeartCount);
            itemCounts.Add(HeartContainerCount);

        }

        public void Update()
        {
            
        }

    }
}
