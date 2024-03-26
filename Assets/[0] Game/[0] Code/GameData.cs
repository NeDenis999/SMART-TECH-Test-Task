using System;
using UniRx;
using UnityEngine.Audio;

namespace Game
{
    [Serializable]
    public class GameData
    {
        public LevelInstaller LevelInstaller;
        public float Volume;
        public AudioMixerGroup Mixer;
        public IntReactiveProperty Score;
        public IntReactiveProperty EnemyCount;
        public int Level = 1;
        public bool IsPause;
    }
}