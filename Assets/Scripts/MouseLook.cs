using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform playerBody;

    float xRotation = 0;
    public float mouseX;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseLookAt();

    }

    private void MouseLookAt()
    {
        //Inputs from mouse axis multiplies by sensivity and frame independent
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;


        xRotation -= mouseY;
        //Clamping cameraY
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Rotating player
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
