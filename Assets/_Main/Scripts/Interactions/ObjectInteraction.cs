using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour 
{

    public InventoryUI inventoryUI;
    
    void Update() 
    {
        int layerMask = 1 << 5;
        layerMask = ~layerMask;
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Interacted with: " + hit.collider.gameObject.name);

                WorldItem itemHit = hit.collider.GetComponent<WorldItem>();
                if (itemHit != null)
                {
                    inventoryUI.AddItem(itemHit.id);
                    hit.collider.gameObject.SetActive(false);
                }
            }
                
        }   
    }
}
