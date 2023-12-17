using Sound.Value;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDropZone : MonoBehaviour, IDropHandler
{
    public static event Action<InventoryItemData, Vector3> DropItem;

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (item == null)
        {
            return;
        }

        OnDropItem(item);
    }

    private void OnDropItem(InventoryItem item)
    {
        SoundController.Instance.PlayAudio(SoundName.InvMetal);

        DropItem?.Invoke(item.Data, Input.mousePosition);
        Destroy(item.gameObject);
    }
}
