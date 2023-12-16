using Sound.Value;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Transform itemParent;

    public bool IsSlotFull => transform.childCount > 0;
    public Transform ItemParent => itemParent;

    private InventoryItem Item
    {
        get; set; 
    }

    private void Start()
    {
        if (IsSlotFull)
        {
            var item = transform.GetChild(0).GetComponent<InventoryItem>();
            if (item != null)
            {
                Item = item;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (item == null)
        {
            return;
        }

        SoundController.Instance.PlayAudio(SoundName.InvRing);

        if (IsSlotFull)
        {
            // Swap
            Swap(Item, item);
            Item = item;
            return;
        }

        item.ItemParent = itemParent;
        Item = item;
    }

    private void Swap(InventoryItem thisItem, InventoryItem otherItem)
    {
        (thisItem.ItemParent, otherItem.ItemParent) = (otherItem.ItemParent, thisItem.ItemParent);
        thisItem.Snap();
    }
}
