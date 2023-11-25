using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TweenUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Button button;
    [SerializeField] private Ease easeType;

    private Sequence _enterSequence;

    private void Awake()
    {
        var scale = button.transform.DOScale(Vector3.one * 1.2f, 0.3f);
        var color = button.image.DOColor(Color.blue, 1f);

        _enterSequence = DOTween.Sequence();
        _enterSequence
            .Append(scale)
            //.Join(color)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(easeType)
            .SetAutoKill(false)
            .OnPause(() =>
            {
                button.transform.localScale = Vector3.one;
            })
            ;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _enterSequence.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _enterSequence.Pause();
    }
}
