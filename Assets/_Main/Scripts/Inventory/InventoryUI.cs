using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private List<InventoryItem> currentItems = new List<InventoryItem>();

    [SerializeField] private InventoryItem inventoryItemPrefab;
    [SerializeField] private Transform inventoryGridContainer;

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
    }

    public void RemoveItem()
    {

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
    CollectableFigures
}
