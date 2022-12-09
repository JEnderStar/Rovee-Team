using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0.1f, 0.0f, 0.0f, Space.World);
    }
}
