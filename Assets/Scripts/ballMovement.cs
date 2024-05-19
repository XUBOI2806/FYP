using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    // Update the movement of the ball when collided with
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(0, 10, 0);
        }
    }
}
