using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TouchToContinue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider LoadingBarFill;

    [SerializeField] GameObject image;
    [SerializeField] GameObject image1;
    [SerializeField] GameObject image2;
    [SerializeField] GameObject image3;
    [SerializeField] GameObject image4;

    [SerializeField] GameObject textToEnable;
    [SerializeField] GameObject sliderToEnable;
    [SerializeField] GameObject textToDisable;

    int touchesa = 1;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // nothing
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if(touchesa == 1)
                {
                    image.SetActive(false);
                    image1.SetActive(true);
                    touchesa++;
                }else if(touchesa == 2)
                {
                    image1.SetActive(false);
                    image2.SetActive(true);
                    touchesa++;
                }else if(touchesa == 3)
                {
                    image2.SetActive(false);
                    image3.SetActive(true);
                    touchesa++;
                }else if(touchesa == 4)
                {
                    image3.SetActive(false);
                    image4.SetActive(true);
                    touchesa++;
                }else if(touchesa == 5)
                {
                    StartCoroutine(LoadSceneAsync());
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (touchesa == 1)
            {
                image.SetActive(false);
                image1.SetActive(true);
                touchesa++;
            }
            else if (touchesa == 2)
            {
                image1.SetActive(false);
                image2.SetActive(true);
                touchesa++;
            }
            else if (touchesa == 3)
            {
                image2.SetActive(false);
                image3.SetActive(true);
                touchesa++;
            }
            else if (touchesa == 4)
            {
                image3.SetActive(false);
                image4.SetActive(true);
                touchesa++;
            }
            else if (touchesa == 5)
            {
                StartCoroutine(LoadSceneAsync());
            }
        }
    }
    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        textToDisable.SetActive(false);
        sliderToEnable.SetActive(true);
        textToEnable.SetActive(true);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            text.text = "Loading " + progressValue * 100f + "%";
            LoadingBarFill.value = progressValue;
            yield return null;
        }
    }
}
