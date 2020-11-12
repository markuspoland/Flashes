using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelTrigger : MonoBehaviour
{
    public enum TimeTravelType
    {
        BLINDED,
        NOTHING
    }

    public ScenePostProcess postProcess;

    public TimeTravelType timeTravelType;
    public float flashingTime = 3f;
    public float regainMovementTime = 6f;
 
    public TimeTravel timeTravel;
    public Animator playerAnim;
    public List<GameObject> objectsToShow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (timeTravelType)
            {
                case TimeTravelType.BLINDED:
                    postProcess.SetTargetExposure();
                    timeTravel.FlashAndFall(flashingTime, regainMovementTime);
                    break;
                case TimeTravelType.NOTHING:
                    postProcess.SetTargetExposure();     
                    timeTravel.Flash(flashingTime);
                    break;
            }

            EnableObjects();
            Destroy(gameObject);
        }
    }

    private void EnableObjects()
    {

        if (objectsToShow != null)
        {
            foreach (GameObject gameObject in objectsToShow)
            {
                gameObject.SetActive(true);
            }
        } else
        {
            return;
        } 
    }
}
