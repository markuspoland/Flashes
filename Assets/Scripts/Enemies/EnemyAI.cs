using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float chaseRange = 10f;
    public float turnSpeed = 2f;
    public Transform playerTransform;
    public Transform bloodPos;
    [HideInInspector]
    public Animator anim;

    public bool isHit = false;
    public bool IsKilled = false;

    public AudioClip hitBlood;
    public AudioClip getHit;
    public AudioClip[] footsteps;

    AudioSource audioSource;
    EnemyHealth enemyHealth;
    NavMeshAgent navMeshAgent;

    float distanceToPlayer = Mathf.Infinity;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        enemyHealth = GetComponent<EnemyHealth>();
    }
    void Start()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
        //enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsKilled || !navMeshAgent.enabled) return;
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
    }

    void ChasePlayer()
    {

        if (distanceToPlayer <= chaseRange)
        {
            FaceTarget();
            anim.SetBool("Attacking", false);
            anim.SetBool("Walk", true);
            navMeshAgent.SetDestination(playerTransform.position);
            navMeshAgent.isStopped = false;
        }

        if (distanceToPlayer > chaseRange)
        {
            anim.SetBool("Walk", false);
            navMeshAgent.isStopped = true;
        }

    }

    void AttackPlayer()
    {
        if (distanceToPlayer <= navMeshAgent.stoppingDistance)
        {
            anim.SetBool("Attacking", true);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void EnableNavMesh()
    {
        navMeshAgent.enabled = true;
    }

    public void DisableNavMesh()
    {
        navMeshAgent.enabled = false;
    }

    public void GetHit(float damage)
    {
        if (IsKilled) return;
        enemyHealth.TakeDamage(damage);
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

    public void PlayFootstep(int foot)
    {
        audioSource.PlayOneShot(footsteps[foot], 0.5f);
    }
}
