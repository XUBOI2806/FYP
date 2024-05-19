using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBall : MonoBehaviour
{
    private Vector3 velocity; // Stores the velocity of the object
    private Vector3 previous; // Stores the previous position of the object
    private bool isLaceKicking; // Indicates if lace kicking is enabled
    private bool isSideKicking; // Indicates if side kicking is enabled

    void FixedUpdate()
    {
        // Disable the collider if neither lace kicking nor side kicking is enabled
        if(!isLaceKicking && !isSideKicking)
        {
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            // Enable the collider if either lace kicking or side kicking is enabled
            GetComponent<Collider>().enabled = true;
        }
        
        // Calculate the velocity based on the change in position and time
        velocity = ((transform.position - previous)) / Time.fixedDeltaTime;
        
        // Update the previous position to the current position
        previous = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding is tagged as "Ball"
        if(collision.gameObject.tag == "Ball")
        {
            Debug.Log("Ball Detected");

            // Apply force to the ball if lace kicking is enabled
            if(isLaceKicking)
            {
                Debug.Log("Lace Kick");
                collision.gameObject.GetComponent<Rigidbody>().AddForce(velocity.x * 50, velocity.magnitude * 20, velocity.z * 50);
            }

            // Apply force to the ball if side kicking is enabled
            if(isSideKicking)
            {
                Debug.Log("Side Kick");
                collision.gameObject.GetComponent<Rigidbody>().AddForce(velocity.x * 30, 0, velocity.z * 30);
            }
        }
    }

    // Enable side kicking
    public void enableSideKicking()
    {
        isSideKicking = true;
    }

    // Enable lace kicking
    public void enableLaceKicking()
    {
        isLaceKicking = true;
    }

    // Disable side kicking
    public void disableSideKicking()
    {
        isSideKicking = false;
    }

    // Disable lace kicking
    public void disableLaceKicking()
    {
        isLaceKicking = false;
    }
}
