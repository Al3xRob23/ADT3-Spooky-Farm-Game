using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] CharacterController characterController;
    public bool inventoryOpen;
    void Start()
    {

        //SimpleFPSController refScript = GetComponent<CharacterController>();
        // characterController = GetComponent<CharacterController>();

        //gameObject.GetComponent<characterController>();
        //characterController = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
        Cursor.visible = true;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            panel.SetActive(!panel.activeInHierarchy);
            if (panel.activeInHierarchy)
            {
                // We know that the game is paused.
                Time.timeScale = 0.0f;
                inventoryOpen = true;
                Cursor.lockState = CursorLockMode.Confined; 
                Cursor.visible = true;
            }
            else
            {
                // We know that the game has been resumed.
                Time.timeScale = 1.0f;
                inventoryOpen = false;
                Cursor.lockState = CursorLockMode.Locked; 
                Cursor.visible = false;
            }
        }
    }
}

