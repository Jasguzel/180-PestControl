using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float spiderHealth = 1;

    //this will be the enemies patrolling function
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //this will be enemy attacks
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject webs;

    //different states the enemy is in
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //this will call all functions within enemy bahavior function
        EnemyBehavior();
    }
    //functions other than start and update begin here
    private void Awake()
    {
        //this will find the first instance of the object with the playercontroller script (inside angle bracket = <  >)
        player = GameObject.FindFirstObjectByType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void EnemyBehavior()
    {
        //this part will check sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //these will determine what the spider does regarding player position
        if(!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if(playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }

        Patrolling();
        ChasePlayer();
        AttackPlayer();
    }
    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (!walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = true;
    }
    private void SearchWalkPoint()
    {
        //this calculates the random point within range of the player
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            agent.SetDestination(transform.position);
            transform.LookAt(player);
            //The ranged attack behavior code goes here
            Rigidbody rb = Instantiate(webs, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 12f, ForceMode.Impulse);
            rb.AddForce(transform.up * 3f, ForceMode.Impulse);
            alreadyAttacked = true;
            //you must set StartCoroutine
            StartCoroutine(ResetAttack());
        }

    }
    //this is a coroutine, you must do exactly as shown below for it to start the timer
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        alreadyAttacked = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<Bullet>())
        {
            spiderHealth --;
            if (spiderHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
