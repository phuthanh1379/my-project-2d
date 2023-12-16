using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private InventoryItemData data;

    public static event Action<InventoryItemData> PickUpItem;

    private bool _isInvoked = false;

    private void Awake()
    {
        Init();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        if (_isInvoked)
        {
            return;
        }

        PickUpItem?.Invoke(data);
        _isInvoked = true;
        Destroy(this.gameObject);
    }

    private void Init()
    {
        LoadData(data);
    }

    private void LoadData(InventoryItemData data)
    {
        if (data == null)
        {
            return;
        }

        SetSprite(data.ItemSprite);
    }

    private void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
