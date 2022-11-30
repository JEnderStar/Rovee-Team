using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoDisabler : MonoBehaviour
{
    public GameObject video;
    public GameObject video1;
    void Start()
    {
        video.SetActive(false);
        video1.SetActive(false);
    }
}
