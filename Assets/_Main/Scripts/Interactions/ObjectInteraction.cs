using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteraction : MonoBehaviour 
{
    public InventoryUI inventoryUI;
    public Transform camera;
#pragma warning disable 0108

    void Update() 
    {
        int layerMask = 1 << 5;
        layerMask = ~layerMask;
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, 3, layerMask))
            {
                Debug.DrawRay(camera.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Interacted with: " + hit.collider.gameObject.name);

                WorldItem hitWorldItem = hit.collider.GetComponent<WorldItem>();
                if (hitWorldItem != null)
                {
                    if (hitWorldItem.IsCollectableByInteraction)
                    {
                        hitWorldItem.CollectItem();
                    }
                }

                if (hit.collider.TryGetComponent(out ItemRequirement itemReq))
                {
                    itemReq.AttemptInteraction();
                }

                if (hit.collider.TryGetComponent(out FoodItem foodItem))
                {
                    foodItem.ConsumeItem();
                }
            }
                
        }   
    }
}
