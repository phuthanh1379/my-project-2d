using Sound.Value;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoundData soundData;

    public static SoundController Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayAudio(string soundName)
    {
        var clip = soundData.GetAudioClip(soundName);
        if (clip == null)
        {
            return;
        }

        audioSource.PlayOneShot(clip);
    }
}
