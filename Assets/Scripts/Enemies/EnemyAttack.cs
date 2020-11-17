using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public GameObject rightHand;

    void Start()
    {
        
    }

    public void EnableRightHandAttack()
    {
        rightHand.SetActive(true);
    }

    public void DisableRightHandAttack()
    {
        rightHand.SetActive(false);
    }
}
