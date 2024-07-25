using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDescriptionContainer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemTitle;
    [SerializeField] private TextMeshProUGUI itemDescription;

    public void Start()
    {
        InventoryItem.OnItemPointerEnter.AddListener(HandleItemPointerEnter);
        InventoryItem.OnItemPointerExit.AddListener(HandleItemPointerExit);
    }

    private void HandleItemPointerEnter(InventoryItem item)
    {
        itemTitle.text = item.CurrentItemDefinition.ItemName;
        itemDescription.text = item.CurrentItemDefinition.ItemDescription;
    }

    private void HandleItemPointerExit(InventoryItem item)
    {
        itemTitle.text = "";
        itemDescription.text = "";
    }

}
