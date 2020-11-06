using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ScenePostProcess postProcess;

    
    void Start()
    {        
        postProcess.SetExposureToTarget();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeJumped();

    }

    private void CheckIfTimeJumped()
    {
        //if (postProcess.IsFaded())
         postProcess.FadeOut();           

    }
}
