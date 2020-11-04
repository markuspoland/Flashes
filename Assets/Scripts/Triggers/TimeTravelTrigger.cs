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

    public TimeTravelType timeTravelType;

    public TimeTravel timeTravel;
    bool isTravelling = false;
    public Animator playerAnim;
    public List<GameObject> objectsToShow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTravelling)
        {
            switch (timeTravelType)
            {
                case TimeTravelType.BLINDED:
                    timeTravel.FlashAndFall();
                    Destroy(gameObject, 3f);
                    break;
                case TimeTravelType.NOTHING:
                    timeTravel.Flash();
                    Destroy(gameObject, 3f);
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (timeTravelType == TimeTravelType.BLINDED)
            {
                playerAnim.SetTrigger("blinded");
            }
            
            isTravelling = true;
            EnableObjects();
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
