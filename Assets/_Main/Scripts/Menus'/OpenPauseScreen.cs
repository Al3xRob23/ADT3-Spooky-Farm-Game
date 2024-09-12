using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPauseScreen : MonoBehaviour
{
    [SerializeField] GameObject panel;
    //[SerializeField] CharacterController characterController;
    public bool PauseMenuOpen;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(!panel.activeInHierarchy);
            if (panel.activeInHierarchy)
            {
                // We know that the game is paused.
                Time.timeScale = 0.0f;
                PauseMenuOpen = true;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                // We know that the game has been resumed.
                Time.timeScale = 1.0f;
                PauseMenuOpen = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

    }
    public void ResumeGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
        PauseMenuOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Quitting");
    }
}
