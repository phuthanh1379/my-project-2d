using TMPro;
using UnityEngine;

public class IngameUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text itemHighlightLabel;

    private void Awake()
    {
        CutsceneTrigger.CutsceneEvent += OnCutsceneTrigger;
    }

    private void OnDestroy()
    {
        CutsceneTrigger.CutsceneEvent += OnCutsceneTrigger;
    }

    private void OnCutsceneTrigger(string triggerName)
    {
        itemHighlightLabel.text = triggerName;
    }   
}
