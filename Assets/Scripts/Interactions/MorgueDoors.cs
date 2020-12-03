using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorgueDoors : MonoBehaviour
{
    public List<Animator> doorAnimators;
    public AudioClip doorOpen;

    AudioSource audioSource;
    InteractibleObject interactible;

    void Start()
    {
        interactible = GetComponent<InteractibleObject>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (interactible.CanInteract() && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.PlayOneShot(doorOpen);
            interactible.Disable();
            foreach (Animator anim in doorAnimators)
            {
                anim.enabled = true;
            }
        }
    }
}
