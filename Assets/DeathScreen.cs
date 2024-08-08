using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    public void Start()
    {
        //PlayerHealth health = GetComponent<
        gameObject.SetActive(false);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToMenu()
    {
        //SceneManager.LoadScene(1);
        Application.Quit();
    }
}
