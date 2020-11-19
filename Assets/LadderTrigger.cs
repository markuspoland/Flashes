using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LadderTrigger : MonoBehaviour
{
    public PlayerController playerController;
    public PlayableDirector director;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.ShowActionCamera();
            director.Play();
            playerController.ShowDefaultCamera(5.3f);
        }
    }
}
