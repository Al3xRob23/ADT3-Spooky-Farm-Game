using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] GameObject playerhud;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerhud.SetActive(!playerhud.activeInHierarchy);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
    }
}
