using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyAI : MonoBehaviour
{
    NavMeshAgent agent;

    Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;
    [SerializeField] AudioSource fire;

    EnemyStats stats = null;
    private Animator anim = null;

    private float timeOfLastAttack = 0;
    private bool hasStopped = false;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<EnemyStats>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }

        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
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

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
    }

    //public Transform projectilePosition;
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        anim.SetFloat("Speed", 0f);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            /*
            //Attack code here
            Rigidbody rb = Instantiate(projectile, projectilePosition.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 50f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            */
            //AttackPlayer(targetStats);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), stats.attackSpeed);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        CharacterStats targetStats = player.GetComponent<CharacterStats>();

        attackingPlayer(targetStats);

    }
    void attackingPlayer(CharacterStats statsToDamage)
    {
        int chance = Random.Range(0, 100);
        anim.SetTrigger("attack");
        fire.Play();
        if (chance >= 85)
        {
            stats.DealDamage(statsToDamage);
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
