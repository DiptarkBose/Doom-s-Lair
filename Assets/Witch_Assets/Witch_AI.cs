using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Witch_AI : MonoBehaviour
{
    //reference to agent
    public NavMeshAgent agent;

    public Transform player;
    
    public LayerMask whatIsGround, whatIsPlayer;

    //Attacking
    public float timeBetweenAttacks;    
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public bool m_IsDead;
    public bool m_IsAttacking;


    public Animator anim;

// Start is called before the first frame update
    void Start()
    {
        m_IsDead = false;
        m_IsAttacking = false;
    }
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // check if player is in sight & attack range 
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Idle();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

    }

    private void ClearAnim() 
    {
        anim.SetBool("isIdle", false);
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isDead", false);
    }

    private void Idle()
    {
        ClearAnim();
        anim.SetBool("isIdle", true);
    }


    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        ClearAnim();
        anim.SetBool("isWalking", true);
    }

    private void AttackPlayer()
    {
        //make sure enemy does not move
        agent.SetDestination(transform.position);
        transform.LookAt(player);

    
            /// attack code here
            ClearAnim();
            anim.SetBool("isAttacking", true);

            //alreadyAttacked = true;
            //Invoke(nameof(ResetAttack), timeBetweenAttacks);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    // kill and cleanup enemy
    protected void MakeDead()
    {
        ClearAnim();
        anim.SetBool("isDead", true);
        //m_AudioSource.PlayOneShot(m_DeathSound);
        m_IsDead = true;
    }


    
}