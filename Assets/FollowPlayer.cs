using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public GameObject myTarget;
    public NavMeshAgent myAgent;
    private Animator anim;

    public int range;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(this.transform.position, myTarget.transform.position);

        if (dist <= myAgent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
        }
        else if(dist < range)
        {
            myAgent.destination = myTarget.transform.position;
            anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        }
    }
}
