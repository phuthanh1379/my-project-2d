using System.Collections.Generic;
using UnityEngine;

public class BottomInventoryController : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> slots = new();
    [SerializeField] private InventoryItem itemPrefab;

    public void DisplayItem(InventoryItemData data)
    {
        if (data == null)
        {
            return;
        }

        var slot = GetSlot();
        if (slot == null)
        {
            return;
        }

        var item = Instantiate(itemPrefab);
        item.SetData(data);
        item.ItemParent = slot.ItemParent;
        item.Snap();
    }

    private InventorySlot GetSlot()
    {
        if (slots == null)
        {
            return null;
        }

        foreach (var slot in slots)
        {
            if (!slot.IsSlotFull)
            {
                return slot;
            }
        }

        return null;
    }
}
