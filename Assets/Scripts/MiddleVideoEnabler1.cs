using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiddleVideoEnabler1 : MonoBehaviour
{
    [SerializeField] GameObject fifthVideo;
    [SerializeField] GameObject sixthVideo;
    [SerializeField] GameObject seventhVideo;
    [SerializeField] GameObject eighthVideo;
    void Start()
    {
        StartCoroutine(videoDisabler5());
    }

    IEnumerator videoDisabler5()
    {
        fifthVideo.SetActive(true);
        yield return new WaitForSeconds(150);
        fifthVideo.SetActive(false);
        StartCoroutine(videoDisabler6());
    }
    IEnumerator videoDisabler6()
    {
        sixthVideo.SetActive(true);
        yield return new WaitForSeconds(46);
        sixthVideo.SetActive(false);
        StartCoroutine(videoDisabler7());
    }
    IEnumerator videoDisabler7()
    {
        seventhVideo.SetActive(true);
        yield return new WaitForSeconds(48);
        seventhVideo.SetActive(false);
        StartCoroutine(videoDisabler8());
    }
    
    IEnumerator videoDisabler8()
    {
        eighthVideo.SetActive(true);
        yield return new WaitForSeconds(24);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
