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

    [SerializeField] GameObject textToEnable;
    [SerializeField] GameObject sliderToEnable;
    [SerializeField] GameObject textToDisable;

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
                StartCoroutine(LoadSceneAsync());
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LoadSceneAsync());
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
