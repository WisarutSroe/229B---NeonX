using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float mouseSensitivity = 2.0f; // Mouse sensitivity
    public Transform playerBody; // Reference to the player body
    private float xRotation = 0f; // Rotation around the X-axis (vertical)
    private float yRotation = 0f; // Rotation around the Y-axis (horizontal)
    public float moveSpeed = 5f; // Player movement speed
   
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the camera vertically (up and down) while clamping the rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the vertical camera rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player body horizontally
        yRotation += mouseX;
        playerBody.rotation = Quaternion.Euler(0f, yRotation, 0f);

        // Get input for movement (WASD or Arrow keys)
        float moveX = Input.GetAxis("Horizontal"); // Left and Right movement (A/D or Arrow keys)
        float moveZ = Input.GetAxis("Vertical");   // Forward and Backward movement (W/S or Arrow keys)

        // Create movement vector
        Vector3 moveDirection = (transform.forward * moveZ + transform.right * moveX).normalized;

        // Move the player
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        
    }
}
