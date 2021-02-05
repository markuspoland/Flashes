using System.Collections;
using UnityEngine;
using System.Linq;

public class Weapon : MonoBehaviour, IPickable
{
    public float hitRadius = 0.5f;

    public GameObject bloodFX;

    PlayerController playerController;
    PlayerCombat playerCombat;
    IInventory inventory;
    bool hitEnabled = false;

    AudioSource audioSource;
    public AudioClip axeSwipe;

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = FindObjectOfType<PlayerController>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        inventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        TriggerHitColliders(transform.position, hitRadius);
    }

    public enum Type
    {
        MELEE,
        RANGED_ONE_HAND
    }

    public float damageOnHit = 50f;

    public Vector3 InHandPosition = new Vector3();
    public Vector3 InHandRotation = new Vector3();

    public Type WeaponType = Type.MELEE;

    public void PickUp()
    {
        inventory.AddItem(this, Inventory.ItemType.WEAPON);
        GrabWeapon();
    }

    private void GrabWeapon()
    {
        playerController.ShowActionCamera();
        TriggerAction("grabFromFloor");
        ChangeWeaponAnimationLayer();
        StartCoroutine(GrabWeaponFromFloor());
        playerController.ShowDefaultCamera(2.1f);
        playerCombat.EquippedWeapon = this;
    }

    private void ChangeWeaponAnimationLayer()
    {
        switch (WeaponType)
        {
            case Type.MELEE:
                playerController.animator.SetBool("equippedAxe", true);
                break;
            case Type.RANGED_ONE_HAND:
                playerController.animator.SetBool("equippedPistol", true);
                break;
        }
    }

    private void EquipWeapon()
    {
        transform.parent = playerController.rightHand.transform;
        transform.localPosition = InHandPosition;
        transform.localRotation = Quaternion.Euler(InHandRotation);
    }

    IEnumerator GrabWeaponFromFloor()
    {
        yield return new WaitForSeconds(1f);
        EquipWeapon();
    }

    private void TriggerAction(string action)
    {
        playerController.animator.SetTrigger(action);
    }

    public void ActivateHitCollider(bool active)
    {
        hitEnabled = active;
    }

    void TriggerHitColliders(Vector3 center, float radius)
    {
        if (!hitEnabled) return;

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            EnemyAI enemy = hitCollider.gameObject.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.isHit = true;
                Instantiate(bloodFX, enemy.bloodPos.position, enemy.bloodPos.rotation);
                enemy.GetHit(damageOnHit);
                hitEnabled = false;
                return;
            }
        }
    }

    public void PlaySwipeAudio()
    {
        Invoke("Swipe", 0.5f);
    }

    void Swipe()
    {
        audioSource.PlayOneShot(axeSwipe);
    }
}