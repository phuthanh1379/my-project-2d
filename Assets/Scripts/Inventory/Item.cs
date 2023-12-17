using Sound.Value;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            return;
        }

        OnPickUp();
    }

    public void SetData(InventoryItemData data)
    {
        this.data = data;
        LoadData(data);
    }

    private void Init()
    {
        LoadData(data);
    }

    private void OnPickUp()
    {
        if (_isInvoked)
        {
            return;
        }

        SoundController.Instance.PlayAudio(SoundName.InvMetal);
        PickUpItem?.Invoke(data);
        _isInvoked = true;
        Destroy(this.gameObject);
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
