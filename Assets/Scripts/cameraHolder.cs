using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cameraHolder : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform arms;
    [SerializeField] private Transform body;

    float xRot;



    void Start()
    {
        // LockCursor();
    }

    void Update()
    {
        // HandleMouseLook();
    }

    public void HandleMouseLook(float mouseX, float mouseY)
    {
        // mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
        // mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;

        /*
        float mouseX = 0;
        float mouseY = 0;
        
        try
        {
            if (Touchscreen.current.touches.Count > 0 && Touchscreen.current.touches[0].isInProgress)
            {
                if (EventSystem.current.IsPointerOverGameObject(Touchscreen.current.touches[0].touchId.ReadValue()))
                {
                    return;
                }
                mouseX = Touchscreen.current.touches[0].delta.ReadValue().x;
                mouseY = Touchscreen.current.touches[0].delta.ReadValue().y;
            }

        }
        catch
        {
            mouseX = 0;
            mouseY = 0;
        }
        */

        mouseX *= mouseSensitivity;
        mouseY *= mouseSensitivity;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        arms.localRotation = Quaternion.Euler(new Vector3(xRot, 0, 0));
        body.Rotate(new Vector3(0, mouseX, 0));
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
