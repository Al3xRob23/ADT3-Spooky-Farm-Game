using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private List<InventoryItem> currentItems = new List<InventoryItem>();

    [SerializeField] private InventoryItem inventoryItemPrefab;
    [SerializeField] private Transform inventoryGridContainer;
    public KeyItemsUI keyItemsUI;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void AddItem(ItemID item)
    {
        var newInventoryItem = Instantiate(inventoryItemPrefab);
        newInventoryItem.transform.SetParent(inventoryGridContainer);
        newInventoryItem.SetItemID(item);
        currentItems.Add(newInventoryItem);
        keyItemsUI.HandleItemAdded(item);
    }

    public void RemoveItem(ItemID itemID)
    {
        InventoryItem itemToDelete = null;
        foreach(var currentItem in currentItems)
        {
            if (currentItem.CurrentItemDefinition.ItemID == itemID)
            {
                // We found the item.
                itemToDelete = currentItem;
                Destroy(currentItem.gameObject);
            }
        }
        if (itemToDelete != null)
        {
            currentItems.Remove(itemToDelete);
        }
    }
}

public enum ItemID
{
    Key,
    MedicPack,
    AmmoPack,
    Shotgun,
    Pitchfork,
    ZombieHead,
    Burger,
    CursedEgg,
    CollectableFigures,
    Torch,
}
