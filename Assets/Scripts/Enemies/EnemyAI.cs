using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public float chaseRange = 10f;
    public Transform playerTransform;
    public Transform bloodPos;
    Animator anim;

    public bool isHit = false;

    AudioSource audioSource;
    public AudioClip hitBlood;
    public AudioClip getHit;

    float distanceToPlayer = Mathf.Infinity;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
        
        if (!IsHit())
        {
           ChasePlayer();         
        } 

        if (IsHit())
        {
            StartCoroutine(StopChasingTemporarily(1.5f));
        }
        AttackPlayer();

        Debug.Log("Hit? " + isHit);
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

    public void GetHit()
    {
        anim.SetTrigger("hit1");
        audioSource.PlayOneShot(hitBlood);
        audioSource.PlayOneShot(getHit);
    }

    public bool IsHit()
    {
        return isHit;
    }

    IEnumerator StopChasingTemporarily(float time = 1f)
    {
        navMeshAgent.isStopped = true;
        yield return new WaitForSeconds(time);
        isHit = false;
        navMeshAgent.isStopped = false;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, chaseRange);
    //}
}
