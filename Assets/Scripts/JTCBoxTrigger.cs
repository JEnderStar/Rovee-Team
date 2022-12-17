using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JTCBoxTrigger : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] GameObject imageToEnable;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
