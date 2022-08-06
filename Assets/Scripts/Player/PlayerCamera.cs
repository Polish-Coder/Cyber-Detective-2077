using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform Orientation;
    public float Sensitivity = 10;

    Transform cam;
    float xRot;
    float yRot;

    void Start()
    {
        cam = transform.Find("Camera");

        HideMouse();
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Mouse X") * Time.deltaTime * Sensitivity;
        float inputY = Input.GetAxis("Mouse Y") * Time.deltaTime * Sensitivity;

        yRot += inputX;
        xRot -= inputY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        //transform.Rotate(transform.up * inputX);
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        Orientation.rotation = Quaternion.Euler(0, yRot, 0);

        //xRot -= inputY;
        //xRot = Mathf.Clamp(xRot, -90, 90);
        //cam.localRotation = Quaternion.Euler(xRot, 0, 0);
    }

    public static void HideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void ShowMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}