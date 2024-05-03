using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public AudioClip cubeCollisionSound;
    public AudioClip sphereCollisionSound;
    public AudioClip cylinderCollisionSound;
    public AudioClip capsuleCollisionSound;

    private AudioSource audioSource;
    private Transform targetObject;

    private int score = 0;
    public Text scoreText;

    int totalObjects;
    int collidedObjs = 0;
    private bool isGameComplete = false;
    public GameObject completionAnimation;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        totalObjects = GameObject.FindGameObjectsWithTag("Cube").Length +
            GameObject.FindGameObjectsWithTag("Sphere").Length +
             GameObject.FindGameObjectsWithTag("Cylinder").Length +
              GameObject.FindGameObjectsWithTag("Capsule").Length;

    }

    void Update()
    {
        UpdateScoreUI(); 

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

        if (materialName.Contains("green"))
            { IncreaseScore(10); }
        if (materialName.Contains("red"))
        { DecreaseScore(5); }
            


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

        collidedObjs++;
        if(collidedObjs >= totalObjects)
        {
            onCompleteGame();
        }

    }
    void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    void DecreaseScore(int points)
    {
        score -= points;
        if (score < 0)
        {
            score = 0; // Ensure score does not go negative
        }
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void onCompleteGame()
    {
        isGameComplete = true;
        completionAnimation.SetActive(true);
        Time.timeScale = 0;
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
