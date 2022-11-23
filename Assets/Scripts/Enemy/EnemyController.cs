using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private float timeOfLastAttack = 0;
    private bool hasStopped = false;

    private NavMeshAgent agent = null;
    private Animator anim = null;
    private EnemyStats stats = null;
    private Transform target;

    /*NewUpdateAI

    public LayerMask whatIsGround, whatIsPlayer;

    //States

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Patrolling

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    */

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        MoveToTarget();
        /*
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) MoveToTarget();
        if (playerInSightRange && playerInAttackRange) ;
        */
    }
    
    /*
    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    */

    private void RotateToTarget()
    {
        //transform.LookAt(target);

        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f);
            //Attack

            if (!hasStopped)
            {
                hasStopped = true;
                timeOfLastAttack = Time.time;
            }
            
            if(Time.time >= timeOfLastAttack + stats.attackSpeed)
            {
                timeOfLastAttack = Time.time;
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                AttackTarget(targetStats);
            }
        }
        else
        {
            if (hasStopped)
            {
                hasStopped = false;
            }
        }
    }

    private void AttackTarget(CharacterStats statsToDamage)
    {
        anim.SetTrigger("attack");
        stats.DealDamage(statsToDamage);
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<EnemyStats>();
        target = PlayerMovementController.instance;
    }
}
