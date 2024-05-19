using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegFollower : MonoBehaviour
{
    public GameObject leg; // The leg GameObject that this object will follow
    
    void FixedUpdate()
    {
        // Set the rotation of this object to match the rotation of the leg
        transform.rotation = leg.transform.rotation;

        // Set the position of this object to match the position of the leg
        transform.position = leg.transform.position;
    }
}
