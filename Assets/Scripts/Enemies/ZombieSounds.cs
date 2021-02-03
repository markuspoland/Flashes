using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSounds : MonoBehaviour
{

    public AudioClip zombieGettingUp;
    public AudioClip zombieMoaning;
    public AudioClip femaleZombieAttack;
    public AudioClip femaleZombieDeath;

    AudioSource audioSource;
     
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGettingUpSound()
    {
        audioSource.PlayOneShot(zombieGettingUp);
    }

    public void PlayMoaningSound()
    {
                
            if (audioSource.isPlaying || !audioSource) return;

            audioSource.loop = true;
            audioSource.clip = zombieMoaning;
            audioSource.Play();
       
    }

    public void FemaleZombieAttack()
    {
        audioSource.PlayOneShot(femaleZombieAttack);
    }

    public void FemaleZombieDeath()
    {

    }

   
}
