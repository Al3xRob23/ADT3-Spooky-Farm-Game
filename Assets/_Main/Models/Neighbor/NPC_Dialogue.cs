using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    
    public GameObject canvas;
    public GameObject NeighborNPC;
    public Animator Anim;
    public GameObject NPCMarker;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider player)
    {
        canvas.SetActive(true);
        Anim.Play("Idle");
        NeighborNPC.GetComponents<Animator>();
        NPCMarker.SetActive(false);
    }

    private void OnTriggerExit(Collider player)
    {
        canvas.SetActive(false);
        Anim.Play("Dancing");
    }
}