using System;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private BottomInventoryController bottomInventoryController;
    [SerializeField] private Item itemPrefab;

    private void Awake()
    {
        Item.PickUpItem += OnPickUpItem;
        InventoryDropZone.DropItem += OnDropItem;
    }

    private void OnDestroy()
    {
        Item.PickUpItem -= OnPickUpItem;
        InventoryDropZone.DropItem -= OnDropItem;
    }

    private void OnDropItem(InventoryItemData data, Vector3 mousePosition)
    {
        if (data == null)
        {
            return;
        }

        var item = Instantiate(itemPrefab);
        item.SetData(data);

        var position = Camera.main.ScreenToWorldPoint(mousePosition);
        item.transform.position = new Vector3(position.x, position.y, 0f);
    }

    private void OnPickUpItem(InventoryItemData data)
    {
        bottomInventoryController.DisplayItem(data);
    }
}
