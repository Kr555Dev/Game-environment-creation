using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input from player (e.g., WASD keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Set animator parameters based on input
        animator.SetFloat("SpeedX", horizontalInput);
        animator.SetFloat("SpeedY", verticalInput);
    }
}
