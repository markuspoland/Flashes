using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivationTrigger : MonoBehaviour
{

    public List<GameObject> objectsToActivate;
    public List<GameObject> objectsToDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
            Destroy(this);
        }
    }
}
