using System.Collections.Generic;
using UnityEngine;

namespace Sound.Value
{
    [CreateAssetMenu(menuName = "Sound", fileName = "SoundData")]
    public class SoundData : ScriptableObject
    {
        [SerializeField] private List<Sound> soundList = new();

        public AudioClip GetAudioClip(string soundName)
        {
            if (string.IsNullOrEmpty(soundName))
            {
                return null;
            }

            foreach (var sound in soundList)
            {
                if (string.Equals(soundName, sound.SoundName))
                {
                    return sound.Clip;
                }
            }

            return null;
        }
    }
}