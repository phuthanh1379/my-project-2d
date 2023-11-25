using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private string soundName;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<SoundData> soundData = new List<SoundData>();

    private void Awake()
    {
        Blockade.StartRemovingBlockade += OnStartRemovingBlockade;
    }

    private void OnDestroy()
    {
        Blockade.StartRemovingBlockade -= OnStartRemovingBlockade;
    }

    private void OnStartRemovingBlockade()
    {
        PlayAudio(soundName);
    }

    public void PlayAudio(string name)
    {
        foreach (var data in soundData)
        {
            if (string.Equals(name, data.name))
            {
                audioSource.PlayOneShot(data.clip);
                return;
            }
        }
    }
}
