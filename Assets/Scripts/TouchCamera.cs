using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class TouchCamera : cameraHolder
{
    float mouseX;
    float mouseY;

    public FloatingJoystick joysticklook;

    public void Update()
    {
        /*try
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
            else
            {
                mouseX = 0;
                mouseY = 0;
            }

        }
        catch
        {
            mouseX = 0;
            mouseY = 0;
        } */
        mouseX = joysticklook.Horizontal;
        mouseY = joysticklook.Vertical;

        HandleMouseLook(mouseX, mouseY);
    }
}
