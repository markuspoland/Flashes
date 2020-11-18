using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieVillageTrigger : MonoBehaviour
{
    public GameObject zombie;
    public GameObject timeTravelTrigger;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zombie.SetActive(true);
            timeTravelTrigger.SetActive(true);
            Destroy(this, 0.3f);
        }
    }


}
