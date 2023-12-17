using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryShowcase : MonoBehaviour
{
    [SerializeField] private GameObject showcase;
    [SerializeField] private TMP_Text itemNameLabel;
    [SerializeField] private TMP_Text itemDescriptionLabel;
    [SerializeField] private Image itemImage;

    private void Awake()
    {
        InventoryItem.ShowDisplayItem += OnClickDisplayItem;
        InventoryItem.HideDisplayItem += OnHideDisplayItem;
    }

    private void OnDestroy()
    {
        InventoryItem.ShowDisplayItem -= OnClickDisplayItem;
        InventoryItem.HideDisplayItem -= OnHideDisplayItem;
    }

    private void Start()
    {
        Hide();
    }

    private void OnClickDisplayItem(InventoryItemData data)
    {
        if (data == null)
        {
            return;
        }

        DisplayItem(data);
    }

    private void OnHideDisplayItem()
    {
        Hide();
    }

    private void DisplayItem(InventoryItemData data)
    {
        itemNameLabel.text = data.ItemName;
        itemDescriptionLabel.text = data.ItemDescription;
        itemImage.sprite = data.ItemSprite;
        showcase.SetActive(true);

        showcase.transform.position = Input.mousePosition;
    }

    private void Hide()
    {
        showcase.SetActive(false);
    }
}
