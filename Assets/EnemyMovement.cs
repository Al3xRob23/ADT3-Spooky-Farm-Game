using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Animator animator;
    public bool seesPlayer;
    public Transform playerPos;
    public int speed;
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (seesPlayer == true)
        {
            transform.parent.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, Time.deltaTime * speed);
            // The step size is equal to speed times frame time.
            float singleStep = rotationSpeed * Time.deltaTime;
            transform.forward = Vector3.RotateTowards(transform.forward, playerPos.position, singleStep, 5.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            seesPlayer = true;
            animator.SetBool("seesPlayer", true);
            playerPos = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            seesPlayer = false;
            animator.SetBool("seesPlayer", false);
        }
    }
}
