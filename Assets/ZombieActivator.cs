using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class ZombieActivator : MonoBehaviour
{
    public TimelineAsset timelineAsset;
    float track1dur = 4.11f;
    //List<TimelineClip> clips = new List<TimelineClip>();

    void Start()
    {
        
        
    }

    
    void Update()
    {
        foreach (var track in timelineAsset.GetOutputTracks())
        {
            if (track.name.Equals("Zombie1"))
            {
               
            }
        }
    }
}
