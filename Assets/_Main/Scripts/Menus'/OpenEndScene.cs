using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenEndScene : MonoBehaviour
{

    public void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }


}
