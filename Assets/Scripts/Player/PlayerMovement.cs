using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    float x, z;
    Vector3 move;
    public CharacterController controller;

    public float speed = 3f;
    public float sprintSpeed = 6f;
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
        if (playerController.ControlsLock())
        {
            playerController.animator.SetFloat("velX", 0);
            playerController.animator.SetFloat("velY", 0);
        }        

        AnimateMovement();
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
       

        float playerSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        move = transform.right * x + transform.forward * z;
        controller.Move(move * playerSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        playerController.animator.SetFloat("velX", x);
        playerController.animator.SetFloat("velY", z);
    }
}
