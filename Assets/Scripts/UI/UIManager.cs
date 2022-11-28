using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject hudCanvas = null;
    [SerializeField] GameObject endCanvas = null;

    void Start()
    {
        SetActiveHud(true);
    }

    public void SetActiveHud(bool state)
    {
        hudCanvas.SetActive(state);
        endCanvas.SetActive(!state);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
