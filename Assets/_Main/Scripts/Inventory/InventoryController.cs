using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] CharacterController characterController;
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
            Time.timeScale = 0.0f;
            panel.SetActive(!panel.activeInHierarchy);

        }
    }
}

