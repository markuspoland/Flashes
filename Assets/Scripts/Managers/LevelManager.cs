using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ScenePostProcess postProcess;
    public TimeTravel timeTravel;
    float timer = 0f;
    
    void Start()
    {
        //Invoke("PlayTimeJumpHalfTwo", 0.1f);
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

    void PlayTimeJumpHalfTwo()
    {
        //timeTravel.PlayTimeJumpHalfTwo();
    }
}
