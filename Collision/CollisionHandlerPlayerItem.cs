using Microsoft.Xna.Framework;
using System;
using Sprint0.ItemClass;
using Sprint0.LevelClass;

namespace Sprint0.Collision
{
    public class CollisionHandlerPlayerItem : ICollisionHandler
    {
        private AItem item;
        private Player player;


        public CollisionHandlerPlayerItem(Player p, AItem item)
        {
            this.item = item;
            player = p;
        }
        public void HandleCollision()
        {
            if (item is ItemHeartContainer)
            {
                player.MaxHp += 2;
               SoundManager.Instance.Play(SoundManager.Sound.GetHeartKey);
            }
            else if (item is ItemHeart)
            {
                player.PlayerHp += 2;
               SoundManager.Instance.Play(SoundManager.Sound.GetHeartKey);
            }
            else if (item is ItemKey) 
            {
               SoundManager.Instance.Play(SoundManager.Sound.GetHeartKey);
            }
            else if (item is ItemRupee)
            {
               SoundManager.Instance.Play(SoundManager.Sound.GetRupee);
            }
            else if (item is ItemTriforcePiece)
            {
               SoundManager.Instance.Stop(SoundManager.Sound.BG_MUSIC);
               SoundManager.Instance.Stop(SoundManager.Sound.LowHp);
               SoundManager.Instance.Play(SoundManager.Sound.Triforce);
            }
            else
            {
               SoundManager.Instance.Play(SoundManager.Sound.GetInventoryItem);
            }

            item.IsPickedUp = true;
        }
    }
}
