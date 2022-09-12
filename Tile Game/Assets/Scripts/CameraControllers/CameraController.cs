using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform orientation;
    public Rigidbody rb;
    public CharacterController controller;

    //Mouse controls
    float sens = 1.5f;
    float yRotation = 0f;
    float xRotation = 0f;

    //Movement
    float mSpeed = 4f;
    float horizontalInput;
    float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseControls();
        move();
    }

    void mouseControls()
    {
        float mouseX = Input.GetAxis("Mouse X") * sens;
        float mouseY = Input.GetAxis("Mouse Y") * sens;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void move()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * mSpeed;
        verticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime * mSpeed;
        transform.Translate(horizontalInput, 0, verticalInput);
    }
}
