using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 300f;
    [SerializeField]
    float maxHealth = 300f;
    CapsuleCollider capsuleCollider;

    EnemyAI enemy;

    AudioSource audioSource;
    public AudioClip deathSound;

    private void Start()
    {
        enemy = GetComponent<EnemyAI>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        audioSource = GetComponent<AudioSource>();
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
        enemy.IsKilled = true;
        audioSource.Stop();
        audioSource.PlayOneShot(deathSound);
        enemy.anim.SetBool("killed", true);
        capsuleCollider.enabled = false;
    }
}
