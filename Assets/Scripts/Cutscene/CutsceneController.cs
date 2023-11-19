using UnityEngine;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutsceneDirector;

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
        cutsceneDirector.Play();
    }
}
