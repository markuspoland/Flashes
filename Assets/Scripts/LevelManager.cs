using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ScenePostProcess postProcess;
    float timer = 0f;
    
    void Start()
    {        
        postProcess.SetExposureToTarget();
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1f * Time.deltaTime;

        if (timer < 7f)
        {
            CheckIfTimeJumped();
        } else
        {
            gameObject.SetActive(false);
        }
        

    }

    private void CheckIfTimeJumped()
    {
        //if (postProcess.IsFaded())
         postProcess.FadeOut();           

    }

    
}
