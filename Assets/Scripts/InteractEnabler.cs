using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractEnabler : MonoBehaviour
{
    bool fadeOut = false;
    // bool isInteractActive = false;
    // bool isButtonActive = false;

    float checkDistance1;
    float checkDistance2;
    float checkDistance3;

    float checkDoor;

    [SerializeField] GameObject npc1;
    [SerializeField] GameObject npc2;
    [SerializeField] GameObject npc3;
    [SerializeField] GameObject door;
    [SerializeField] GameObject imageToEnable;
    [SerializeField] Image image;

    /*
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject walls;
    [SerializeField] GameObject deco;
    [SerializeField] GameObject lights;
    [SerializeField] GameObject player;

    [SerializeField] GameObject video;
    [SerializeField] GameObject video1;
    [SerializeField] GameObject video2;
    [SerializeField] GameObject video3;
    [SerializeField] GameObject video4;
    */
    [SerializeField] GameObject interact;
    [SerializeField] GameObject OpenDoor;
    
    void Update()
    {
        checkDistance();
    }

    void checkDistance()
    {
        checkDistance1 = Vector3.Distance(this.transform.position, npc1.transform.position);
        checkDistance2 = Vector3.Distance(this.transform.position, npc2.transform.position);
        checkDistance3 = Vector3.Distance(this.transform.position, npc3.transform.position);

        if (checkDistance1 <= 2f || checkDistance2 <= 2f || checkDistance3 <= 2f)
        {
            interact.SetActive(true);
            // isInteractActive = true;
        }
        else
        {
            interact.SetActive(false);
            // isInteractActive = false;
        }

        checkDoor = Vector3.Distance(this.transform.position, door.transform.position);
        if(checkDoor <= 2f)
        {
            OpenDoor.SetActive(true);
            // isButtonActive = true;
        }
        else
        {
            OpenDoor.SetActive(false);
            // isButtonActive = false;
        }
        /*
        if (isInteractActive && isButtonActive)
        {
            interact.transform.position = new Vector3(900f, 280f, 0f); // interact button on top
            OpenDoor.transform.position = new Vector3(900f, 100f, 0f); // question button on bottom
        }
        else
        {
            interact.transform.position = new Vector3(900f, 180f, 0f); // both should be on the same position
            OpenDoor.transform.position = new Vector3(900f, 180f, 0f);
        }
        */
    }

    public void openTheDoor()
    {
        /*
        Camera.main.transform.rotation = Quaternion.Euler(270, 0, 0);
        player.gameObject.GetComponent<PlayerMovementController>().enabled = false;
        lights.SetActive(false);
        HUD.SetActive(false);
        walls.SetActive(false);
        deco.SetActive(false);
        video.SetActive(true);
        StartCoroutine(finishCut());
        */
        imageToEnable.SetActive(true);
        StartCoroutine(FadeTextToFullAlpha());
    }

    /*
    IEnumerator finishCut()
    {
        yield return new WaitForSeconds(39);
        video.SetActive(false);
        video1.SetActive(true);
        StartCoroutine(finishCut1());
    }

    IEnumerator finishCut1()
    {
        yield return new WaitForSeconds(35);
        video1.SetActive(false);
        video2.SetActive(true);
        StartCoroutine(finishCut2());
    }
    IEnumerator finishCut2()
    {
        yield return new WaitForSeconds(31);
        video2.SetActive(false);
        video3.SetActive(true);
        StartCoroutine(finishCut3());
    }
    IEnumerator finishCut3()
    {
        yield return new WaitForSeconds(95);
        video3.SetActive(false);
        video4.SetActive(true);
        StartCoroutine(finishCut4());
    }
    IEnumerator finishCut4()
    {
        yield return new WaitForSeconds(98);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    */

    public IEnumerator FadeTextToFullAlpha()
    {
        /*image.color = new Color(0, 0, 0, 0);
        for (float i = 0; i <= 250; i += 25)
        {
            image.color = new Color(0, 0, 0, i);
        }
        */
        float targetAlpha = 1.0f;
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            // Debug.Log(image.material.color.a);
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, 10f * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
