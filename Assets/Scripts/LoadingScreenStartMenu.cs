using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScreenStartMenu : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider LoadingBarFill;

    public TextMeshProUGUI text;

    public void LoadScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        LoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            text.text = "Loading " + progressValue * 100f + "%";
            LoadingBarFill.value = progressValue;
            yield return null;
        }
    }
}
