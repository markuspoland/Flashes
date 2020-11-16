using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public float chaseRange = 10f;
    public Transform playerTransform;
    Animator anim;

    float distanceToPlayer = Mathf.Infinity;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
        ChasePlayer();
        AttackPlayer();
    }

    void ChasePlayer()
    {
        if (distanceToPlayer <= chaseRange)
        {
            anim.SetBool("Attacking", false);
            anim.SetBool("Walk", true);
            navMeshAgent.SetDestination(playerTransform.position);
        }
        
        if (distanceToPlayer > chaseRange)
        {
            anim.SetBool("Walk", false);
        }
        
    }

    void AttackPlayer()
    {
        if (distanceToPlayer <= navMeshAgent.stoppingDistance)
        {
            anim.SetBool("Attacking", true);
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, chaseRange);
    //}
}
