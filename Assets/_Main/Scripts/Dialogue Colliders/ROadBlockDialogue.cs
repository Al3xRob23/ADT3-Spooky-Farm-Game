using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROadBlockDialogue : MonoBehaviour
{
    public GameObject canvas;
    
    void OnTriggerEnter(Collider player)
    {
        canvas.SetActive(true);
    }

}

