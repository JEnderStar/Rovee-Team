using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject idle;
    [SerializeField] GameObject video;

    public void Start()
    {
        video.SetActive(false);
    }
    public void PlayGame()
    {
        canvas.SetActive(false);
        panel.SetActive(false);
        idle.SetActive(false);
        video.SetActive(true);
        StartCoroutine(finishCut());
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator finishCut()
    {
        yield return new WaitForSeconds(86);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
