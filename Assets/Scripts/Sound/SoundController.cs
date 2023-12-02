using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    // [SerializeField] private List<SoundData> soundData = new List<SoundData>();

    public static SoundController Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayAudio(string soundName)
    {
        // foreach (var data in soundData)
        // {
        //     if (!string.Equals(soundName, data.name))
        //     {
        //         continue;
        //     }
        //     
        //     audioSource.PlayOneShot(data.clip);
        //     return;
        // }
    }
}
