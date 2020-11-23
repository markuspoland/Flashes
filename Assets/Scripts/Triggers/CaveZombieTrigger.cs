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
            enemy.anim.SetTrigger("getup");
            Destroy(gameObject);
        }
    }
}
