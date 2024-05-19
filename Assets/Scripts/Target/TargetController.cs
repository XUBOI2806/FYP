using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float decreaseSizeFactor = 0.9f; // Factor to decrease the size of the targets
    public float expandSizeFactor = 1.1f; // Factor to increase the size of the targets

    private float speed = 1f; // Speed of target movement
    public GameObject[] targets; // Array of target GameObjects
    public Vector3[] endPosition; // Array of end positions for each target
    public bool setupEndPositionBool; // Flag to check if end positions are set up
    public Vector3[] startPosition; // Array of start positions for each target
    public bool setupStartPositionBool; // Flag to check if start positions are set up
    public bool[] moveToEnd; // Array of flags to determine if targets should move to end positions
    public bool setupBool; // Flag to check if setup for moveToEnd array is done
    
    // Start is called before the first frame update
    void Start()
    {
        setupEndPositionBool = true;
        setupStartPositionBool = true;
        setupBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        setupStartPosition();
        setupEndPosition();
        setupMoveBoolArray();
    }

    // Randomize function for all targets
    public void randomiseTargets()
    {
        foreach(GameObject target in targets)
        {
            // Set each target to a random position within specified bounds
            target.transform.localPosition = new Vector3(Random.Range(-3.16f, 3.163f), Random.Range(0.484f, 1.955f), 1.117f);
        }
        setupStartPositionBool = true; // Reset the start position setup flag
    }

    // Function to get the index number for a target given its name
    private int getTargetIndex(string targetName)
    {
        switch (targetName)
        {
            case "Bottom Left Target":
                return 0;
            case "Top Left Target":
                return 1;
            case "Bottom Right Target":
                return 2;
            case "Top Right Target":
                return 3;
            default:
                return -1; // Return -1 if the target name is not recognized
        }
    }

    // Method used to set random end positions for each target
    public void setupEndPosition()
    {
        if (setupEndPositionBool)
        {
            endPosition = new Vector3[targets.Length]; // Initialize the endPosition array
            foreach (GameObject target in targets)
            {
                int i = getTargetIndex(target.name);
                if (i != -1)
                {
                    // Set a random end position within specified bounds
                    endPosition[i] = new Vector3(Random.Range(-3.16f, 3.163f), Random.Range(0.484f, 1.955f), 1.117f);
                }
            }
            setupEndPositionBool = false; // Reset the end position setup flag
        }
    }

    // Method to set the moveToEnd array to all true
    public void setupMoveBoolArray()
    {
        if (setupBool)
        {
            moveToEnd = new bool[targets.Length]; // Initialize the moveToEnd array
            for (int i = 0; i < moveToEnd.Length; i++)
            {
                moveToEnd[i] = true; // Set all elements to true
            }
            setupBool = false; // Reset the setup flag
        }
    }

    // Method to initialize start positions
    public void setupStartPosition()
    {
        if (setupStartPositionBool)
        {
            startPosition = new Vector3[targets.Length]; // Initialize the startPosition array
            foreach(GameObject target in targets)
            {
                int i = getTargetIndex(target.name);
                if(i != -1)
                {
                    startPosition[i] = target.transform.localPosition; // Set the start position to the current local position
                }
            }
            setupStartPositionBool = false; // Reset the start position setup flag
        }
    }

    // Method to handle target movement
    public void moveTarget()
    {
        foreach (GameObject target in targets)
        {
            if (target != null)
            {
                int i = getTargetIndex(target.name);
                Vector3 destination = moveToEnd[i] ? endPosition[i] : startPosition[i];

                // Calculate the direction to the current waypoint
                Vector3 direction = destination - target.transform.localPosition;
                direction.Normalize();

                // Move the object towards the current waypoint
                target.transform.localPosition += direction * speed * Time.deltaTime;

                // Check the distance to the current waypoint
                float distance  = Vector3.Distance(target.transform.localPosition, destination);
                if (distance < 0.1f) 
                {
                    moveToEnd[i] = !moveToEnd[i]; // Toggle the move direction
                }
            }
        }
    }

    // Increase the movement speed of the targets
    public void increaseTargetMovementSpeed()
    {
        speed += 1;
    }

    // Decrease the movement speed of the targets
    public void decreaseTargetMovementSpeed()
    {
        if (speed > 0)
        {
            speed -= 1;
        }
    }

    // Shrink the targets
    public void ShrinkTargets()
    {
        foreach (GameObject target in targets)
        {
            target.transform.localScale *= decreaseSizeFactor; // Scale down the target
        }
    }

    // Expand the targets
    public void ExpandTargets()
    {
        foreach (GameObject target in targets)
        {
            // Scale up the target
            target.transform.localScale *= expandSizeFactor;
        }
    }
}
