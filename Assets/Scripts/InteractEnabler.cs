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
    [SerializeField] CanvasGroup HUD;
    // [SerializeField] Image img;

    [SerializeField] GameObject interact;
    [SerializeField] GameObject OpenDoor;
    
    void Update()
    {
        fadeUI();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        // loop over 1 second backwards
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            // img.color = new Color(0, 0, 0, i);
            fadeOut = true;
            if(i >= 0.99)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            yield return null;
        }
    }
    
    void fadeUI()
    {
        if (fadeOut)
        {
            if(HUD.alpha >= 0)
            {
                HUD.alpha -= Time.deltaTime;
                if(HUD.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
