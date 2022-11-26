using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;

    float distance;
    float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;
    public GameObject HUDUI;
    public GameObject interact;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

    
    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void Update()
    {
        // Interact();
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        UpdateDialogue();
    }

    /*
    void Interact()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 0.5f)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                curResponseTracker++;
                if(curResponseTracker >= npc.playerDialogue.Length - 1)
                {
                    curResponseTracker = npc.playerDialogue.Length - 1;
                }
            }

            else if(Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                curResponseTracker--;
                if(curResponseTracker < 0)
                {
                    curResponseTracker = 0;
                }
            }
            //trigger dialogue
            if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            else if(Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
            }

            if(curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[1];
                }
            }

            else if(curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[2];
                }
            }

            else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[2];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[3];
                }
            }
        }
    }
    */

    void UpdateDialogue()
    {
        if (distance <= 2f)
        {
            if (curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
            }

            else if (curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
            }

            else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[2];
            }
        }
    }

    void StartConversation()
    {
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        HUDUI.SetActive(false);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];
    }

    void EndDialogue()
    {
        isTalking = false;
        curResponseTracker = 0;
        dialogueUI.SetActive(false);
        HUDUI.SetActive(true);
    }

    public void startInteract()
    {
        if (distance <= 2f)
        {
            if (isTalking == false)
            {
                StartConversation();
            }
        }
    }

    public void endInteract()
    {
        if (distance <= 2f)
        {
            if (isTalking == true)
            {
                EndDialogue();
            }
        }
    }

    public void scrollUp()
    {
        if (distance <= 2f)
        {
            curResponseTracker--;
            if (curResponseTracker < 0)
            {
                curResponseTracker = 0;
            }
        }
    }

    public void scrollDown()
    {
        if (distance <= 2f)
        {
            curResponseTracker++;
            if (curResponseTracker >= npc.playerDialogue.Length - 1)
            {
                curResponseTracker = npc.playerDialogue.Length - 1;
            }
        }
    }

    public void selectChoice()
    {
        if (distance <= 2f)
        {
            if (curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                npcDialogueBox.text = npc.dialogue[1];
            }

            else if (curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
                npcDialogueBox.text = npc.dialogue[2];
            }

            else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[2];
                npcDialogueBox.text = npc.dialogue[3];
            }
        }
    }
}
