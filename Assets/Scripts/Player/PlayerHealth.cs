using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health = 100f;
    [SerializeField]
    float maxHealth = 100f;
    PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void Heal(float heal)
    {
        health += heal;
        if (health > maxHealth) health = maxHealth;
    }

    private void Die()
    {
        playerController.IsKilled = true;
        playerController.ShowActionCamera();
        playerController.animator.SetTrigger("death");
    }
}
