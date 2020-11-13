using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneTwo : MonoBehaviour
{
    PlayableDirector director;
    public PlayerController playerController;
    
    void Start()
    {
        director = GetComponent<PlayableDirector>();
        playerController.IsImmobilized = true;
        playerController.ShowDefaultCamera(7.5f, () => { playerController.IsImmobilized = false; });
    }

    
    void Update()
    {
        
    }
}
