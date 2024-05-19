using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class targetScript : MonoBehaviour
{
    GameObject target; // Reference to the target GameObject
    public ScoreManager ScoreManager; // Reference to the ScoreManager for incrementing score

    public GameObject fractured; // Prefab for the fractured version of the target

    // This method is called when the target collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is named "Ball"
        if (collision.gameObject.name == "Ball")
        {
            // Increment the score using the ScoreManager
            ScoreManager.IncrementScore();

            // Store the current position of the target
            Vector3 oldPos = transform.position;

            // Instantiate the fractured version of the target at the same position
            GameObject fracturedInstance = Instantiate(fractured, oldPos, Quaternion.identity);

            // Start a coroutine to destroy the fractured object after a delay
            StartCoroutine(DestroyFracturedObjectAfterDelay(fracturedInstance, 2));

            // Disable the mesh renderer of the original target to make it invisible
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Coroutine to destroy the fractured object and the original target after a delay
    private IEnumerator DestroyFracturedObjectAfterDelay(GameObject obj, float delay)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        // Destroy the fractured object
        Destroy(obj);

        // Destroy the original target
        Destroy(gameObject);
    }
}