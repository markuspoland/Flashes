using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScream : MonoBehaviour
{
    public AudioClip audioClip;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMonsterScream()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
