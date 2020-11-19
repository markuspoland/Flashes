using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public GameObject rightHand;
    EnemyAI enemy;

    void Start()
    {
        enemy = GetComponent<EnemyAI>();
    }

    public void EnableRightHandAttack()
    {
       if (!enemy.IsKilled) rightHand.SetActive(true);
    }

    public void DisableRightHandAttack()
    {
        rightHand.SetActive(false);
    }
}
