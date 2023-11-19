using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IngameUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text itemHighlightLabel;
    [SerializeField] private Button button;

    private void Awake()
    {
        CutsceneTrigger.CutsceneEvent += OnCutsceneTrigger;
        button.onClick.AddListener(OnClickButton);
    }

    private void OnDestroy()
    {
        CutsceneTrigger.CutsceneEvent += OnCutsceneTrigger;
        button.onClick.RemoveListener(OnClickButton);
    }

    private void OnCutsceneTrigger(string triggerName)
    {
        itemHighlightLabel.text = triggerName;
    }

    private void OnClickButton()
    {
        var sequence = DOTween.Sequence();
        var scaleTween = button.transform.DOScale(Vector3.one * 1.2f, 1f);
        var scaleBackTween = button.transform.DOScale(Vector3.one, 1f);
        //var moveTween = button.transform.DOMoveX(5f, 2f);
        //var colorTween = button.image.DOColor(Color.red, 2f);
        //var backTween = button.transform.DOMoveX(0f, 2f);

        sequence
            .Append(scaleTween)
            .Append(scaleBackTween)
            .SetLoops(-1)
            .Play()
            ;
    }
}
