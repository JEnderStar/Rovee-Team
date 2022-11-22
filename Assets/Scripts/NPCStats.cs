using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStats : MonoBehaviour
{
    public GameObject player;
    public GameObject TextName;

    float distance;

    void Update()
    {
        if(TextName != null)
        {
            TextName.transform.LookAt(Camera.main.transform.position);
            TextName.transform.Rotate(0, 180, 0);
            TextName.GetComponent<TextMesh>().color = Color.cyan;
        }

        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance >= 5f)
        {
            TextName.SetActive(false);
        }

        else
        {
            TextName.SetActive(true);
        }   
    }
}
