using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using static UnityEngine.UI.Image;
//using UnityEditor.PackageManager;

public class SimpleFPSController : MonoBehaviour
{
    private HighlightInteractable lastViewedInteractable;

    public bool isGrounded;
    private Vector3 velocity;
    public float gravity = -9.81f;

    public float movementSpeed = 5.0f;
    public float sprintSpeed = 7.0f;
    public float mouseSensitivity = 2.0f;

#pragma warning disable IDE0051 // Remove unused private members
    float verticalRotation = 0;
#pragma warning restore IDE0051 // Remove unused private members
    CharacterController characterController;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    Camera camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    public float Stamina = 10.0f;
    public float MaxStamina = 10.0f;
    public float currentSpeed;

    //---------------------------------------------------------
    private float StaminaRegenTimer = 0.0f;

    //---------------------------------------------------------
    private const float StaminaDecreasePerFrame = 1.0f;
    private const float StaminaIncreasePerFrame = 5.0f;
    private const float StaminaTimeToRegen = 3.0f;
    public float verticalLookLimit = 80f;

    private float xRotation;
    private float mouseY;


    //Animations
    public Animator animator;

    RaycastHit hit;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
        camera = Camera.main;

#pragma warning disable CS0168 // Variable is declared but never used
        RaycastHit hit;
#pragma warning restore CS0168 // Variable is declared but never used
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

    }

    //private void FixedUpdate()
    //{
    //    transform.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);
    //    Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation * mouseSensitivity * Time.deltaTime, 0, 0);
    //}


    void Update()
    {
        currentSpeed = movementSpeed;
        isGrounded = characterController.isGrounded;
        //// Rotation (Mouse Look)
        //mouseX = Input.GetAxis("Mouse X");
        //mouseY = -Input.GetAxis("Mouse Y");
        //verticalRotation += mouseY;
        //verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);


        //// Movement
        //float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        //float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        //Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        //speed = transform.rotation * speed;

        //characterController.SimpleMove(speed);
        // Player Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * currentSpeed * Time.deltaTime);

        // Gravity.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to ensure grounded state
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit);

        if (Time.timeScale != 0)
        {
            camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        //Looking Raycast
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Interactable");
        Transform cameraTransform = Camera.main.transform;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, 3, layerMask))
        {
            Debug.DrawRay(camera.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.collider.gameObject.TryGetComponent(out HighlightInteractable highlightInteractable))
            {
                //Debug.Log("Interacted with: " + hit.collider.gameObject.name);
                highlightInteractable.GetComponent<HighlightInteractable>().Highlight();
                lastViewedInteractable = highlightInteractable;
            }

        }else if(lastViewedInteractable != null)
        {
            lastViewedInteractable.UnHighlight();

        }



            //Sprinting

            bool isRunning = (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W));
        bool isNotRunning = Input.GetKeyUp(KeyCode.LeftShift);


        if (isRunning)
        {
            Stamina = Mathf.Clamp(Stamina - (StaminaDecreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
            StaminaRegenTimer = 2.0f;
        }
        else if (Stamina < MaxStamina)
        {
            if (StaminaRegenTimer >= StaminaTimeToRegen)
                Stamina = Mathf.Clamp(Stamina + (StaminaIncreasePerFrame * Time.deltaTime), 1.0f, MaxStamina);
            else
                StaminaRegenTimer += Time.deltaTime;
        }
        if (isRunning)
        {
            movementSpeed = sprintSpeed;
        }
        if (isRunning && Stamina == 0.0f)
        {
            movementSpeed = 2f;
        }
        else if (isNotRunning)
        {
            movementSpeed = 3.0f;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("isStabbing", true);
        }
        else
        {
            animator.SetBool("isStabbing", false);
        }

        //Attacking enemies 
        //Replace with animation collision script
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
            

        //    if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, 3, layerMask))
        //    {
        //        Debug.DrawRay(camera.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //        Debug.Log("Interacted with: " + hit.collider.gameObject.name);

        //        if (hit.collider.gameObject.CompareTag("Enemy"))
        //        {
        //            Debug.Log("Zombie");
        //            // Ensure the enemy has an EnemyHealth component
        //            if (hit.collider.gameObject.TryGetComponent(out EnemyHealth enemyHealth)) 
        //            {
        //                enemyHealth.TakeDamage(); // Call the method to apply damage

        //                if (enemyHealth.currentHealth <= 0)
        //                {
        //                    enemyHealth.RemoveEnemy();
        //                }
        //            }

        //        }

#pragma warning disable CS8321 // Local function is declared but never used
                void OnCollisionStay(Collision collision)
                {
                    if (collision.gameObject.tag == "Ground")
                    {
                        isGrounded = true;
                    }
                }
#pragma warning restore CS8321 // Local function is declared but never used

        //    }
        //}
    }

    public void EnemyHit()
    {
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Enemy");
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, 3, layerMask))
        {
            Debug.DrawRay(camera.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Interacted with: " + hit.collider.gameObject.name);

            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Zombie");
                // Ensure the enemy has an EnemyHealth component
                if (hit.collider.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
                {
                    enemyHealth.TakeDamage(); // Call the method to apply damage

                    if (enemyHealth.currentHealth <= 0)
                    {
                        enemyHealth.RemoveEnemy();
                    }
                }

            }
        }
    }
}
