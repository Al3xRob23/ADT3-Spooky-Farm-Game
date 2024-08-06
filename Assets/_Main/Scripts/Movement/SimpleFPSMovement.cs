using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class SimpleFPSController : MonoBehaviour
{

    public bool isGrounded;

    public float movementSpeed = 5.0f;
    public float sprintSpeed = 7.0f;
    public float mouseSensitivity = 2.0f;

    float verticalRotation = 0;
    CharacterController characterController;

    public float Stamina = 10.0f;
public float MaxStamina = 10.0f;
public float currentSpeed;

//---------------------------------------------------------
private float StaminaRegenTimer = 0.0f;

//---------------------------------------------------------
private const float StaminaDecreasePerFrame = 1.0f;
private const float StaminaIncreasePerFrame = 5.0f;
private const float StaminaTimeToRegen = 3.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen

    }


    void Update()
    {
         currentSpeed = movementSpeed;
        // Rotation (Mouse Look)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation += mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;

        characterController.SimpleMove(speed);

        //Sprinting

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
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
    if (isRunning )
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
    }

void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
			isGrounded = true;
        }
    }
    
}
