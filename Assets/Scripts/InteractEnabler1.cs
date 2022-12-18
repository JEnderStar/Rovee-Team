using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractEnabler1 : MonoBehaviour
{
    // bool fadeOut = false;
    // bool isInteractActive = false;
    // bool isFakeButtonActive = false;
    // bool isButtonActive = false;

    float checkDistance1;
    float checkDistance2;
    float checkDistance3;

    float checkDoor;
    float checkFakeDoor;
    float checkFakeDoor1;
    float checkFakeDoor2;
    float checkFakeDoor3;
    float checkFakeDoor4;
    float checkFakeDoor5;
    float checkFakeDoor6;
    float checkFakeDoor7;

    [SerializeField] GameObject npc1;
    [SerializeField] GameObject npc2;
    [SerializeField] GameObject npc3;
    [SerializeField] GameObject door;
    [SerializeField] GameObject fakeDoorButton;

    [SerializeField] GameObject fakeDoor;
    [SerializeField] GameObject fakeDoor1;
    [SerializeField] GameObject fakeDoor2;
    [SerializeField] GameObject fakeDoor3;
    [SerializeField] GameObject fakeDoor4;
    [SerializeField] GameObject fakeDoor5;
    [SerializeField] GameObject fakeDoor6;
    [SerializeField] GameObject fakeDoor7;

    [SerializeField] GameObject textFakeDoor;

    // [SerializeField] GameObject player;
    [SerializeField] GameObject ground;
    [SerializeField] GameObject ground1;
    [SerializeField] AudioSource audioSource;

    [SerializeField] GameObject hud;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject video;

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

        checkFakeDoor = Vector3.Distance(this.transform.position, fakeDoor.transform.position);
        checkFakeDoor1 = Vector3.Distance(this.transform.position, fakeDoor1.transform.position);
        checkFakeDoor2 = Vector3.Distance(this.transform.position, fakeDoor2.transform.position);
        checkFakeDoor3 = Vector3.Distance(this.transform.position, fakeDoor3.transform.position);
        checkFakeDoor4 = Vector3.Distance(this.transform.position, fakeDoor4.transform.position);
        checkFakeDoor5 = Vector3.Distance(this.transform.position, fakeDoor5.transform.position);
        checkFakeDoor6 = Vector3.Distance(this.transform.position, fakeDoor6.transform.position);
        checkFakeDoor7 = Vector3.Distance(this.transform.position, fakeDoor7.transform.position);
        if(checkFakeDoor <= 2f || checkFakeDoor1 <= 2f || checkFakeDoor2 <= 2f || checkFakeDoor3 <= 2f || checkFakeDoor4 <= 2f || checkFakeDoor5 <= 2f || checkFakeDoor6 <= 2f || checkFakeDoor7 <= 2f)
        {
            fakeDoorButton.SetActive(true);
            // isFakeButtonActive = true;
        }
        else
        {
            fakeDoorButton.SetActive(false);
            // isFakeButtonActive = false;
        }
        /*
        if (isInteractActive && (isButtonActive || isFakeButtonActive))
        {
            interact.transform.position = new Vector3(900f, 280f, 0f);
            OpenDoor.transform.position = new Vector3(900f, 100f, 0f);
            fakeDoorButton.transform.position = new Vector3(900f, 100f, 0f);
        }
        else
        {
            interact.transform.position = new Vector3(900f, 180f, 0f);
            OpenDoor.transform.position = new Vector3(900f, 180f, 0f);
            fakeDoorButton.transform.position = new Vector3(900f, 180f, 0f);
        }
        */
    }

    public void openTheDoor()
    {
        Camera.main.transform.rotation = Quaternion.Euler(90, 0, 0);
        ground.SetActive(false);
        ground1.SetActive(false);
        hud.SetActive(false);
        panel.SetActive(false);
        audioSource.Stop();
        StartCoroutine(finishCut());
    }

    public void fakeOpenTheDoor()
    {
        StartCoroutine(fakeDoorTrigger());
    }

    IEnumerator fakeDoorTrigger()
    {
        textFakeDoor.SetActive(true);
        yield return new WaitForSeconds(2);
        textFakeDoor.SetActive(false);
    }

    IEnumerator finishCut()
    {
        video.SetActive(true);
        yield return new WaitForSeconds(178);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
