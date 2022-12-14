using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractEnabler : MonoBehaviour
{
    bool fadeOut = false;

    float checkDistance1;
    float checkDistance2;
    float checkDistance3;

    float checkDoor;

    [SerializeField] GameObject npc1;
    [SerializeField] GameObject npc2;
    [SerializeField] GameObject npc3;
    [SerializeField] GameObject door;

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
        }
        else
        {
            interact.SetActive(false);
        }

        checkDoor = Vector3.Distance(this.transform.position, door.transform.position);
        if(checkDoor <= 1f)
        {
            OpenDoor.SetActive(true);
        }
        else
        {
            OpenDoor.SetActive(false);
        }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
}
