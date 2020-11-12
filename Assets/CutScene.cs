using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutScene : MonoBehaviour
{
    PlayableDirector playableDirector;
    public PlayerController playerController;
    //CameraHandler cameraHandler;
    void Start()
    {
        playerController.ShowActionCamera();
        playableDirector = GetComponent<PlayableDirector>();
        playerController.IsImmobilized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playableDirector.time >= 11.00d)
        {
            playerController.IsImmobilized = false;
            playerController.ShowDefaultCamera();
        }
    }
}
