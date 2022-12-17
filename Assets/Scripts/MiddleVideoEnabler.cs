using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiddleVideoEnabler : MonoBehaviour
{
    [SerializeField] GameObject firstVideo;
    [SerializeField] GameObject secondVideo;
    [SerializeField] GameObject thirdVideo;
    [SerializeField] GameObject fourthVideo;
    [SerializeField] GameObject fifthVideo;
    [SerializeField] GameObject sixthVideo;
    [SerializeField] GameObject seventhVideo;
    [SerializeField] GameObject eighthVideo;
    void Start()
    {
        StartCoroutine(videoDisabler());
    }

    IEnumerator videoDisabler()
    {
        firstVideo.SetActive(true);
        yield return new WaitForSeconds(109);
        firstVideo.SetActive(false);
        StartCoroutine(videoDisabler2());
    }
    
    IEnumerator videoDisabler2()
    {
        secondVideo.SetActive(true);
        yield return new WaitForSeconds(68);
        secondVideo.SetActive(false);
        StartCoroutine(videoDisabler3());
    }
    
    IEnumerator videoDisabler3()
    {
        thirdVideo.SetActive(true);
        yield return new WaitForSeconds(90);
        thirdVideo.SetActive(false);
        StartCoroutine(videoDisabler4());
    }
    IEnumerator videoDisabler4()
    {
        fourthVideo.SetActive(true);
        yield return new WaitForSeconds(58);
        fourthVideo.SetActive(false);
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
