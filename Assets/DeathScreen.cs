using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] GameObject panel;


    public void Start()
    {
        //PlayerHealth health = GetComponent<
        gameObject.SetActive(false);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Respawning");
        Time.timeScale = 1f;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Quitting");
    }
    public void ShowMenu()
    {
        panel.SetActive(!panel.activeInHierarchy);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
