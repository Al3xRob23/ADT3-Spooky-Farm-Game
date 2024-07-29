using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private List<InventoryItem> currentItems = new List<InventoryItem>();

    [SerializeField] private InventoryItem inventoryItemPrefab;
    [SerializeField] private Transform inventoryGridContainer;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        AddItem(ItemID.Key);
        yield return new WaitForSeconds(1f);
        AddItem(ItemID.Potion);
    }

    public void AddItem(ItemID item)
    {
        var newInventoryItem = Instantiate(inventoryItemPrefab);
        newInventoryItem.transform.SetParent(inventoryGridContainer);
        newInventoryItem.SetItemID(item);
        currentItems.Add(newInventoryItem);
    }
}

public enum ItemID
{
    Key,
    Potion,
    Present,
    Sword
}
