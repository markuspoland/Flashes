using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieVillageTrigger : MonoBehaviour
{
    public GameObject zombie;
    public GameObject timeTravelTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zombie.SetActive(true);
            timeTravelTrigger.SetActive(true);
            Destroy(gameObject, 0.3f);
        }
    }
}
