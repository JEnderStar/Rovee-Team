using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionVideoEnabler : MonoBehaviour
{
    [SerializeField] GameObject firstVideo;
    [SerializeField] GameObject secondVideo;
    [SerializeField] GameObject thirdVideo;
    [SerializeField] GameObject fourthVideo;
    void Start()
    {
        StartCoroutine(videoDisabler());
    }

    IEnumerator videoDisabler()
    {
        firstVideo.SetActive(true);
        yield return new WaitForSeconds(33);
        firstVideo.SetActive(false);
        StartCoroutine(videoDisabler2());
    }
    
    IEnumerator videoDisabler2()
    {
        secondVideo.SetActive(true);
        yield return new WaitForSeconds(28);
        secondVideo.SetActive(false);
        StartCoroutine(videoDisabler3());
    }
    
    IEnumerator videoDisabler3()
    {
        thirdVideo.SetActive(true);
        yield return new WaitForSeconds(68);
        thirdVideo.SetActive(false);
        StartCoroutine(videoDisabler4());
    }
    
    IEnumerator videoDisabler4()
    {
        fourthVideo.SetActive(true);
        yield return new WaitForSeconds(47);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
