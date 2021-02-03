using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    Animator anim;
    EnemyAI enemy;
    PlayableDirector director;

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyAI>();
        director = GetComponent<PlayableDirector>();
    }
    void Start()
    {
        
        if (enemy)
        {
            DisableEnemyNavMesh();
        }
        
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

    void DisableEnemyNavMesh()
    {
        enemy.DisableNavMesh();
    }
}
