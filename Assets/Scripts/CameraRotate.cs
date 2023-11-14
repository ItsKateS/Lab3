using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform player;
    public Transform camera_;

    float sensX = 3f;
    float sensY = 3f;

    Quaternion center;

    public static bool cursorLock = true;

    void Start()
    {
        center = camera_.localRotation;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * sensY;
        Quaternion rotY = camera_.localRotation * Quaternion.AngleAxis(mouseY, -Vector3.right);

        if(Quaternion.Angle(center, rotY) < 90f)
            camera_.localRotation = rotY;

        float mouseX = Input.GetAxis("Mouse X") * sensX;
        Quaternion rotX = player.localRotation * Quaternion.AngleAxis(mouseX, Vector3.up);

        player.localRotation = rotX;


        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if(Input.GetKeyDown(KeyCode.Escape))
                cursorLock = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKeyDown(KeyCode.Escape))
                cursorLock = true;
        }
    }
}
