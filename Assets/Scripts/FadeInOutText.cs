using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeInOutText : MonoBehaviour
{
    bool active = true;
    int a = 0;

    void Start()
    {
        StartCoroutine(trigger(GetComponent<TextMeshProUGUI>()));
    }
 
 
 
    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            a = 0;
            yield return null;
        }
        StartCoroutine(trigger(i));
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            a = 1;
            yield return null;
        }
        StartCoroutine(trigger(i));
    }

    public IEnumerator trigger(TextMeshProUGUI i)
    {
        if (a == 0)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(FadeTextToZeroAlpha(1f, i));
        } else if (a == 1)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(FadeTextToFullAlpha(1f, i));
        }
    }
}
