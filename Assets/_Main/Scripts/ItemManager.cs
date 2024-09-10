using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public InventoryUI inventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        InventoryItem.OnItemClicked.AddListener(HandleItemActivated);
    }

    public void HandleItemActivated(InventoryItem inventoryItem)
    {
        switch (inventoryItem.CurrentItemDefinition.ItemID)
        {
            case ItemID.MedicPack:
                Debug.Log("Used Item");
                playerHealth.TakeDamage(-20);
                inventoryUI.RemoveItem(ItemID.MedicPack);
                break;
            case ItemID.Pitchfork:
                Debug.Log("Equipped Pitchfork");
                break;
        }
    }

}


