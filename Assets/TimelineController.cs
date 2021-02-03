using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    Animator anim;
    EnemyAI enemy;
    PlayableDirector director;
    void Start()
    {
        anim = GetComponent <Animator>();
        enemy = GetComponent<EnemyAI>();
        director = GetComponent<PlayableDirector>();
        enemy.DisableNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(director.state == PlayState.Playing))
        {
            enemy.EnableNavMesh();
            anim.applyRootMotion = false;
            enabled = false;
        }
    }
}
