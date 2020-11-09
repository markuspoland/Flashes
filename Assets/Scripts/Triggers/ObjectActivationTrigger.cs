using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivationTrigger : MonoBehaviour
{

    public List<GameObject> objectToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in objectToActivate)
            {
                obj.SetActive(true);
            }
            Destroy(this);
        }
    }
}
