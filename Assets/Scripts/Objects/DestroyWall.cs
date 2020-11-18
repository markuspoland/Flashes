using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    Rigidbody[] bricks;
    AudioSource audioSource;
    public AudioClip wallClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WallDestroy()
    {
        audioSource.PlayOneShot(wallClip);
        bricks = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody brick in bricks)
        {
            brick.isKinematic = false;
            brick.AddForce(Vector3.forward * 200, ForceMode.Impulse);
            StartCoroutine(DisableCollider(brick));
        }
    }

    private IEnumerator DisableCollider(Rigidbody brick)
    {
        yield return new WaitForSeconds(1f);
        brick.GetComponent<MeshCollider>().enabled = false;
    }
}
