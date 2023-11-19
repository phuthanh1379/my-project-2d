using DG.Tweening;
using UnityEngine;

public class Blockade : MonoBehaviour
{
    [SerializeField] private Vector3 endPosition;

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
            ;
    }
}
