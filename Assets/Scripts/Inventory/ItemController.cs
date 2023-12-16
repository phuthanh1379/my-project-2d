using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private BottomInventoryController bottomInventoryController;

    private void Awake()
    {
        Item.PickUpItem += OnPickUpItem;
    }

    private void OnDestroy()
    {
        Item.PickUpItem -= OnPickUpItem;
    }

    private void OnPickUpItem(InventoryItemData data)
    {
        bottomInventoryController.DisplayItem(data);
    }
}
