using Microsoft.Xna.Framework;
using System;
using Sprint0.ItemClass;
using Sprint0.LevelClass;
using Sprint0.PlayerClass;

namespace Sprint0.Collision
{
    public class CollisionHandlerPlayerItem : ICollisionHandler
    {
        private AItem item;
        private Player player;
        private LinkInventory inventory;


        public CollisionHandlerPlayerItem(Player p, AItem item)
        {
            this.item = item;
            player = p;
            inventory = player.Inventory;
        }
        public void HandleCollision()
        {
            if (player.PlayerHp == 0)
            {
                return;
            }
            if (item is ItemHeartContainer)
            {
                if (player.Inventory.FirstHeartContainer)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.HeartCountainer);
                    inventory.FirstHeartContainer = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetHeartKey);
                }
                player.MaxHp ++;
                if ((player.PlayerHp + 2) <= player.MaxHp)
                {
                    player.PlayerHp += 2;

                }else if ((player.PlayerHp + 1) <= player.MaxHp)
                {
                    player.PlayerHp++;
                }

            }
            else if (item is ItemHeart)
            {
                if((player.PlayerHp + 2) <= player.MaxHp)
                {
                    player.PlayerHp += 2;

                }
                else if((player.PlayerHp + 1) <= player.MaxHp){
                    player.PlayerHp++;
                }

                if (player.Inventory.FirstHeart)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Heart);
                    inventory.FirstHeart = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetHeartKey);
                }
                
            }
            else if (item is ItemKey) 
            {
                if (player.Inventory.FirstKey)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Key);
                    inventory.FirstKey = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetHeartKey);
                }
                inventory.KeyCount++;
                
            }
            else if (item is ItemRupee)
            {
                if (player.Inventory.FirstRupee)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Rupee);
                    inventory.FirstRupee = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetRupee);
                }
                inventory.RupeeCount++;
            }
            else if (item is ItemTriforcePiece)
            {
               player.State = new PlayerTriforce(player);
               SoundManager.Instance.PauseAllSounds();
               SoundManager.instance.Play(SoundManager.Sound.Credits);
            }
            else if (item is ItemArrow)
            {
                if (player.Inventory.FirstArrow)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Arrow);
                    inventory.FirstArrow = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                }
                inventory.Arrow = true;
            }
            else if (item is ItemSpecialArrow)
            {
                if (player.Inventory.FirstSpecialArrow)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Arrow);
                    inventory.FirstSpecialArrow = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                }
                inventory.SpecialArrow = true;
            }
            else if (item is ItemCandle)
            {
                if (!player.Inventory.Candle)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Candle);
                    inventory.Candle = true;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                }
            }
            else if (item is ItemBomb)
            {
                if (player.Inventory.FirstBomb)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Bomb);
                    inventory.FirstBomb = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                }
                inventory.BombCount++;
            }
            else if (item is ItemBow)
            {
                if (player.Inventory.FirstBow)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Bow);
                    inventory.FirstBow = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                }
                inventory.Bow = true;
            }
            else if (item is ItemClock)
            {
                if (player.Inventory.FirstClock)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Clock);
                    inventory.FirstClock = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                }
                inventory.Clock = true;
            }
            else if (item is ItemCompass)
            {
                if (player.Inventory.FirstCompass)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Compass);
                    inventory.FirstCompass = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                }
                inventory.Compass = true;
            }
            else if (item is ItemFairy)
            {
                if (player.Inventory.FirstFairy)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Fairy);
                    inventory.FirstFairy = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                }
                SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
            }
            else if (item is ItemSpecialBoomerang)
            {
                if (player.Inventory.FirstSpecialBomerang)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.SpecialBoomerang);
                    inventory.FirstSpecialBomerang = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                }
                SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                inventory.SpecialBoomerang = true;
            }
            else if (item is ItemMap)
            {
                if (player.Inventory.FirstMap)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Map);
                    inventory.FirstMap = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                }
                inventory.Map = true;
            }
            else if (item is ItemWoodenBoomerang)
            {
                if (player.Inventory.FirstBoomerang)
                {
                    SoundManager.Instance.Play(SoundManager.Sound.NewItem);
                    player.State = new PlayerFirstItem(player, PlayerFirstItem.ItemType.Boomerang);
                    inventory.FirstBoomerang = false;
                }
                else
                {
                    SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                }
                inventory.Boomerang = true;
            }

            item.IsPickedUp = true;
        }
    }
}
