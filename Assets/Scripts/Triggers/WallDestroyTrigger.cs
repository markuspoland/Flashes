using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroyTrigger : MonoBehaviour
{
    public DestroyWall wall;
    public Animator playerAnim;
    public PlayerController playerController;
    public GameObject monster;
    public GameObject enterMonsterAnim;
    public EnemyAI monsterAI;
    public CameraHandler cameraHandler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.IsImmobilized = true;
            playerController.ShowActionCamera();
            wall.WallDestroy();
            monster.SetActive(true);
            enterMonsterAnim.SetActive(true);
            playerAnim.SetTrigger("Block");
            StartCoroutine(MonsterScream());
            
        }
    }

    IEnumerator MonsterScream()
    {
        yield return new WaitForSeconds(1f);
        cameraHandler.ActivateTargetCamera();
        yield return new WaitForSeconds(2f);
        cameraHandler.ActivateSourceCamera();
        playerController.ShowDefaultCamera();
        playerController.IsImmobilized = false;
        monsterAI.EnableNavMesh();
        Destroy(gameObject);
    }
}
