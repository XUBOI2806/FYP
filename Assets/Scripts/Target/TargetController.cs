using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float decreaseSizeFactor = 0.9f;
    public float expandSizeFactor = 1.1f;

    // Define the duration of movement
    public float duration = 3f;



    public GameObject[] targets;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // randomise function for all targets
    public void randomiseTargets()
    {
        foreach(GameObject target in targets)
        {
            target.transform.localPosition = new Vector3(Random.Range(-3.16f, 3.163f), Random.Range(0.484f, 1.955f), 1.117f);
        }
    }

    // move targets from x = 3 to x = -3
    public void moveTarget()
    {


        // Define the start and end positions
        Vector3 startPosition;
        Vector3 endPosition;

        

        // Interpolate the position over time
        foreach (GameObject target in targets)
        {
            if (target != null)
            {
                Debug.Log("Initial position of " + target.name + ": " + target.transform.position);
                switch (target.name)
                {
                    case "Bottom Left Target":
                        startPosition = new Vector3(3.163f, 0.5f, 1.17f);
                        endPosition = new Vector3(-3.163f, 0.5f, 1.7f);
                        break;
                    case "Top Left Target":
                        startPosition = new Vector3(3.163f, 1.955f, 1.17f);
                        endPosition = new Vector3(-3.163f, 1.955f, 1.17f);
                        break;
                    case "Bottom Right Target":
                        startPosition = new Vector3(-3.163f, 0.5f, 1.17f);
                        endPosition = new Vector3(3.163f, 0.5f, 1.17f);
                        break;
                    case "Top Right Target":
                        startPosition = new Vector3(-3.163f, 1.955f, 1.17f);
                        endPosition = new Vector3(3.163f, 1.955f, 1.17f);
                        break;
                    default:
                        startPosition = new Vector3(4f, 4f, 27f);
                        endPosition = new Vector3(6f, 4f, 27f);
                        break;
                }

                // Calculate the current position based on time

                float timeFraction = Mathf.PingPong(Time.time, duration) / duration;
                Vector3 newPosition = Vector3.Lerp(startPosition, endPosition, timeFraction);

                // Update the target's position
                target.transform.localPosition = newPosition;


            }

        }
    }



    public void ShrinkTargets()
    {
        foreach (GameObject target in targets)
        {
            
            // Scale down the target by resizeFactor
            target.transform.localScale *= decreaseSizeFactor;
            Debug.Log("ShrinkTargets()");
            
        }
    }
    public void ExpandTargets()
    {
        foreach (GameObject target in targets)
        {
            
            // Scale down the target by resizeFactor
            target.transform.localScale *= expandSizeFactor;
            Debug.Log("ShrinkTargets()");
            
        }
    }
}
