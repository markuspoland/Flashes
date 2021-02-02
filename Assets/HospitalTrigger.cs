using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalTrigger : MonoBehaviour
{
    public CameraHandler cameraHandler;
    public PlayerController playerController;
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

            StartCoroutine(ZombiesComeOut());
        }
    }

    IEnumerator ZombiesComeOut()
    {
        playerController.IsImmobilized = true;
        cameraHandler.ActivateTargetCamera();
        yield return new WaitForSeconds(4f);
        cameraHandler.ActivateSourceCamera();
        yield return new WaitForSeconds(0.2f);
        playerController.IsImmobilized = false;
        Destroy(gameObject);
    }
}
