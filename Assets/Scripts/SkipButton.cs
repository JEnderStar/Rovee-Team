using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    public void SkipScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SkipFinalScene()
    {
        SceneManager.LoadScene(0);
    }
}
