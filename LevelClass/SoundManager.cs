using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace Sprint0.LevelClass
{
    public class SoundManager : IDisposable
    {
        static SoundManager(){
            SoundEffect.MasterVolume = 0.10f;
        }

        
        private SoundEffectInstance Level_BGM;
        private SoundEffectInstance LowHp_BGM;
        private SoundEffectInstance Game_Over;
        
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
            BG_MUSIC,
            Triforce,
            GameOver
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
                {Sound.BG_MUSIC, content.Load<SoundEffect>("BG_MUSIC") },
                {Sound.Triforce, content.Load<SoundEffect>("Triforce") },
                {Sound.GameOver, content.Load<SoundEffect>("GameOver") },
            };
            LowHp_BGM = soundDict[Sound.LowHp].CreateInstance();
            LowHp_BGM.IsLooped = true;
            Game_Over = soundDict[Sound.GameOver].CreateInstance();
            StartBGM();
        }

        private void StartBGM()
        {
            Level_BGM = soundDict[Sound.BG_MUSIC].CreateInstance();
            Level_BGM.IsLooped = true;
            Level_BGM.Play();
        }

        public void StopBGM()
        {
            Level_BGM.Pause();
        }

        public void PlayLowHpBGM()
        {
            LowHp_BGM.Play();
        }

        public void StopLowHpBGM()
        {
            LowHp_BGM.Pause();
        }

        public void PlayGameOver()
        {
            Game_Over.Stop();
        }

        public void StopGameOver()
        {
            Game_Over.Stop();
        }

        public void PlayWinMusic()
        {
            Play(Sound.Triforce);
        }


        public void Dispose() 
        {
            StopBGM();
            StopGameOver();
            StopLowHpBGM();
            Level_BGM.Dispose();
            LowHp_BGM.Dispose();
            Game_Over.Dispose();
        }
    }
}
