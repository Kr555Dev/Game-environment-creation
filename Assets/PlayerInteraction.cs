using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public AudioClip cubeCollisionSound;
    public AudioClip sphereCollisionSound;
    public AudioClip cylinderCollisionSound;
    public AudioClip capsuleCollisionSound;

    private AudioSource audioSource;
    private Transform targetObject;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Rotate the player character towards the target object
        if (targetObject != null)
        {
            Vector3 targetDirection = targetObject.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Play a specific sound when colliding with a game object
        if (other.CompareTag("Cube"))
        {
            audioSource.PlayOneShot(cubeCollisionSound);
        }
        else if (other.CompareTag("Sphere"))
        {
            audioSource.PlayOneShot(sphereCollisionSound);
        }
        else if (other.CompareTag("Cylinder"))
        {
            audioSource.PlayOneShot(cylinderCollisionSound);
        }
    }

    void OnMouseEnter()
    {
        // Set the target object when mouse hovers over a game object
        targetObject = transform;
    }

    void OnMouseExit()
    {
        // Reset the target object when mouse exits from the game object
        targetObject = null;
    }
}
