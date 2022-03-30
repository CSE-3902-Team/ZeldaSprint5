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
                LevelManager.Instance.SoundManager.Play(SoundManager.Sound.GetHeartKey);
            }
            else if (item is ItemHeart)
            {
                player.PlayerHp += 2;
                LevelManager.Instance.SoundManager.Play(SoundManager.Sound.GetHeartKey);
            }
            else if (item is ItemKey) 
            {
                LevelManager.Instance.SoundManager.Play(SoundManager.Sound.GetHeartKey);
            }
            else if (item is ItemRupee)
            {
                LevelManager.Instance.SoundManager.Play(SoundManager.Sound.GetRupee);
            }
            else if (item is ItemTriforcePiece)
            {
                LevelManager.Instance.SoundManager.StopBGM();
                LevelManager.Instance.SoundManager.StopLowHpBGM();
                LevelManager.Instance.SoundManager.PlayWinMusic();
            }
            else
            {
                LevelManager.Instance.SoundManager.Play(SoundManager.Sound.GetInventoryItem);
            }

            item.IsPickedUp = true;
        }
    }
}
