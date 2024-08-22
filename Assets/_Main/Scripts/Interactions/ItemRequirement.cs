using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemRequirement : MonoBehaviour
{
    public List<ItemID> RequiredItems;

    public UnityEvent OnItemRequirementAccepted = new UnityEvent();
    public UnityEvent OnItemRequirementDeclined = new UnityEvent();


    private void Awake()
    {
        WorldItem.OnItemCollected.AddListener(HandleItemCollected);
    }

    public void AttemptInteraction()
    {
        if (RequiredItems.Count == 0)
        {
            // We picked up all the items.
            OnItemRequirementAccepted?.Invoke();
        }
        else
        {
            // We still need some more items.
            OnItemRequirementDeclined?.Invoke();
        }
    }

    private void HandleItemCollected(ItemID id)
    {
        RequiredItems.Remove(id);
    }
}
