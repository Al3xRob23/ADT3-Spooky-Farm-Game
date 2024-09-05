using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public class ItemHoverEvent : UnityEvent<InventoryItem> { }
    public static ItemHoverEvent OnItemPointerEnter = new ItemHoverEvent();
    public static ItemHoverEvent OnItemPointerExit = new ItemHoverEvent();
    public static ItemHoverEvent OnItemClicked = new ItemHoverEvent();

    [SerializeField] private ItemLookup itemLookup;

    [SerializeField] private Image itemImage;
    private ItemDefinition currentItemDefinition;
    public ItemDefinition CurrentItemDefinition { 
        get => currentItemDefinition; 
        private set => currentItemDefinition = value; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnItemPointerEnter?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnItemPointerExit?.Invoke(this);
    }

    public void SetItemID(ItemID itemID)
    {
        ItemDefinition definition = itemLookup.ItemDefinitions.Where(i => i.ItemID == itemID).FirstOrDefault();
        if (definition != null) 
        {
            currentItemDefinition = definition;
            itemImage.sprite = definition.ItemSprite;
        }
    }

    public void HandleItemClicked()
    {
        OnItemClicked?.Invoke(this);
    }
}
