using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public InventoryUI inventoryUI;
    public EquipItemOnPlayer equipItemOnPlayer;
    public EquipTorch equipTorch;
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
                equipItemOnPlayer.EquipItem();
                break;
            case ItemID.Burger:
                Debug.Log("Used Item");
                playerHealth.TakeDamage(-10);
                inventoryUI.RemoveItem(ItemID.MedicPack);
                break;
            case ItemID.Torch:
                Debug.Log("Used Torch");
                equipTorch.EquipTorchItem();
                break;
        }
    }

}


