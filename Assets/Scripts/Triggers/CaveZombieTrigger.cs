using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveZombieTrigger : MonoBehaviour
{

    public EnemyAI enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EnableEnemy());
        }
    }

    private IEnumerator EnableEnemy()
    {
        enemy.anim.SetTrigger("getup");
        yield return new WaitForSeconds(5.15f);
        enemy.EnableNavMesh();
        Destroy(gameObject);
    }
}
