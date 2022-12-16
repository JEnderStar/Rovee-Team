using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractEnabler1 : MonoBehaviour
{
    bool fadeOut = false;

    float checkDistance1;
    float checkDistance2;
    float checkDistance3;

    float checkDoor;

    [SerializeField] GameObject npc1;
    [SerializeField] GameObject npc2;
    /* [SerializeField] GameObject npc3;
    [SerializeField] GameObject door;
    [SerializeField] GameObject HUD;
    [SerializeField] Image img;
    [SerializeField] GameObject player;
    [SerializeField] GameObject props;
    [SerializeField] GameObject arms;
    [SerializeField] GameObject video;
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
        // checkDistance3 = Vector3.Distance(this.transform.position, npc3.transform.position);

        if (checkDistance1 <= 2f || checkDistance2 <= 2f /* || checkDistance3 <= 2f */ )
        {
            interact.SetActive(true);
        }
        else
        {
            interact.SetActive(false);
        }

        /*
        checkDoor = Vector3.Distance(this.transform.position, door.transform.position);
        if(checkDoor <= 1f)
        {
            OpenDoor.SetActive(true);
        }
        else
        {
            OpenDoor.SetActive(false);
        }
        */
    }

    public void openTheDoor()
    {
        Camera.main.transform.rotation = Quaternion.Euler(270, 0, 0);
        /*
        player.gameObject.GetComponent<PlayerMovementController>().enabled = false;
        HUD.SetActive(false);
        props.SetActive(false);
        video.SetActive(true);
        StartCoroutine(finishCut());
        */
    }

    /*
    IEnumerator finishCut()
    {
        yield return new WaitForSeconds(108);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    */
}