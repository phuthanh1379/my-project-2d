using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngameUIController : MonoBehaviour
{
    [SerializeField] private Image itemHighlightImage;

    private void Awake()
    {
        ParticleTrigger.PickUpItem += OnPickUpItem;
    }

    private void Start()
    {
        itemHighlightImage.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        ParticleTrigger.PickUpItem -= OnPickUpItem;
    }

    private void OnPickUpItem(Sprite sprite)
    {
        itemHighlightImage.sprite = sprite;
        itemHighlightImage.gameObject.SetActive(true);
    }
}
