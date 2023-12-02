using System;
using UnityEngine;

namespace Sound.Value
{
    [Serializable]
    public class Sound
    {
        [SerializeField] private string soundName;
        [SerializeField] private AudioClip clip;

        public string SoundName => soundName;
        public AudioClip Clip => clip;
    }
}