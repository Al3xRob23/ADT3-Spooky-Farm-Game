using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class WorldItem : MonoBehaviour
{
    public ItemID id;

    private InventoryUI inventoryUI;

    public class ItemCollectedEvent : UnityEvent<ItemID> { }
    public static ItemCollectedEvent OnItemCollected = new ItemCollectedEvent();

    public bool IsCollectableByInteraction = true;

    private void Awake()
    {
        inventoryUI = FindObjectOfType<InventoryUI>();
    }

    public void CollectItem()
    {
        inventoryUI.AddItem(id);
        gameObject.SetActive(false);

        OnItemCollected?.Invoke(id);
    }
}
