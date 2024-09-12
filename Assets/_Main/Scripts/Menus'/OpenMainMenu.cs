using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenMainMenu : MonoBehaviour
{
    public void OpenMainMenuOnEndGame()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Cursor set visible");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

}
