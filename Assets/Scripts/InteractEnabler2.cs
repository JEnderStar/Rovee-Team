using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractEnabler2 : MonoBehaviour
{
    bool fadeOut = false;
    bool isInteractActive = false;
    bool isButtonActive = false;

    float checkDistance1;
    float checkDistance2;
    float checkDistance3;

    // float checkDoor;

    [SerializeField] GameObject npc1;
    [SerializeField] GameObject npc2;
    [SerializeField] GameObject npc3;

    /*
    [SerializeField] GameObject door;
    [SerializeField] GameObject imageToEnable;
    [SerializeField] Image image;
    */

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
    // [SerializeField] GameObject OpenDoor;
    
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
            isInteractActive = true;
        }
        else
        {
            interact.SetActive(false);
            isInteractActive = false;
        }
        /*
        checkDoor = Vector3.Distance(this.transform.position, door.transform.position);
        if(checkDoor <= 2f)
        {
            OpenDoor.SetActive(true);
            isButtonActive = true;
        }
        else
        {
            OpenDoor.SetActive(false);
            isButtonActive = false;
        }

        if (isInteractActive && isButtonActive)
        {
            interact.transform.position = new Vector3(900f, 280f, 0f);
            OpenDoor.transform.position = new Vector3(900f, 100f, 0f);
        }
        else
        {
            interact.transform.position = new Vector3(900f, 180f, 0f);
            OpenDoor.transform.position = new Vector3(900f, 180f, 0f);
        }
        */
    }

    public void openTheDoor()
    {
        /*
        imageToEnable.SetActive(true);
        StartCoroutine(FadeTextToFullAlpha());
        */
    }

    /*
    public IEnumerator FadeTextToFullAlpha()
    {
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
    */
}
