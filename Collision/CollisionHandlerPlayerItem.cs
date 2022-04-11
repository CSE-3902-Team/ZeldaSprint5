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
            if (item is ItemHeartContainer)
            {
                player.MaxHp += 2;
               SoundManager.Instance.Play(SoundManager.Sound.GetHeartKey);
                inventory.FirstHeartContainer = false;

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

                SoundManager.Instance.Play(SoundManager.Sound.GetHeartKey);
                inventory.FirstHeart = false;
            }
            else if (item is ItemKey) 
            {
               SoundManager.Instance.Play(SoundManager.Sound.GetHeartKey);
                inventory.KeyCount++;
                inventory.FirstKey = false;
                Console.WriteLine(inventory.KeyCount);
            }
            else if (item is ItemRupee)
            {
               SoundManager.Instance.Play(SoundManager.Sound.GetRupee);
                inventory.RupeeCount++;
                inventory.FirstRupee = false;
            }
            else if (item is ItemTriforcePiece)
            {
               player.State = new PlayerTriforce(player);
               SoundManager.Instance.Stop(SoundManager.Sound.BG_MUSIC);
               SoundManager.Instance.Stop(SoundManager.Sound.LowHp);
               SoundManager.Instance.Play(SoundManager.Sound.Triforce);
            }
            else if (item is ItemArrow)
            {
                SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                inventory.FirstArrow = false;
                inventory.ArrowCount++;
            }
            else if (item is ItemBomb)
            {
               SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                inventory.FirstBomb = false;
                inventory.BombCount++;
            }
            else if (item is ItemBow)
            {
                SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                inventory.FirstBow = false;
                inventory.Bow = true;
            }
            else if (item is ItemClock)
            {
                SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                inventory.FirstClock = false;
                inventory.Clock = true;
            }
            else if (item is ItemCompass)
            {
                SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                inventory.FirstCompass = false;
                inventory.Compass = true;
            }
            else if (item is ItemFairy)
            {
                SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                inventory.FirstFairy = false;
            }
            else if (item is ItemMap)
            {
                SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                inventory.FirstMap = false;
                inventory.Map = true;
            }
            else if (item is ItemWoodenBoomerang)
            {
                SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
                inventory.FirstBoomerang = false;
                inventory.Boomerang = true;
            }

            item.IsPickedUp = true;
        }
    }
}
