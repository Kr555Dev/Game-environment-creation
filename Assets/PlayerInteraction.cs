using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public AudioClip cubeCollisionSound;
    public AudioClip sphereCollisionSound;
    public AudioClip cylinderCollisionSound;
    public AudioClip capsuleCollisionSound;

    private AudioSource audioSource;
    private Transform targetObject;

    private int score = 0;

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

    private void OnCollisionEnter(Collision collision)
    {
        Material collidedMaterial = collision.gameObject.GetComponent<Renderer>().material;
        string materialName = collidedMaterial.name;


        // Use the material name as needed
        Debug.Log("Collided with material: " + materialName);

        if (collision.gameObject.CompareTag("Cube"))
        {
            audioSource.PlayOneShot(cubeCollisionSound); 
        }
        if (collision.gameObject.CompareTag("Sphere"))
        {
            audioSource.PlayOneShot(sphereCollisionSound);
        }
        if (collision.gameObject.CompareTag("Cylinder"))
        {
            audioSource.PlayOneShot(cylinderCollisionSound);
        }
        if (collision.gameObject.CompareTag("Capsule"))
        {
            audioSource.PlayOneShot(capsuleCollisionSound);
        }

    }
    //void OnTriggerEnter(Collider other)
    //{
    //    // Play a specific sound when colliding with a game object
    //    if (other.CompareTag("Cube"))
    //    {
    //        audioSource.PlayOneShot(cubeCollisionSound);
    //    }
    //    else if (other.CompareTag("Sphere"))
    //    {
    //        audioSource.PlayOneShot(sphereCollisionSound);
    //    }
    //    else if (other.CompareTag("Cylinder"))
    //    {
    //        audioSource.PlayOneShot(cylinderCollisionSound);
    //    }
    //    else if (other.CompareTag("Capsule"))
    //    {
    //        audioSource.PlayOneShot(capsuleCollisionSound);
    //    }
    //}

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
