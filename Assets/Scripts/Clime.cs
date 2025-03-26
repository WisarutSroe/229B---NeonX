using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clime : MonoBehaviour
{
    public float moveSpeed = 5f; // Walking speed
    public float climbSpeed = 3f; // Climbing speed
    private CharacterController controller;
    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 2.0f;
    public Transform playerCamera;
    private float xRotation = 0f;
    private float yRotation = 0f;
    [Header("Climbing")]
    private bool isClimbing = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent flipping upside down

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D movement
        float moveZ = Input.GetAxis("Vertical");   // W/S movement
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        if (isClimbing)
        {
            float climbY = Input.GetAxis("Vertical"); // Up/Down movement on ladder
            moveDirection = new Vector3(0, climbY * climbSpeed, 0);
            
        }
        
        else
        {
            moveDirection.y += Physics.gravity.y * Time.deltaTime; // Apply gravity
        }
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false; // Stop climbing when leaving ladder
        }
    }


}
