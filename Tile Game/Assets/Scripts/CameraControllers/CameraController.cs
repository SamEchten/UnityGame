using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;

    public Transform orientation;
    public Rigidbody rb;
    public CharacterController controller;

    //Mouse controls
    float sens = 1.5f;
    float yRotation = 0f;
    float xRotation = 0f;
    float mouseX;
    float mouseY;

    //Movement
    float mSpeed = 10f;
    float horizontalInput;
    float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam = Camera.main;
    }

    void Update()
    {
        getInputs();
    }

    void FixedUpdate()
    {
        move();
    }

    void getInputs()
    {
        float deltaTime = Time.deltaTime;

        //Mouse
        mouseX = Input.GetAxis("Mouse X") * sens;
        mouseY = Input.GetAxis("Mouse Y") * sens;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //keyboard
        horizontalInput = Input.GetAxisRaw("Horizontal") * deltaTime * mSpeed  * 10f;
        verticalInput = Input.GetAxisRaw("Vertical") * deltaTime * mSpeed * 10f;
    }

    void move()
    {
        //Mouse
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        //Keyboard
        Vector3 moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection * 100f, ForceMode.Force);
        //transform.Translate(horizontalInput, 0, verticalInput);
    }
}
