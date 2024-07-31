using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour 
    {   
    
    
    
        void Update() 
        {
            int layerMask = 1 << 5;
            layerMask = ~layerMask;
            if (Input.GetKey(KeyCode.E))
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.Log("Did Hit");
                    Debug.Log("Interacted with: " + hit.collider.gameObject.name);
                }else
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.green);
        }
                
            }   
        }
    }
