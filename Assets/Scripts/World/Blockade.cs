using DG.Tweening;
using System;
using UnityEngine;

public class Blockade : MonoBehaviour
{
    [SerializeField] private Vector3 endPosition;

    public static event Action StartRemovingBlockade;

    private void Awake()
    {
        CutsceneTrigger.CutsceneEvent += OnCutsceneEvent;
    }

    private void OnDestroy()
    {
        CutsceneTrigger.CutsceneEvent -= OnCutsceneEvent;
    }

    private void OnCutsceneEvent(string triggerName)
    {
        transform
            .DOMove(endPosition, 0.3f)
            .SetDelay(3.25f)
            .OnStart(() =>
            {
                StartRemovingBlockade?.Invoke();
            })
            .Play()
            ;
    }
}
