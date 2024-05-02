using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity = 2f;

    private Transform playerTransform;
    private float mouseX, mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerTransform = transform.parent;
    }

    void Update()
    {
        // Get mouse input for camera rotation
        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        // Rotate the player based on mouse input
        playerTransform.rotation = Quaternion.Euler(0f, mouseX, 0f);

        // Rotate the camera vertically based on mouse input
        transform.localRotation = Quaternion.Euler(mouseY, 0f, 0f);
    }
}
