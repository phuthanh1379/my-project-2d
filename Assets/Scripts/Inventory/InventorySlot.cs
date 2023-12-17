using Sound.Value;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerDownHandler
{
    [SerializeField] private Transform itemParent;
    [SerializeField] private GameObject stackCounter;
    [SerializeField] private TMP_Text stackCounterLabel;

    public bool IsSlotFull => itemParent.transform.childCount > 0;
    public Transform ItemParent => itemParent;

    private InventoryItem Item
    {
        get
        {
            if (_stackCount > 0)
            {
                return itemParent.transform.GetChild(0).GetComponent<InventoryItem>();
            }
            else
            {
                return null;
            }
        }
    }
    //private int StackCount => itemParent.transform.childCount;
    private int _stackCount;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _stackCount = default;

        if (IsSlotFull)
        {
            _stackCount = itemParent.transform.childCount;
        }

        CheckStack();
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
            // Check if stackable
            if (!CheckStackable(Item, item))
            {
                // Swap
                Swap(Item, item);
                CheckStack();
                return;
            }
        }

        item.ItemParent = itemParent;
        _stackCount += 1;
        CheckStack();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_stackCount <= 1)
        {
            _stackCount = 0;
            return;
        }

        _stackCount -= 1;
        CheckStack();
    }

    private void Swap(InventoryItem thisItem, InventoryItem otherItem)
    {
        (thisItem.ItemParent, otherItem.ItemParent) = (otherItem.ItemParent, thisItem.ItemParent);
        thisItem.Snap();
    }

    private void CheckStack()
    {
        if (_stackCount > 1)
        {
            stackCounter.SetActive(true);
        }
        else
        {
            stackCounter.SetActive(false);
        }

        stackCounterLabel.text = _stackCount.ToString();
    }

    private static bool CheckStackable(InventoryItem itemA, InventoryItem itemB)
        => (itemA.Data.Id == itemB.Data.Id) && itemA.Data.Stackable && itemB.Data.Stackable;
}
