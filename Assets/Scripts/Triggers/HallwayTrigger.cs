using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayTrigger : MonoBehaviour
{
    public List<Light> lights;
    public GameObject zombie;
    public TimeTravel timeTravel;
    public List<Renderer> lampRenderers;
    public ScenePostProcess postProcess;
    public AudioClip horrorHit;

    bool playerEntered = false;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!playerEntered)
            {
                postProcess.SetTargetExposure();
                StartCoroutine(ScaryMoment());
            }
            
        }
    }

    IEnumerator ScaryMoment()
    {
        var emisColor = Color.white * 0f;
        lights[0].enabled = false;
        lampRenderers[0].material.SetColor("_EmissiveColor", emisColor);
        audioSource.PlayOneShot(horrorHit);
        yield return new WaitForSeconds(0.5f);
        lights[1].enabled = false;
        lampRenderers[1].material.SetColor("_EmissiveColor", emisColor);
        audioSource.PlayOneShot(horrorHit);
        zombie.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        timeTravel.FlashAndFall(3f, 6f);
        yield return new WaitForSeconds(2.7f);
        zombie.SetActive(false);
        foreach(var light in lights)
        {
            light.enabled = true;
        }
        emisColor = Color.white * 3.152447f;
        foreach (var lampRend in lampRenderers)
        {
            lampRend.material.SetColor("_EmissiveColor", emisColor);
        }
        playerEntered = true;
        Destroy(gameObject, 2f);
    }
}
