using Sound.Value;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private InventoryItemData data;

    public Transform ItemParent 
    {
        get; set;
    }

    private void Awake()
    {
        Init();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ItemParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        itemImage.raycastTarget = false;

        SoundController.Instance.PlayAudio(SoundName.InvRing);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var mousePosition = Input.mousePosition;
        transform.position = new Vector2(mousePosition.x, mousePosition.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Snap();
        itemImage.raycastTarget = true;
    }

    public void Snap()
    {
        transform.SetParent(ItemParent);
        rectTransform.anchoredPosition = Vector2.zero;
    }

    private void Init()
    {
        ItemParent = transform.parent;
        LoadData(data);
    }

    public void LoadData(InventoryItemData itemData)
    {
        if (itemData == null)
        {
            return;
        }

        SetSprite(itemData.ItemSprite);
    }

    private void SetSprite(Sprite sprite)
    {
        itemImage.sprite = sprite;
    }
}
