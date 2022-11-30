using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject canvas;
    public GameObject hands;
    public GameObject video;
    public GameObject video2;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        player.gameObject.GetComponent<PlayerStats>().enabled = false;
        player.gameObject.GetComponent<PlayerMovementController>().enabled = false;
        canvas.SetActive(false);
        hands.SetActive(false);
        video.SetActive(true);
        Camera.main.transform.rotation = Quaternion.Euler(270, 0, 0);
        StartCoroutine(finishCut());
    }

    IEnumerator finishCut()
    {
        yield return new WaitForSeconds(32);
        video.SetActive(false);
        video2.SetActive(true);
        StartCoroutine(finishCut2());
    }

    IEnumerator finishCut2()
    {
        yield return new WaitForSeconds(75);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
