using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{

    public Animator animator;
    public bool seesPlayer;
    public Transform playerPos;
    public float speed;
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
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, playerPos.position, Time.deltaTime * speed);
            // The step size is equal to speed times frame time.
            // Rotate towards the player.
            // Calculate the direction from the current object to the target
            Vector3 directionToTarget = playerPos.position - transform.parent.position;

            // Calculate the step size based on the rotation speed and time
            float step = rotationSpeed * Time.deltaTime;

            // Calculate the new direction by rotating towards the target direction
            Vector3 newDirection = Vector3.RotateTowards(transform.parent.forward, directionToTarget, step, 0.0f);

            // Update the rotation of the object to face the new direction
            transform.parent.rotation = Quaternion.LookRotation(newDirection);

            //float singleStep = rotationSpeed * Time.deltaTime;
            //transform.parent.forward = Vector3.RotateTowards(transform.parent.forward, playerPos.position, singleStep, 0.1f);
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
