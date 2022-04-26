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
        public static SoundManager instance;

        static SoundManager() {
            SoundEffect.MasterVolume = .5f;
        }

        public static SoundManager Instance { get { return instance; } }

        public SoundManager()
        {
            instance = this;
        }

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
            GameOver,
            Credits,
            MainMenu,
            Boss,
            BossLowHp,
            BossDead,
        }

        private static Dictionary<Sound, SoundEffectInstance> soundDict;
        public void Play(Sound s)
        {
            soundDict[s].Play();
        }

        public void Stop(Sound s)
        {
            soundDict[s].Stop();
        }

        public void PauseAllSounds()
        {
            foreach (Sound key in Enum.GetValues(typeof(Sound)))
            {
                soundDict[key].Stop();
            }
        }

        public void LoadAllSounds(ContentManager content)
        {
            soundDict = new Dictionary<Sound, SoundEffectInstance>
            {
                {Sound.SwordSlash,content.Load<SoundEffect>("LOZ_Sword_Slash").CreateInstance()}, 
                {Sound.BombDrop, content.Load<SoundEffect>("BombDrop").CreateInstance()},     
                {Sound.BombBlow, content.Load<SoundEffect>("BombBlow").CreateInstance()},    
                {Sound.EnemyHit, content.Load<SoundEffect>("EnemyHit").CreateInstance()},
                {Sound.EnemyDie, content.Load<SoundEffect>("EnemyDie").CreateInstance()},
                {Sound.LinkHurt, content.Load<SoundEffect>("LinkHurt").CreateInstance()},    
                {Sound.LowHp,    content.Load<SoundEffect>("LowHp").CreateInstance()}, 
                {Sound.LinkDie,  content.Load<SoundEffect>("LinkDie").CreateInstance()},
                {Sound.NewItem,  content.Load<SoundEffect>("NewItem").CreateInstance()},
                {Sound.GetInventoryItem,content.Load<SoundEffect>("GetInventoryItem").CreateInstance()}, 
                {Sound.GetHeartKey, content.Load<SoundEffect>("GetHeartKey").CreateInstance()}, 
                {Sound.GetRupee,   content.Load<SoundEffect>("GetRupee").CreateInstance()}, 
                {Sound.KeyAppear,  content.Load<SoundEffect>("KeyAppear").CreateInstance()}, 
                {Sound.WalkStairs, content.Load<SoundEffect>("WalkStairs").CreateInstance()},
                {Sound.PuzzleSolved, content.Load<SoundEffect>("PuzzleSolved").CreateInstance()},
                {Sound.DoMagic, content.Load<SoundEffect>("LOZ_MagicalRod").CreateInstance() }, 
                {Sound.UseArrowBoomerang, content.Load<SoundEffect>("LOZ_Arrow_Boomerang").CreateInstance() }, 
                {Sound.BG_MUSIC, content.Load<SoundEffect>("BG_MUSICV2").CreateInstance() }, 
                {Sound.Triforce, content.Load<SoundEffect>("Triforce").CreateInstance() }, 
                {Sound.GameOver, content.Load<SoundEffect>("GameOver").CreateInstance() }, 
                {Sound.Credits, content.Load<SoundEffect>("CreditsBGM").CreateInstance() }, 
                {Sound.MainMenu, content.Load<SoundEffect>("MainMenu").CreateInstance() },
                {Sound.Boss, content.Load<SoundEffect>("Boss").CreateInstance() },
                {Sound.BossLowHp, content.Load<SoundEffect>("BossLowHp").CreateInstance() },
                {Sound.BossDead, content.Load<SoundEffect>("Bossdeaad").CreateInstance() },
            };
            soundDict[Sound.LowHp].IsLooped = true;
            soundDict[Sound.BG_MUSIC].IsLooped = true;
            soundDict[Sound.GameOver].IsLooped = true;
            soundDict[Sound.Credits].IsLooped = true;
            soundDict[Sound.MainMenu].IsLooped = true;
            soundDict[Sound.Boss].IsLooped = true;
            soundDict[Sound.BossLowHp].IsLooped = true;
            soundDict[Sound.BossDead].IsLooped = false;
        }


        public void Dispose() 
        {
            foreach (Sound key in Enum.GetValues(typeof(Sound)))
            {
                soundDict[key].Stop();
                soundDict[key].Dispose();
            }
        }
    }
}
