using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float panSpeed = 1f;
    public float border = 15f;
    private Vector3 startPos;
    public float step;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 camPos = transform.position;

        //Debug.Log(mousePos);
        //Debug.Log(Screen.height);

        // Reset position to the start position -> 
        if (Input.GetKeyDown(KeyCode.R))
        {
            camPos = startPos;
        }

        if (mousePos.y >= Screen.height - border)
        {
            camPos.z += panSpeed * Time.deltaTime;
        }
        if (mousePos.y <= border)
        {
            camPos.z -= panSpeed * Time.deltaTime;
        }
        if (mousePos.x >= Screen.width - border)
        {
            camPos.x += panSpeed * Time.deltaTime;
        }
        if (mousePos.x <= border)
        {
            camPos.x -= panSpeed * Time.deltaTime;
        }

        transform.position = camPos;
    }
}
