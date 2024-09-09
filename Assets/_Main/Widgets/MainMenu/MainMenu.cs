using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("GameIntro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public Canvas OptionsCanvas;
    public void OptionsMenu()
    {
        OptionsCanvas.enabled = true;
        
    }

    public void CloseOptionsMenu()
    {
        OptionsCanvas.enabled = false;
    }
}
