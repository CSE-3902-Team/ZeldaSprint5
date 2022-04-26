using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace Sprint0.PlayerClass
{
    public class PlayerFirstItem : IPlayerState
    {
        private Player player;
        private int currentFrame;
        private int TOTAL_FRAMES = 90;
        private static Dictionary<ItemType, Rectangle> dict = new Dictionary<ItemType, Rectangle>
        {
            {ItemType.Rupee, new Rectangle(2894,2444,134,298) },
            {ItemType.Key,new Rectangle(751,2444,134,298)}, 
            {ItemType.Bomb,new Rectangle(2268,2449,134,294)},
            {ItemType.Boomerang,new Rectangle(1109,2483,131,266) },
            {ItemType.Arrow,new Rectangle(1682,2449,134,294)},
            {ItemType.Heart,new Rectangle(568,2493,134,248)}, 
            {ItemType.HeartCountainer,new Rectangle(2429,2473,134,294)},
            {ItemType.Compass,new Rectangle(2579,2482,134,294)},
            {ItemType.Fairy,new Rectangle(1462,2452,134,294)},
            {ItemType.Map,new Rectangle(927,2451,131,293)},
            {ItemType.Clock,new Rectangle(1301,2452,133,294)},
            {ItemType.Bow, new Rectangle(2744,2447,133,290) },
            {ItemType.SpecialBoomerang, new Rectangle(1890,2507,133,240)},
            {ItemType.Candle,new Rectangle(3040,2459,133,240) }
        };

        public PlayerFirstItem(Player instance, ItemType heldItem)
        {
            player = instance;
            currentFrame = 1;
            player.SourceRectangle = dict[heldItem];
        }

        public enum ItemType
        {
            Rupee,
            Key,
            Bomb,
            Boomerang,
            Bow,
            Clock,
            Arrow,
            Heart,
            HeartCountainer,
            Compass,
            Fairy,
            Map,
            SpecialBoomerang,
            Candle,
        }

        public void ChangeDirection(Player.Directions dir)
        {
            return;
        }

        public void Update()
        {

            if (currentFrame > TOTAL_FRAMES)
            {
                player.State = new PlayerDownIdle(player);

            }
            player.DrawOffset = new Vector2(0, 0);
            player.CollisionOffsetX = new Vector2(0, 0);
            player.CollisionOffsetY = new Vector2(0, 0);
            currentFrame++;
        }

        public void DamageLink(Player.Directions dir)
        {
            return;
        }

        public void Attack()
        {
            return;
        }

        

        

    }
}