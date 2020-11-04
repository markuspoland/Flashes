using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mouseX;
    float mouseY;

    public float mouseSensitivity = 100f;

    float xRotation = 0f;

    public Transform playerBody;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.ControlsLock()) return;

        GetInput();
        HandleRotation();
    }

    void HandleRotation()
    {
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -72f, 72f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    void GetInput()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }
}
