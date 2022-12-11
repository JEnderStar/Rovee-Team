using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractEnabler_orig : MonoBehaviour
{
    float checkDistance1;

    float checkDoor;

    // remove comment, add DialogueManager on NPC to hide the dialogue hud.
    // [SerializeField] GameObject npc;
    // [SerializeField] GameObject door;

    [SerializeField] GameObject HUD;
    [SerializeField] GameObject player;

    [SerializeField] GameObject interact;
    [SerializeField] GameObject OpenDoor;
    
    void Update()
    {
        checkDistance();
    }

    void checkDistance()
    {
        /*
        checkDistance1 = Vector3.Distance(this.transform.position, npc.transform.position);

        if (checkDistance1 <= 2f)
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
        */
    }

    public void openTheDoor()
    {
        // codes
    }
}
