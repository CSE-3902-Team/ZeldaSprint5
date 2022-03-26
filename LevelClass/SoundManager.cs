using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace Sprint0.LevelClass
{
    public class SoundManager
    {

        public enum Sound
        { 
            SwordSlash,
            BombDrop,
            BombBlow,
            EnemyHit,
            EnemyDie,
            LinkHurt,
            LowHp,
            LinkDie,
            NewItem,
            GetInventoryItem,
            GetHeartKey,
            GetRupee,
            KeyAppear,
            WalkStairs,
            PuzzleSolved
        }
        //private SoundEffectInstance levelMusic;
        private Dictionary<Sound, SoundEffect> soundDict;
        public void Play(Sound s)
        {
            SoundEffect target;
            soundDict.TryGetValue(s, out target);
            target.Play();
        }
        public void LoadAllSounds(ContentManager content)
        {
            soundDict = new Dictionary<Sound, SoundEffect>
            {
                {Sound.SwordSlash,content.Load<SoundEffect>("LOZ_Sword_Slash")},
                {Sound.BombDrop,content.Load<SoundEffect>("BombDrop")},
                {Sound.BombBlow, content.Load<SoundEffect>("BombBlow")},
                {Sound.EnemyHit, content.Load<SoundEffect>("EnemyHit")},
                {Sound.EnemyDie, content.Load<SoundEffect>("EnemyDie")},
                {Sound.LinkHurt, content.Load<SoundEffect>("LinkHurt")},
                {Sound.LowHp,    content.Load<SoundEffect>("LowHp")},
                {Sound.LinkDie,  content.Load<SoundEffect>("LinkDie")},
                {Sound.NewItem,  content.Load<SoundEffect>("NewItem")},
                {Sound.GetInventoryItem,content.Load<SoundEffect>("GetInventoryItem")},
                {Sound.GetHeartKey, content.Load<SoundEffect>("GetHeartKey")},
                {Sound.GetRupee,   content.Load<SoundEffect>("GetRupee")},
                {Sound.KeyAppear,  content.Load<SoundEffect>("KeyAppear")},
                {Sound.WalkStairs, content.Load<SoundEffect>("WalkStairs")},
                {Sound.PuzzleSolved, content.Load<SoundEffect>("PuzzleSolved")},
            };
        }
    }
}
