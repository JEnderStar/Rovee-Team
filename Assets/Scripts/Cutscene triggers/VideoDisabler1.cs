using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoDisabler1 : MonoBehaviour
{
    public GameObject video;
    public GameObject video1;
    public GameObject video2;
    public GameObject video3;
    public GameObject video4;
    void Start()
    {
        video.SetActive(false);
        video1.SetActive(false);
        video2.SetActive(false);
        video3.SetActive(false);
        video4.SetActive(false);
    }
}
