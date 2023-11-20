using System;
using System.Collections;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Monster : MonoBehaviour
{

    //3 states: Patrolling, Moving, Attacking
    //Moving overrides patrolling and attacking.

    private Animator myAnimator;
    private NavMeshAgent ai;

    private const int IdleAnims = 2;

    [SerializeField] private float maxHealth;
    private float health;
    private Coroutine stateRoutine;
    [SerializeField] private Rigidbody fireBallPrefab;
    [SerializeField] private Transform firePoint;
    private Vector3 lookAtPoint;

    private EAiState aiState = EAiState.Idle;
    [SerializeField] private float boredTimer = 1;

    private WaitForSeconds idleTimer;
    
    [Flags]
    private enum EAiState
    {
        Idle = 1, // Idle happens, once we have reached our destination / finished an attack.
        Wander = 2, // Wander is going to happen, if we haven't interacted with our charcater for x seconds
        CommandMove = 4, // Happens when told to move, cannot exit unless attack is given, exists into idle.
        CommandAttack = 8 // Happens when attack is called, can only be cancelled by move, when finished goes into idle.
    }



    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        ai = GetComponent<NavMeshAgent>();
        health = maxHealth;
        idleTimer = new WaitForSeconds(boredTimer);
        EnterIdle();
    }

    private IEnumerator Idle()
    {
        yield return idleTimer;
        //If this completes, then we should enter wander if our state is not a command
        if (aiState == EAiState.Idle)
        {
            bool findLoc;
            RaycastHit hit;
            do
            {
                Vector3 randomSphere = Random.insideUnitCircle * 10;
                randomSphere.z = randomSphere.y;
                randomSphere.y = 1000;
                findLoc = Physics.Raycast(randomSphere, -Vector3.up, out hit, 2000, StaticUtilities.GroundLayerID);
            }
            while (!findLoc);
            
            MoveToTarget(hit.point);
            aiState = EAiState.Wander;
        }
    }

    private void EnterIdle()
    {
        aiState = EAiState.Idle;
        StopRotating();
        stateRoutine = StartCoroutine(Idle());
    }
    


    private void Update()
    {

        Vector3 velocity = transform.InverseTransformDirection(ai.velocity);
        myAnimator.SetFloat(StaticUtilities.XSpeedAnimID, velocity.x);
        myAnimator.SetFloat(StaticUtilities.ZSpeedAnimID, velocity.z);
        if ((aiState & (EAiState.Idle | EAiState.CommandAttack)) == 0 && ai.remainingDistance <= ai.stoppingDistance)
        {
            EnterIdle();
        }

    }


    public void MoveToTarget(Vector3 hitObjectPoint)
    {
        aiState = EAiState.CommandMove;
        ai.SetDestination(hitObjectPoint);
        ai.isStopped = false;
    }

    public void TryAttack(RaycastHit hitObject)
    {
        //Rotate to face object.
        ai.isStopped = true;
        aiState = EAiState.CommandAttack;
        StopRotating();
        lookAtPoint = (hitObject.point - transform.position).normalized;
        stateRoutine = StartCoroutine(RotateToTarget());
    }

    private IEnumerator RotateToTarget()
    {
        myAnimator.SetBool(StaticUtilities.IsTurningAnimID, true);
        float angle;
        do
        { 
            angle = Vector3.Dot(transform.right, lookAtPoint);
            myAnimator.SetFloat(StaticUtilities.TurnAnimID, angle);
            yield return null;
        } while (Mathf.Abs(angle) >= 0.01f);
        myAnimator.SetBool(StaticUtilities.IsTurningAnimID, false);
        stateRoutine = null;
        Attack();
        
        //Attack.
    }

    private void StopRotating()
    {
        if(stateRoutine != null) StopCoroutine(stateRoutine);
        myAnimator.SetBool(StaticUtilities.IsTurningAnimID, false);
    }

    private void Attack()
    {
        myAnimator.SetTrigger(StaticUtilities.AttackAnimID);
    }
    
    public void ChangeIdleState()
    {
        int newState = Random.Range(0, 2);
        myAnimator.SetFloat(StaticUtilities.IdleAnimID, newState);
    }

    public void SpawnFireBall()
    {
        Rigidbody projectile = Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
        projectile.AddForce(lookAtPoint * 1, ForceMode.Impulse);
        EnterIdle();
    }
}
