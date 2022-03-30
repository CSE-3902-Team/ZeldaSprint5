using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.ItemClass;

namespace Sprint0
{
    public class LinkInventory
    {
        private Dictionary<AItem, int> itemAndCount;

        private int rupeeCount;
        private int keyCount;
        private int bombCount;
        private Boolean sword;
        private int bowCount;
        private int mapCount;
        private int arrowCount;
        private int compassCount;
        private int heartCount;
        private int heartContainerCount;

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
        public Boolean Sword
        {
            get { return sword; }
            set { sword = value; }
        }
                
          
    }
}
