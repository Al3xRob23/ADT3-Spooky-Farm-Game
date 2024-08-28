using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{

    public bool playerClose;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerClose = true;
            animator.SetBool("playerClose", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        {

            PlayerExit();
        }
    }

    public void PlayerExit()
    {
        playerClose = false;
        animator.SetBool("playerClose", false);
    }

}
