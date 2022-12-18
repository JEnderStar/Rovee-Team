using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CIBoxTrigger : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] GameObject imageToEnable;
    [SerializeField] GameObject player;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject video;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject skip;

    private void OnTriggerEnter(Collider other)
    {
        imageToEnable.SetActive(true);
        StartCoroutine(FadeTextToFullAlpha());
    }

    public IEnumerator FadeTextToFullAlpha()
    {
        float targetAlpha = 1.0f;
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, 10f * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
        hud.SetActive(false);
        video.SetActive(true);
        player.transform.position = new Vector3(-30f, -30f, -30f);
        Camera.main.transform.rotation = Quaternion.Euler(90, 0, 0);
        audioSource.Stop();
        skip.SetActive(true);
        StartCoroutine(FadeOut());
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator FadeOut()
    {
        float targetAlpha = 0f;
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            Debug.Log(image.material.color.a);
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, 10f * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
        imageToEnable.SetActive(false);
        StartCoroutine(finishCut());
    }

    IEnumerator finishCut()
    {
        yield return new WaitForSeconds(26);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
