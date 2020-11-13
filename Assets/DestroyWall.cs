using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    Rigidbody[] bricks;

    void Start()
    {
        bricks = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody brick in bricks)
        {
            brick.isKinematic = false;
            brick.AddForce(Vector3.forward * 200, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
