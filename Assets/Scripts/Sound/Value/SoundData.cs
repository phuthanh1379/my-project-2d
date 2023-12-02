using System.Collections.Generic;
using UnityEngine;

namespace Sound.Value
{
    public class SoundData : ScriptableObject
    {
        [SerializeField] private List<Sound> soundList = new();
    }
}