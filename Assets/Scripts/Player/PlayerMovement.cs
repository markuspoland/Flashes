using UnityEngine;
using System.Collections;

public class PlayerMovement : PortalTraveller
{
    float x, z;
    Vector3 move;
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        //Press K to kill yourself or L to resurrect for testing purposes
        AnimateDying();
        AnimateResurrection();
        AnimateMovement();
    }

    private void AnimateDying()
    {
        if (playerController.IsKilled || playerController.IsResurrecting || playerController.IsImmobilized) return;

        if (Input.GetKeyDown(KeyCode.K))
        {
            playerController.IsKilled = true;
            playerController.ShowActionCamera();
            playerController.actionCam.Priority = 11;
            playerController.animator.SetBool("killed", true);
        }
    }

    private void AnimateResurrection()
    {
        if (!playerController.IsKilled || playerController.IsResurrecting || playerController.IsImmobilized) return;

        if (Input.GetKeyDown(KeyCode.L))
        {
            playerController.IsKilled = false;
            playerController.IsResurrecting = true;
            //callback action is called from player controller
            playerController.ShowDefaultCamera(3.1f, delegate { playerController.IsResurrecting = false; });
            playerController.animator.SetBool("killed", false);
        }
    }

    private void AnimateMovement()
    {
        if (playerController.ControlsLock()) return;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        playerController.animator.SetFloat("velX", x);
        playerController.animator.SetFloat("velY", z);
    }
}
