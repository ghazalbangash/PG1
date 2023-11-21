using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;


public class EnemyControler : MonoBehaviour
{


    public NavMeshAgent agent;
    private Animator myAnimator;

    public Transform player;
    public LayerMask groundlayer, playerlayer;

    // Attack
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public GameObject projectilePos;

    public Vector3 walkPoint;
    bool walkpointSet;
    public float walkPointRange;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    PlayerAction inputAction;



    private EAiState aiState = EAiState.Idle;
    private void Awake() {
        // agent = GetComponent<NavMeshAgent>();

        //Inputs.InitEnemy(this);
    }

    private void Start() {
        myAnimator = GetComponent<Animator>();
    }



    private enum EAiState
    {
        Idle = 1, // Idle happens, once we have reached our destination / finished an attack.
        Wander = 2, // Wander is going to happen, if we haven't interacted with our charcater for x seconds
        CommandMove = 4, // Happens when told to move, cannot exit unless attack is given, exists into idle.
        CommandAttack = 8 // Happens when attack is called, can only be cancelled by move, when finished goes into idle.
    }

    private void Update() {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerlayer);


        // Attack State
        if(playerInSightRange && playerInAttackRange) Attack();

        //if(!playerInSightRange && playerInAttackRange) Patroll();

        if(playerInSightRange && !playerInAttackRange)Chase();


        Vector3 velocity  = agent.velocity;
        myAnimator.SetFloat(staticutility.XSpeedAnimID,velocity.x);
        myAnimator.SetFloat(staticutility.ZSpeedAnimID,velocity.z);
    }


    private void Patroll(){
        if(!walkpointSet)SearchWalkPoint();
        if(walkpointSet){
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceWalkPoint = transform.position - walkPoint;

        if(distanceWalkPoint.magnitude < 1f){
            walkpointSet = false;
        }
    
    }
    private void Chase(){
        agent.SetDestination(player.position);
    }

    private void SearchWalkPoint(){
        float randomX = Random.Range(-walkPointRange,walkPointRange);
        float randomZ = Random.Range(-walkPointRange,walkPointRange);

        walkPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if(Physics.Raycast(walkPoint,-transform.up,1f,groundlayer)){
            walkpointSet = true;
        }
    }



    private void Attack()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            Rigidbody bulletRb = Instantiate(projectile, projectilePos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void MoveToTarget(Vector3 hitObjectPoint)
    {
        aiState = EAiState.CommandMove;
        agent.SetDestination(hitObjectPoint);
        agent.isStopped = false;
    }

}
