using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoDisabler2 : MonoBehaviour
{
    public GameObject video;

    void Start()
    {
        video.SetActive(false);
    }
}
