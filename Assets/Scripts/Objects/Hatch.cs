﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hatch : MonoBehaviour
{
    public Animator animator;
    public HatchKey item;
    public CameraHandler cameraHandler;
    public PlayerController playerController;
    public List<GameObject> objectToActivate;
    public List<GameObject> objectToDeactivate;
    public ScenePostProcess postProcess;
    public TimeTravel timeTravel;

    AudioSource audioSource;
    
    bool flash = false;

    IInventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (flash)
        {
            postProcess.FadeIn();
        }
    }

    public void OpenHatch()
    {
        if (inventory.HasItem(item, Inventory.ItemType.KEY))
        {
            animator.SetTrigger("openHatch");
            inventory.RemoveItem(item, Inventory.ItemType.KEY);
            ActivateItems();
            playerController.IsImmobilized = true;
            postProcess.SetTargetExposure();
            cameraHandler.ActivateTargetCamera();
            DeactivateItems();
            StartCoroutine(ResetCamera());
        }
    }

    void ActivateItems()
    {
        foreach (GameObject obj in objectToActivate)
        {
            obj.SetActive(true);
        }
    }

    void DeactivateItems()
    {
        foreach (GameObject obj in objectToDeactivate)
        {
            obj.SetActive(false);
        }
    }

    private IEnumerator ResetCamera()
    {
        timeTravel.PlayTimeJumpHalfOne();
        yield return new WaitForSeconds(1f);
        cameraHandler.ActivateEndCamera();
        playerController.gameObject.transform.Rotate(0f, 180f, 0f);
        flash = true;
        playerController.animator.SetTrigger("blinded");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(2);
    }
}
