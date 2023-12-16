using UnityEngine;

[CreateAssetMenu (menuName = "Inventory/Item", fileName = "ItemData")]
public class InventoryItemData : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;

    public int Id
    {
        get => id; 
    }

    public string ItemName
    {
        get => itemName;
    }

    public Sprite ItemSprite
    {
        get => itemSprite;
    }
}
