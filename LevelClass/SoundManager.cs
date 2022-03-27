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
        static SoundManager(){
            SoundEffect.MasterVolume = 0.15f;
        }

        
        private SoundEffectInstance Current_BGM;
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
            PuzzleSolved,
            DoMagic,
            UseArrowBoomerang,
            BG_MUSIC
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
                {Sound.SwordSlash,content.Load<SoundEffect>("LOZ_Sword_Slash")}, //Complete
                {Sound.BombDrop, content.Load<SoundEffect>("BombDrop")},     //Complete
                {Sound.BombBlow, content.Load<SoundEffect>("BombBlow")},    //Complete
                {Sound.EnemyHit, content.Load<SoundEffect>("EnemyHit")},
                {Sound.EnemyDie, content.Load<SoundEffect>("EnemyDie")},
                {Sound.LinkHurt, content.Load<SoundEffect>("LinkHurt")},    //Complete
                {Sound.LowHp,    content.Load<SoundEffect>("LowHp")}, 
                {Sound.LinkDie,  content.Load<SoundEffect>("LinkDie")},
                {Sound.NewItem,  content.Load<SoundEffect>("NewItem")},
                {Sound.GetInventoryItem,content.Load<SoundEffect>("GetInventoryItem")},
                {Sound.GetHeartKey, content.Load<SoundEffect>("GetHeartKey")}, //Complete
                {Sound.GetRupee,   content.Load<SoundEffect>("GetRupee")}, //Complete
                {Sound.KeyAppear,  content.Load<SoundEffect>("KeyAppear")}, 
                {Sound.WalkStairs, content.Load<SoundEffect>("WalkStairs")},
                {Sound.PuzzleSolved, content.Load<SoundEffect>("PuzzleSolved")},
                {Sound.DoMagic, content.Load<SoundEffect>("LOZ_MagicalRod") }, //Complete
                {Sound.UseArrowBoomerang, content.Load<SoundEffect>("LOZ_Arrow_Boomerang") }, //Complete
                {Sound.BG_MUSIC, content.Load<SoundEffect>("BG_MUSIC") }
            };
            StartBGM();
        }

        private void StartBGM()
        {
            Current_BGM = soundDict[Sound.BG_MUSIC].CreateInstance();
            Current_BGM.IsLooped = true;
            Current_BGM.Play();
        }

        public void ChangeBGM(Sound music)
        {
            Current_BGM.Pause();
            Current_BGM.Dispose();
            Current_BGM = soundDict[music].CreateInstance();
            Current_BGM.IsLooped = true;
            Current_BGM.Play();
        }
    }
}
