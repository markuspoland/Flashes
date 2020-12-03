using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public string hint;
    public OnScreenHint hintLabel;
    public List<GameObject> objectsToShow;
    public Key key;
    public IPickable pickable;
    public AudioClip pickupSound;
    public AudioClip cantInteractSound;
    public AudioClip interactSound;

    AudioSource audioSource;

    private InteractibleObject interactible;
    private bool aleadyInteracted = false;
    private bool aleadyKeyUsed = false;
    private IInventory inventory;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        interactible = GetComponent<InteractibleObject>();
        pickable = GetComponent<IPickable>();
        inventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        if (interactible.CanInteract() && Input.GetKeyDown(KeyCode.E))
        {
            if (pickable != null)
            {
                audioSource.PlayOneShot(pickupSound);
                interactible.Disable();
                pickable.PickUp();
                aleadyInteracted = true;
            }
            else
            {
                Interact();
            }
        }
    }

    private void Interact()
    {
        if (key != null)
        {
            if (!inventory.HasItem(key as IPickable, Inventory.ItemType.KEY))
            {
                FirstStep();
            } else
            {
                UseKey();
            }
        } else
        {
            FirstStep();
        }
    }

    private void FirstStep()
    {
        hintLabel.ShowHint(hint);
        audioSource.PlayOneShot(cantInteractSound);
        if (!aleadyInteracted)
        {
            EnableObjects();
            aleadyInteracted = true;
        }
    }
    private void UseKey()
    {
        if (!aleadyKeyUsed)
        {
            audioSource.PlayOneShot(interactSound);
            interactible.Disable();
            key.UseKey();
            aleadyKeyUsed = true;
        }
    }

    private void EnableObjects()
    {
        foreach (GameObject gameObject in objectsToShow)
        {
            gameObject.SetActive(true);
        }
    }
}
