using Microsoft.Xna.Framework;
using System;
using Sprint0.ItemClass;
using Sprint0.LevelClass;

namespace Sprint0.Collision
{
    public class CollisionHandlerPlayerItem : ICollisionHandler
    {
        private AItem item;


        public CollisionHandlerPlayerItem(AItem item)
        {
            this.item = item;

        }
        public void HandleCollision()
        {
            if (item is ItemHeart || item is ItemKey || item is ItemHeartContainer)
            {
                LevelManager.Instance.SoundManager.Play(SoundManager.Sound.GetHeartKey);
            }
            else if (item is ItemRupee)
            {
                LevelManager.Instance.SoundManager.Play(SoundManager.Sound.GetRupee);
            }
            else 
            { 
                LevelManager.Instance.SoundManager.Play(SoundManager.Sound.GetInventoryItem);
            }

            item.IsPickedUp = true;
        }
    }
}
